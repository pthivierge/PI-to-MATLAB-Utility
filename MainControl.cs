using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using System.Runtime.InteropServices;

using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.Time;
using OSIsoft.AF.UnitsOfMeasure;
using OSIsoft.AF.PI;
using OSIsoft.AF.EventFrame;

namespace MATLABfromCSharp
{
    public class MainControl
    {
        //Class Properties
        PISystem currentSystem;
        PIServer currentPIServer;
        AFDatabase currentAfdb;
        MainForm mainForm;
        string _curServer;
        string _curDatabase;
        bool checkedMatlab;

        /// <summary>
        /// Starts up the Desktop Matlab or attaches to COM-Enabled Matlab.
        /// to Com-Enable Matlab use [ enableservice('AutomationServer',true);]
        /// </summary>
        public MainControl()
        {
            // Matlab Startup and Connection to Desktop            
            MatlabAccess.MatlabStartup();
            checkedMatlab = false;
        }

        /// <summary>
        /// Give the MainControl access to the MainForm
        /// </summary>
        /// <param name="form">The Main Form</param>
        public void setMainForm(MainForm form)
        {
            mainForm = form;
        }

        //Matlab
        /// <summary>
        /// Checks to see if Matlab is still open and asks to Reload the logged data and reopens matlab.
        /// </summary>
        /// <param name="showDialog"> Whether to show a dialog with yes or no.</param>
        public void checkMatlab(bool showDialog)
        {
           if(showDialog)
           {
               bool hasMatlab = MatlabAccess.isMatlabOpen();
               if (!hasMatlab && !checkedMatlab)
               {
                   DialogResult result1 = MessageBox.Show(" Matlab has been closed. Do you want to reopen Matlab and load with Logged inputs? To start with an empty workspace, click No.", "Matlab has Closed", MessageBoxButtons.YesNoCancel);
                   if (result1 == DialogResult.Yes)
                   {
                       MatlabAccess.MatlabStartup();
                       LogSystem.SaveLog("temp.txt");
                       LogSystem.Clear();
                       importLog("temp.txt");
                       checkedMatlab = false;
                   }
                   else if(result1 == DialogResult.No)
                   {
                       MatlabAccess.MatlabStartup();
                   }
                   else
                       checkedMatlab = true;
               }
           }
           else
           {
               MatlabAccess.MatlabStartup();
               LogSystem.SaveLog("temp.txt");
               LogSystem.Clear();
               importLog("temp.txt");
               checkedMatlab = false;
           }

        }

        // AFDATABASE
        /// <summary>
        /// Returns the AFDatabase that the MainControl is using.
        /// </summary>
        /// <returns></returns>
        public AFDatabase getAFDatabase()
        {
            return currentAfdb;
        }
        /// <summary>
        /// Sets the AFDatabase that the MainControl will use.
        /// </summary>
        /// <param name="currentDatabase"> The name of the AFDatabase. </param>
        public void setAFDatabase(string currentDatabase)
        {
            if (currentAfdb == null || currentDatabase != currentAfdb.Name)
            {
                //Connect to Server; otherwise will be null.
                currentAfdb = currentSystem.Databases[currentDatabase];
            }
        }

        // Attributes
        /// <summary>
        ///  Uses the Element Path to access the Attributes.
        /// </summary>
        /// <remarks> The AFTreeView is implemented with ToolTipText is the path to the selected Element. </remarks>
        /// <param name="path"> The pathway to the Element</param>
        /// <returns> AFAttributes containing the Attributes of the selected Element. </returns>
        public AFAttributes getAttributes(string path)
        {
            mainForm.Status("Getting Attributes...");
            List<string> searchPaths = new List<string> { path };
            AFKeyedResults<string, AFElement> result = AFElement.FindElementsByPath(searchPaths, null);
            AFElement elem = result[path];
            AFAttributes atts = elem.Attributes;
            return atts;
        }

        //PIPoints
        /// <summary>
        /// Accesses the PIServer to get the PIPoints that are available.
        /// </summary>
        /// <param name="sys"> The current PISystem</param>
        /// <param name="serv"> The current PIServer</param>
        /// <returns></returns>
        public List<PIPoint> getPIPoints(PISystem sys, PIServer serv)
        {
            mainForm.Status("Getting PIPoints...");
            currentSystem = sys;
            currentPIServer = serv;
            List<PIPoint> list;
            try
            {
                List<string> query = new List<string>() { "*" };
                list = (List<PIPoint>)PIPoint.FindPIPoints(serv, query, null);
                return list;
            }
            catch
            {
                    mainForm.Status("ERROR: Unable to attach to " + serv.Name);
                    return null;
            }

        }

        // Export Data
        /// <summary>
        /// Get the Data from PIServer using AFSDK.
        /// </summary>
        /// <param name="point"> The name of the PIPoint.</param>
        /// <param name="server"> The PIServer</param>
        /// <param name="MatlabName"> The name of the variable to be used for Matlab.</param>
        /// <param name="start"> The time to start taking data from.</param>
        /// <param name="end">The time to stop taking data from.</param>
        /// <param name="edit"> true: Adds the log to the LogSystem (generally true)</param>
        /// <returns></returns>
        public void getPIData(string point, string server, string MatlabName, string start, string end, bool edit)
        {
            string name = MatlabAccess.modifyMatlabName(MatlabName);
            if (name == string.Empty)
                return;
            try
            {
                AFAccess.getPIData(name, server, point, start, end, edit);
                mainForm.Status("Data sent for " + point);
                return;
            }
            catch { checkMatlab(true); mainForm.Status("ERROR: Data not sent for  " + point); return; }

        }

        /// <summary>
        ///  Accesses the AFServer to get data.
        /// </summary>
        /// <param name="server_database"> The string of the server and database 'server'-'database'</param>
        /// <param name="attName"> Name of the Attribute.</param>
        /// <param name="MatlabName"> Variable name to be used in Matlab workspace.</param>
        /// <param name="searchPath"> The path to the Element.</param>
        /// <param name="start">The time at which data will start being imported from.</param>
        /// <param name="end">The time when data will stop being imported.</param>
        /// <param name="edit"> true: Adds the log input into the LogSystem (generally true)</param>
        /// <returns></returns>
        public void getAFData(string server_database, string attName, string MatlabName, string searchPath, string start, string end, bool edit)
        {
            MatlabName = MatlabAccess.modifyMatlabName(MatlabName);
            if (MatlabName == string.Empty)
                return;
            try
            {
                AFAccess.getAFData(server_database, attName, MatlabName, searchPath, start, end, edit);
                mainForm.Status("Data sent for " + attName);
                return;
            }
            catch { checkMatlab(true); mainForm.Status("ERROR: Data not sent for  " + attName); return; }

        }

        // Import Saved Log
        /// <summary>
        /// Imports a saved file into Matlab.
        /// </summary>
        /// <param name="path"> The path to the importe File.</param>
        /// <returns></returns>
        public string[] importLog(string path)
        {
            try
            {
                string[] lines = LogSystem.ImportLog(path);
                foreach (string line in lines)
                {
                    if (line != string.Empty)
                    {
                        string[] info = Regex.Split(line, @"=");
                        mainForm.Status("Importing: " + info[1] + " as " + info[0]);
                        
                        if (info.Length == 2)
                        {
                            _curServer = info[0];
                            _curDatabase = info[1];
                        }
                        else if (info.Length == 6) //Absolute Time
                        {
                            if (info[5] != string.Empty)
                                mainForm.dataPrefDialog.setupDataPreferences(info[5]);
                            string srv_db = "'" + _curServer + "'_'" + _curDatabase + "'";
                            if (info[2] == "PI.Point")
                                getPIData(info[1], _curServer, info[0], info[3], info[4], true);
                            else
                                getAFData(srv_db, info[1], info[0], info[2], info[3], info[4], true);
                        }
                        else // Dates
                        {
                            string[] time = Regex.Split(info[3], @"-");
                            if (info[4] != string.Empty)
                                mainForm.dataPrefDialog.setupDataPreferences(info[4]);
                            string srv_db = "'" + _curServer + "'_'" + _curDatabase + "'";
                            if (info[2] == "PI.Point")
                                getPIData(info[1], _curServer, info[0], time[0], time[1], true);
                            else
                            {
                                try
                                {
                                    List<string> paths = new List<string>() { info[2] };
                                    AFKeyedResults<string, AFEventFrame> frames = AFEventFrame.FindEventFramesByPath(paths, null);

                                    int i = frames.Count;
                                    AFEventFrame frame = frames[paths[0]];
                                    AFAccess.getEventFrameData(srv_db, info[1], info[0], frame, true);

                                }
                                catch
                                {
                                    getAFData(srv_db, info[1], info[0], info[2], time[0], time[1], true);
                                }
                            }

                        }
                    }
                }
            }
            catch
            {
                mainForm.Status("ERROR: Invalid import file. Please choose a different file.");
            }
            return new string[] { _curServer, _curDatabase };
        }

        // Import to AF
        /// <summary>
        ///  Gets value from Matlab and writes it to AF.
        /// </summary>
        /// <remarks> Will not write, if the Attribute is read-only. A Matlab Variable Name must be input.</remarks>
        /// <param name="path"> The path to the Element to search with.</param>
        /// <param name="workspaceVariableName">The variable name in Matlab being used.</param>
        /// <param name="AFName">The attribute name in AF being written to.</param>
        public void ImportToAF(string path, string workspaceVariableName, string AFName)
        {
            object val = null;
            double dbVal;

            //LOGIC: A variable name must be entered. 
            try
            {
                MatlabAccess.GetWorkspaceData(workspaceVariableName, "base", out val);
            }
            catch
            {
                mainForm.Status("Couldn't find the variable in the Matlab Workspace");
            }

            List<string> searchPaths = new List<string>() { path };
            AFKeyedResults<string, AFElement> results = AFElement.FindElementsByPath(searchPaths, null);
            AFElement Element = results[path];
            AFAttribute Attribute = Element.Attributes[AFName];
            double.TryParse(val.ToString(), out dbVal);
            try
            {
                AFAccess.writeToAF(Element, Attribute, dbVal);
            }
            catch
            {
                mainForm.Status("Cannot Write to this Attribute");
            }
        }

        // Save Logs
        /// <summary>
        /// Calls the LogSystem.Save method.
        /// </summary>
        /// <param name="filePath">The path to where the file will be written.</param>
        public void saveCurrentLog(string filePath)
        {
            LogSystem.SaveLog(filePath);
        }
        /// <summary>
        /// Not implemented. Future use: writes a matlab that imports the same data.
        /// </summary>
        /// <param name="filePath"> The path to where the file will be written.</param>
        public void saveMatlabLog(string filePath)
        {
            MatlabWriter writer = new MatlabWriter(filePath);
            writer.Save();
        }

        // Data Preferences
        /// <summary>
        ///  Passes the Data Preferences from the MainForm to the AFAccess.
        /// </summary>
        /// <param name="timestamp"> true: exports the timestamp to Matlab.</param>
        /// <param name="datapref"> Integer for Attribute.GetValues; 0(raw), negative(sampling), positive(profiled sampling)</param>
        /// <param name="format"> String representation of the Data Preferences. </param>
        public void currentDataPrefChanges(bool timestamp, int datapref, string format)
        {
            AFAccess.setDataPrefs(timestamp, datapref, format);
        }
    }
}
