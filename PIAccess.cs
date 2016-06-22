
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


﻿using System;
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

namespace MATLABfromCSharp
{
    public static class PIAccess
    {
        private static AFTimeRange checkAFTimeRange(string start, string end)
        {
            AFTimeRange aftr;
            aftr = new AFTimeRange(start, end);
            return aftr;
        }
        private static bool isRelativeTimeString(string start, string end, LogInput logInput)
        {
            //Determine if AFTIME Relative String
            DateTime DTstart, DTend;
            string[] stringTime;
            if (!DateTime.TryParse(start, out DTstart) || !DateTime.TryParse(end, out DTend))
            {
                stringTime = new string[] { start, end };
                logInput.setRelativeTime(stringTime);
                return true;
            }
            return false;
        }

        //TODO add time reliance to getPIData
        public static  void getPIData(string MatlabName, string server, string point, string start, string end)
        {
            LogInput logInput; //LOG DATA

            AFTimeRange aftr; //TIMERANGE
            try { aftr = checkAFTimeRange(start, end); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            PISDK.PISDKClass _pisdk = new PISDK.PISDKClass();
            PISDK.PIPoint pt = _pisdk.Servers[server].PIPoints[point]; // Add the correct SERVER NAME & PI Points
            PISDK.PIValues values = pt.Data.RecordedValues(start, end,
            PISDK.BoundaryTypeConstants.btAuto, "", PISDK.FilteredViewConstants.fvRemoveFiltered, null); //Get Values

            logInput = new LogInput(MatlabName, "PI.Point", point, "PI.Point", aftr);
            isRelativeTimeString(start, end, logInput);

            double[] timeStamp = new double[values.Count];
            int i= 0;
            foreach(PISDK.PIValue val in values)
            {
                DateTime UTCTime = val.TimeStamp.LocalDate;
                timeStamp[i] = UTCTime.ToOADate() + 693960;
                i++;
            }

            logInput.setAttributeGetValueFormat(0);
            logInput.setTimespaceFormat("ts0");

            string server_database = "'" + server + "'-'PI.Point'";
            logInput.setServerDatabase(server_database);
            LogSystem.addLogInput(server_database, logInput, true);

            MatlabAccess.sendDataToMatlab(MatlabName, PIValuesToArray(values)); //Export 
            MatlabAccess.sendDataToMatlab(MatlabName + "Time", timeStamp);
        }

        // Modified From WHITEPAPER ConvertAFValues
        private static double[] PIValuesToArray(PISDK.PIValues piValues)
        {
            double[] dblArray = new double[piValues.Count];

            for (Int32 i = 0; i < piValues.Count; i++)
            {
                try
                { dblArray[i] = double.Parse(piValues[i + 1].Value.ToString()); }
                catch { }

            }

            return dblArray;
        }

        public static List<string> getPIpoints(string server)
        {
            PISDK.PISDKClass _pisdk = new PISDK.PISDKClass();

            PISDK.PIPoints pts = _pisdk.Servers[server].PIPoints;

            List<string> PIpoints = new List<string>();
            foreach (PISDK.PIPoint pt in pts)
            {
                PIpoints.Add(pt.Name);
            }
            return PIpoints;
        }




    }
}
