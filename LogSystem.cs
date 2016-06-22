
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
using System.Text.RegularExpressions;
using OSIsoft.AF.Time;
using OSIsoft.AF;

namespace MATLABfromCSharp
{
    class LogSystem
    {
       //List of server_databases with list of variable names  
       static Dictionary<string, List<string>> servers_databases = new Dictionary<string,List<string>>(); //"server_database" Key
       //Log of unique variables in the form of LogInput class
       static Dictionary<string, LogInput> logs = new Dictionary<string, LogInput>();
       //Listview from the Mainform     
       static ListView Log;


        // LogSystem Add/Remove/Clear/Get
        /// <summary>
       /// Clear the LogSystem, includes the listView.
       /// </summary>
        public static void Clear()
       {
           servers_databases.Clear();
           logs.Clear();
           Log.Items.Clear();
       }
        /// <summary>
        /// Gets the LogInput based on the unique variable name.
        /// </summary>
        /// <param name="keyVariableName"> The unique variable name.</param>
        /// <returns></returns>
        public static LogInput getLogInput(string keyVariableName)
        { 
            LogInput logInput;
            logs.TryGetValue(keyVariableName, out logInput);
            return logInput;
        }
        /// <summary>
        /// Log the new export of Matlab data
        /// Steps: 1) Check for the Server_database key
        ///        2) Add variable name to server list and logs.
        ///        3) Add to the ListView - doesn't add to ListView when editting.
        /// </summary>
        /// <param name="keySrv_Db"> The string representing the server and database</param>
        /// <param name="logInput"> The LogInput entry.</param>
        /// <param name="addToListView"> true: adds a ListViewItem to the ListView (generally true, false when editting)</param>
        public static void addLogInput(string keySrv_Db, LogInput logInput, bool addToListView)
        {
           if (!isServer_DatabasesInLogSystem(keySrv_Db))
               servers_databases.Add(keySrv_Db, new List<string>() { logInput.getKeyVariableName() });           
           else
               servers_databases[keySrv_Db].Add(logInput.getKeyVariableName());              
                         
           logs.Add(logInput.getKeyVariableName(), logInput);

           if(addToListView)
                Log.Items.Add(logInput.ToListViewItem());
        }
        /// <summary>
        ///  Removes a loginput connected to the KeyVariableName and removes it from the server_database.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="srv_db"></param>
        public static void removeLogInput(string keyName, string srv_db)
        {
            servers_databases[srv_db].Remove(keyName);
            logs.Remove(keyName);
        }

        // Server Database key parsing.
        /// <summary>
        /// Parses the Server Database string representation into the server and database names.
        /// </summary>
        /// <param name="srv_db"> String representation of server and database.</param>
        /// <returns> Array containing the server and the database strings.</returns>
        public static string[] parseServerDatabaseKey(string srv_db)
        {
            return Regex.Split(srv_db, @"'");
        }

        // Saving and Importing the Log
        /// <summary>
        /// Writes the Log to a *.txt File.
        /// Writing Style: Server = Database
        ///              : KeyVariableName = Attribute = PathwayToElement = TimeRange    
        /// </summary>
        /// <param name="Filename">The path to the file location.</param>
        public static void SaveLog(string Filename)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Filename))
            {
                foreach(KeyValuePair <string, List<string>> entry in servers_databases)
                {
                    string[] Server_Database = parseServerDatabaseKey(entry.Key); // {"",ServerName,-, DatabaseName,""}
                    file.Write(Server_Database[1] + "=" + Server_Database[3] + "\r\n");
                    List<string> varnames = entry.Value;
                    foreach(string name in varnames)
                    {
                       LogInput inp;
                       logs.TryGetValue(name, out inp);
                       file.Write("\r\r" + inp.ToString() + "\r\n");
                    }
                }               
            }
        }
        /// <summary>
        /// Reads in the saved Log from a *.txt File.
        /// </summary>
        /// <param name="FileName">The location of the file.</param>
        /// <returns> Array of strings for each line.</returns>
        public static string[] ImportLog(string FileName)
        {
            return System.IO.File.ReadAllLines(FileName);
        }

        // Log Status Calls
        /// <summary>
        /// Returns whether not the Log is empty.
        /// </summary>
        /// <returns> true: if empty</returns>
        public static bool isLogEmpty()
        {
            return Log.Items.Count == 0;
        }
        /// <summary>
        /// Checks the log for the variable name.
        /// </summary>
        /// <param name="varname"> the unique variable name.</param>
        /// <returns> true: if logs has the name already.</returns>
        public static bool isVariableInLogSystem(string varname)
        {
            return logs.ContainsKey(varname);
        }
        /// <summary>
        /// Check that the server_databae already exists.
        /// </summary>
        /// <param name="srv_db_name"> The string representign the server and database.</param>
        /// <returns></returns>
        private static bool isServer_DatabasesInLogSystem(string srv_db_name)
        {
            return servers_databases.ContainsKey(srv_db_name);
        }

        // LogView
        /// <summary>
        /// Passes the LogView from the LogDialog to the LogSystem.
        /// </summary>
        /// <param name="lv"> The Listview to display the LogSystem.</param>
        public static void addView(ListView lv)
        {
            Log = lv;
        }
    }

    public class LogInput
    {
        private string keyVariableName, element, attribute, elementPath;
        private string Server_Database;
        private AFTimeRange Range;
        private string[] absoluteTime;

        private string timespaceFormat;
        private int attributeGetValueFormat;

        /// <summary>
        /// Constructor of a Log Input
        /// </summary>
        /// <param name="key"> unique variable name</param>
        /// <param name="element"> element name</param>
        /// <param name="attribute"> attribute name</param>
        /// <param name="path"> element path</param>
        /// <param name="timeRange"> AFTimeRange</param>
        public LogInput(string key, string element, string attribute, string path, AFTimeRange timeRange)
        {
            keyVariableName = key;
            this.element = element;
            this.attribute = attribute;
            elementPath = path;
            Range = timeRange;
            timespaceFormat = "ts";
        }

        /// <summary>
        /// Creates the ListViewItem for the ListView
        /// </summary>
        /// <returns> ListViewItem representation of the LogInput.</returns>
        public ListViewItem ToListViewItem()
        {
            ListViewItem item = new ListViewItem(keyVariableName);
            item.SubItems.Add(element);
            item.SubItems.Add(attribute);
            if (absoluteTime == null)
                item.SubItems.Add(Range.ToString("g"));    
            else
                item.SubItems.Add(AbsoluteTimeToString());    
            return item;
        }
       
        /// <summary>
        /// Creates the string for the saving into the .txt file.
        /// </summary>
        /// <returns> String representation of the logInput.</returns>
        public override string ToString()
        {
            string fileWrite;
            if(absoluteTime == null)
                fileWrite = keyVariableName + "=" + attribute + "=" + elementPath + "=" + Range.ToString() + "=" + timeSpaceFormatString();
            else
                fileWrite = keyVariableName + "=" + attribute + "=" + elementPath + "=" + AbsoluteTimeToString() + "=" + timeSpaceFormatString();
            return fileWrite;
        }


        // Accessors
        public string getKeyVariableName()
        {
            return keyVariableName;
        }
        public string getPath()
        {
            return elementPath;
        }
        public string getElement()
        {
            return element;
        }
        public string getAttribute()
        {
            return attribute;
        }
        public AFTimeRange getTimeRange()
        {
            return Range;
        }

        // ServerDatabase set,get
        public void setServerDatabase(string name)
        {
            Server_Database = name;
        }
        public string getServerDatabase()
        {
            return Server_Database;
        }
        public void setAFTimeRange(AFTimeRange aftr)
        {
            this.Range = aftr;
        }
    
        // AbsoluteTime
        public void setAbsoluteTime(string[] absolute)
        {
            absoluteTime = absolute;
        }
        public string[] getAbsoluteTime()
        {
            return absoluteTime;
        }
        public string AbsoluteTimeToString()
        {
            return "" + absoluteTime[0] + " = " + absoluteTime[1];
        }

        // Data Preferences
        public void setTimespaceFormat(string format)
        {
            timespaceFormat = format;
        }
        public void setAttributeGetValueFormat(int n)
        {
            attributeGetValueFormat = n;
        }
        public string timeSpaceFormatString()
        {
            return "" + timespaceFormat + "";
        }
    }

    
}
