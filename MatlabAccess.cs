using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MATLABfromCSharp
{
    public static class MatlabAccess
    {

        private static MLApp.MLApp matlab;

        // Start Matlab.
        /// <summary>
        /// Starts with Program, either connects to COM-Enabled Matlab or starts a Matlab File.
        /// </summary>
        /// <remarks> The call "enableservice('AutomationServer',true);" COM-enables Matlab and ensures it doesn't close with the program.</remarks>
        public static void MatlabStartup()
        {
            // Matlab Startup and Connection to Desktop            
            Type MatlabType = Type.GetTypeFromProgID("Matlab.Desktop.Application");
            try
            {
                //To make sure COM enabled for running Matlab
                //Connect to an open Matlab
                // Execute = enableservice('AutomationServer',true);

                matlab = (MLApp.MLApp)Marshal.GetActiveObject("Matlab.Desktop.Application");
            }
            catch (System.Runtime.InteropServices.COMException ex1)
            {
                try
                {
                    //Open Matlab program
                    matlab = (MLApp.MLApp)Activator.CreateInstance(MatlabType);

                    //IMPORTANT: Stops exiting from Matlab when program closes
                    matlab.Execute("enableservice('AutomationServer',true);");
                }
                catch (System.Runtime.InteropServices.COMException ex2)
                {
                    // Matlab not on computer.
                }
            }
        }

        // Matlab Status
        /// <summary>
        /// Checks to see if Matlab is Open. (if matlab is null).
        /// </summary>
        /// <returns> true if matlab is not closed.</returns>
        public static bool isMatlabOpen()
        {
            return matlab != null;
        }

        /// <summary>
        /// Checks the Matlab workspace for the variable name, so no data is Overwritten.
        /// </summary>
        /// <param name="name"> The variable name being checked for.</param>
        /// <returns></returns>
        public static bool isVariableInWorkspace(string name)
        {
            try
            {
                return !(matlab.GetVariable(name, "base") == null);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Unique Matlab Variable Name.
        /// <summary>
        /// Make UserInput Matlab-Friendly and Check for Unique Variable Name
        ///  1) UserInput-MatlabFriendly - Remove punctuation and numbers at start
        ///   2) Check Unique Variables - check Matlab workspace and Log System         
        /// </summary>
        /// <param name="varName">Either user-input name or attribute name</param>
        /// <returns>A Unique Variable Name not in the workspace or in the log.</returns>
        public static string modifyMatlabName(string varName)
        {

            string matName = Regex.Replace(varName, @"^[\d-]*\s*", ""); //Removes numbers from the front
            matName = Regex.Replace(matName, @"[^\w]", ""); //Remove Punctuation

            //Iteration of name, if name not unique or in workspace
            string newName = matName;
            int i = 1;
            while (LogSystem.isVariableInLogSystem(newName) | isVariableInWorkspace(newName))
            {
                newName = matName + i;
                i++;
            }

            return newName;
        }

        // Access the Matlab Workspace to Send/Remove/Get Data
        /// <summary>
        /// Send the array of doubles to Matlab.
        /// </summary>
        /// <param name="varName"> The Unique variable name.</param>
        /// <param name="dblInput"> Passed Array of Data.</param>
        /// <exception cref="System.RunTime.InteropServices.COMException"> Thrown when matlab is closed and no connection.</exception>
        public static void sendDataToMatlab(string varName, double[] dblInput)
        {
            try
            {
                matlab.PutWorkspaceData(varName, "base", dblInput); // varname, workspace, values
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                matlab = null;
            }
        }

        /// <summary>
        /// Send a array of strings to Matlab.
        /// </summary>
        /// <param name="varName"> The unique variable name.</param>
        /// <param name="strInput"> Passed Array of Data.</param>
        /// <exception cref="System.RunTime.InteropServices.COMException"> Thrown when matlab is closed and no connection.</exception>
        public static void sendDataToMatlab(string varName, string[] strInput)
        {
            try
            {
                matlab.PutWorkspaceData(varName, "base", strInput); // varname, workspace, values
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                matlab = null;
            }
        }

        /// <summary>
        /// Grab data from the workspace.
        /// </summary>
        /// <param name="name"> the name of the variable in the Matlab workspace.</param>
        /// <param name="workspace"> the workspace name, (generally "base")</param>
        /// <param name="val"> out the object from Matlab.</param>
        public static void GetWorkspaceData(string name, string workspace, out object val)
        {
            matlab.GetWorkspaceData(name, workspace, out val);  
        }

        /// <summary>
        /// Removes the variable from Matlab Workspace along with the timespace.
        /// </summary>
        /// <remarks> Only called when the log is editted.</remarks>
        /// <param name="varName">The name of the variable in Matlab.</param>
        public static void removeMatlabVariable(string varName)
        {
            try
            {
                matlab.Execute("clear " + varName + "Time");

                matlab.Execute("clear " + varName);
            }
            catch { }
        }

        //Execute Matlab Methods
        /// <summary>
        /// Plots data the time vs. the unique variable name. 
        /// Example of calling matlab methods from C#.
        /// </summary>
        /// <param name="varName"> unique variable name</param>
        public static void plotMatlabVariables(string varName)
        {
            matlab.Execute("plot(" + varName + "Time" + "," + varName + ");");
        }
    }
}
