
/*
Copyright 2016 OSIsoft, LLC.
Licensed under the Apache License, Version 2.0 (the License);
you may not use this file except in compliance with the License.
You may obtain a copy of the License at 

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing,
software distributed under the License is distributed on an AS IS BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and limitations under the License.

Please see the file named LICENSE.md.
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.Time;
using OSIsoft.AF.UnitsOfMeasure;
using OSIsoft.AF.PI;
using OSIsoft.AF.EventFrame;

using System.Text.RegularExpressions;

using System.Runtime.InteropServices;

namespace MATLABfromCSharp
{
    public class AFAccess
    {       
        static bool Timestamp;
        static int dataPref;
        static string dataFormat;

        // AFTime Range 
        /// <summary>
        /// Confirm that a valid start and end time were entered by the user.
        /// </summary>
        /// <param name="start">string of the Start Time.</param>
        /// <param name="end">string of End Time.</param>
        /// <returns> The AFTimeRange created using the start and end strings.</returns>
        private static AFTimeRange checkAFTimeRange(string start, string end)
        {
            AFTimeRange aftr;
            aftr = new AFTimeRange(start, end);
            return aftr;
        }
        /// <summary>
        /// Determines if the inputted strings are in PI Absolute Time.
        /// </summary>
        /// <param name="start">The string of the start time.</param>
        /// <param name="end">The string of the end time.</param>
        /// <param name="logInput">Adds the Absolute time to this logInput.</param>
        /// <returns></returns>
        public static bool isAbsoluteTimeString(string start, string end, LogInput logInput)
        {
            //Determine if AFTIME Absolute Time String
            DateTime DTstart, DTend;
            string[] stringTime;
            if (!DateTime.TryParse(start, out DTstart) || !DateTime.TryParse(end, out DTend))
            {
                stringTime = new string[] { start, end };
                logInput.setAbsoluteTime(stringTime);
                return true;
            }
            return false;
        }

        // Data Preferences
        /// <summary>
        /// Sets the Datapreferences in AFAccess.
        /// </summary>
        /// <param name="timestamp"> if true: exports the Timestamp with the data.</param>
        /// <param name="datapref">Integer for Attribute.GetValues; 0(raw), negative(Samples), positive(profiled samples)</param>
        /// <param name="format"> String representation of the Data Preference</param>
        public static void setDataPrefs(bool timestamp, int datapref, string format)
        {
            Timestamp = timestamp;
            dataPref = datapref;
            dataFormat = format;
        }
       
       
        // Getting Data from AFServer

        /// <summary>
        ///  Using AFSDK adds both PI Tags and Constant attribute values to Matlab.
        /// </summary>
        /// <remarks> Attribute.GetValues is an Important call <= Int32 determines level of specficity of returned values.</remarks>
        /// <param name="server_database"> String representing server and database</param>
        /// <param name="AttributeName"> The name of the attribute</param>
        /// <param name="MatlabName"> The variable name in the Matlab Workspace.</param>
        /// <param name="path"> The path to the AFElement.</param>
        /// <param name="start"> Start of Data Collection.</param>
        /// <param name="end"> End of Data Collection.</param>
        /// <param name="addToListView"> true: adds the log input to the Log. (generally true).</param>
        public static void getAFData(string server_database, string AttributeName, string MatlabName, string path, string start, string end, bool addToListView)
        {
           
            //Find Element & the Attribute
            List<string> searchPaths = new List<string>() { path };
            AFKeyedResults<string, AFElement> results = AFElement.FindElementsByPath(searchPaths, null);
            AFElement Element = results[path];
            AFAttribute attribute = Element.Attributes[AttributeName];

            getData(server_database, AttributeName, MatlabName, start, end, attribute, true);
                                  
        }

        /// <summary>
        /// Gets the data of the EventFrame attribute chosen.
        /// </summary>
        /// <param name="server_database"> Unique string representing the server and database</param>
        /// <param name="AttributeName"> The name of the AFEventFrame AFAttribute.</param>
        /// <param name="MatlabName"> The name of the variable in the Matlab workspace. </param>
        /// <param name="frame"> The AFEventFrame object.</param>
        /// <param name="addToListView"> true: adds input into the LogSystem. (Generally true)</param>
        public static void getEventFrameData(string server_database, string AttributeName, string MatlabName, AFEventFrame frame, bool addToListView)
       {
           getData(server_database, AttributeName, MatlabName, frame.StartTime.ToString(), frame.EndTime.ToString(), frame, true);                                  
       }

        /// <summary>
        /// Get the PIPoint data, uses AFSDK.
        /// </summary>
        /// <param name="MatlabName"> The variable name in Matlab workspace.</param>
        /// <param name="server"> The name of the server. </param>
        /// <param name="point"> The name of the Point.</param>
        /// <param name="start"> The start time of data collection.</param>
        /// <param name="end"> The end time of data collection.</param>
        /// <param name="addToListView">true: adds to the LogSystem ListView. (generally true)</param>
        public static void getPIData(string MatlabName, string server, string point, string start, string end, bool addToListView)
        {
            PIServer serv = PIServer.FindPIServer(server);
            PIPoint piPoint = PIPoint.FindPIPoint(serv, point);

            string server_database = "'" + server + "'-'PI.Point'";

            getData(server_database, point, MatlabName, start, end, piPoint, true);
        }

        /// <summary>
        ///  Common calls of getting Data from AFServer
        /// </summary>
        /// <param name="server_database">String representing the server and database</param>
        /// <param name="AttributeName"> name of the attribute</param>
        /// <param name="MatlabName">variable name for the Matlab Workspace</param>
        /// <param name="start">Start time of data collection.</param>
        /// <param name="end">End time of the data collection.</param>
        /// <param name="afobject"> AF object - AFAttribute, AFEventFrame, or PIPoint</param>
        /// <param name="addToListView"> Whether to add to the Listview (generally true)</param>
        public static void getData(string server_database,string AttributeName, string MatlabName, string start, string end, Object afobject, bool addToListView)
        {

                MatlabName = MatlabAccess.modifyMatlabName(MatlabName);
                LogInput logInput = null;
                AFValues Values = new AFValues();
                AFAttribute attribute;

                object[] vals;
                double[] dbVals;
                double[] timestamps = null;
                int[] statuses;
                int baddata;

                //TIME RANGE
                AFTimeRange aftr;
                try { aftr = checkAFTimeRange(start, end); }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                }

                /// Get Object
                Type type = afobject.GetType();
                string typestring = type.ToString();

                //  LogInput logInput = new LogInput(MatlabName, Element.Name, attribute.Name, path, aftr);
                switch (type.ToString())
                {
                    case "OSIsoft.AF.Asset.AFAttribute":
                        attribute = (AFAttribute)afobject;
                        logInput = new LogInput(MatlabName, attribute.Element.Name, attribute.Name, attribute.Element.GetPath(), aftr);
                        if (attribute.PIPoint == null) // Constant Value
                        {
                            aftr = new AFTimeRange("*", "*");
                            logInput.setAFTimeRange(aftr);
                            Values = attribute.GetValues(aftr, dataPref, null);
                        }
                        else // PI Point - Time Matters!!
                        {
                            /* Summary: Attribute.GetValues - Important Call!  
                             * Parameter Int32 => DataPref
                             *          = 0 :  All Values returned
                             *          < 0 :  Evenly spaced values, including start and end
                             *          > 0 :  # of intervals, for each interval 5 points are given (first, last, high, low, and exceptional)
                             */
                            Values = attribute.GetValues(aftr, dataPref, null); // FULLY UNDERSTAND THIS !!! Important Call!!!!
                        }
                        break;
                    case "OSIsoft.AF.EventFrame.AFEventFrame":
                        AFEventFrame frame = (AFEventFrame)afobject;
                        logInput = new LogInput(MatlabName, frame.Name, frame.Attributes[AttributeName].Name, frame.GetPath(), aftr);
                        attribute = frame.Attributes[AttributeName];
                        logInput.setAFTimeRange(aftr);
                        AFValue val = attribute.GetValue(aftr);
                        Values = new AFValues() { val };
                        break;
                    case "OSIsoft.AF.PI.PIPoint":
                        PIPoint piPoint = (PIPoint)afobject;
                        string path = piPoint.GetPath();
                        logInput = new LogInput(MatlabName, "PI.Point", piPoint.Name, "PI.Point", aftr);
                        Values = piPoint.RecordedValues(aftr, AFBoundaryType.Interpolated, "", true, Int32.MaxValue);
                        break;

                }



                //Determine if AFTIME Absolute String
                isAbsoluteTimeString(start, end, logInput);

                logInput.setAttributeGetValueFormat(dataPref);
                logInput.setTimespaceFormat(dataFormat);

                ConvertAFValues.GetValuesArray(Values, false, out vals, out timestamps, out statuses, out baddata);
                try
                {
                    MatlabAccess.sendDataToMatlab(MatlabName, AFValuesToArray(vals));

                    if (Timestamp)
                        MatlabAccess.sendDataToMatlab(MatlabName + "Time", timestamps);
                }
                catch
                {
                    logInput.setServerDatabase(server_database);
                    LogSystem.addLogInput(server_database, logInput, addToListView);
                    throw new NullReferenceException();
                }

                logInput.setServerDatabase(server_database);
                LogSystem.addLogInput(server_database, logInput, addToListView);


            


        }

        // Organize Data into Arrays.
        /// <summary>
        ///  Move from object array into a double array. Turns enumerated values into doubles.
        /// </summary>
        /// <remarks> Called often after AFValues are given to method ConvertAFValues.GetValuesArray(..).</remarks>
        /// <param name="vals"> The array of object values. </param>
        /// <returns></returns>
        private static double[] AFValuesToArray(object[] vals)
            {

               double[] dblArray = new double[vals.Length];

                //DIGITAL ENUMERATION VALUES
                try
                {
                    if ((AFEnumerationValue)vals[0] != null)
                    {
                        for (Int32 i = 0; i < vals.Length; i++)
                        {
                            dblArray[i] = ((AFEnumerationValue)vals[i]).Value;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //For Normal integers
                    for (Int32 i = 0; i < vals.Length; i++)
                    {
                        try
                        { dblArray[i] = double.Parse(vals[i].ToString()); }
                        catch { }
                    }
                }
                return dblArray;
            }

        // Writing Data to the AFServer
        /// <summary>
        /// Writes to AF, and checks in the element.
        /// </summary>
        /// <param name="element"> AFElement being written to.</param>
        /// <param name="attribute"> AFAttribute being changed.</param>
        /// <param name="value"> The new value being imported.</param>
        public static void writeToAF(AFElement element, AFAttribute attribute, double value)
        {
            AFValue input = new AFValue(attribute, value, AFTime.Now);
            attribute.SetValue(input);
            element.CheckIn();
        }

    }

        //FROM Whitepaper: Using PI Data with Matlab
        class ConvertAFValues
        {
            public static void GetValuesArray(AFValues afvalues, out object[] values, out int baddata)
            {
                int size = afvalues.Count;
                values = new object[size];
                baddata = 0;
                int i = 0;
                foreach (AFValue afval in afvalues)
                {
                    values[i] = afval.Value;
                    if (afval.Status != AFValueStatus.Good)
                        baddata = baddata + 1;
                    i = i + 1;
                }
                return;
            }

            public static void GetValuesArray(AFValues afvalues, out double[] values, out double[] timestamps, out int[] statuses, out int baddata)
            {
                int size = afvalues.Count;
                values = new double[size];
                timestamps = new double[size];
                statuses = new int[size];
                baddata = 0;
                int i = 0;
                foreach (AFValue afval in afvalues)
                {
                    if ((AFEnumerationValue)afval.Value != null)
                        values[i] = ((AFEnumerationValue)afval.Value).Value;                 
                    else
                        double.TryParse(afval.Value.ToString(), out values[i]);

                    timestamps[i] = ((DateTime)afval.Timestamp).ToOADate() + 693960;
                    statuses[i] = (int)afval.Status;
                    if (afval.Status != AFValueStatus.Good)
                        baddata = baddata + 1;
                    i = i + 1;
                }
                return;
            }

            public static void GetValuesArray(AFValues afvalues, bool notInteger, out object[] values, out double[] timestamps, out int[] statuses, out int baddata)
            {
                int size = afvalues.Count;
                values = new object[size];
                timestamps = new double[size];
                statuses = new int[size];
                baddata = 0;
                int i = 0;
                foreach (AFValue afval in afvalues)
                {
                    values[i] = afval.Value;
                    timestamps[i] = ((DateTime)afval.Timestamp).ToOADate() + 693960;
                    statuses[i] = (int)afval.Status;
                    if (afval.Status != AFValueStatus.Good)
                        baddata = baddata + 1;
                    i = i + 1;
                }
                return;
            }
        }



 }
