
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
using OSIsoft.AF.UI;

/**
 ----------------------------------------- PI To Matlab
 Author: Marissa Engle, Intern
 Based on WhitePaper: Using PI Data with Matlab
 Description: Academia tool for professors and students to import data from Matlab. Can be saved and imported from a textfile for distribution.
 ------------------------------------------------------
 **/

// TODO
/// Treeview Scalability not tested.
/// Clean up the Import.

namespace MATLABfromCSharp
{
    public partial class MainForm : Form
    {

        // Initialization
        public MainForm(MainControl main)
        {
            InitializeComponent();
            this.control = main;
            control.setMainForm(this);

            importing = false;
            isAdministrator = false;

            currentTreeSearch = "";
            currentSearchResults = new AFNamedCollectionList<AFElement>();

        }

        // Load and Closing
        private void PItoMatlabForm_Load(object sender, EventArgs e)
        {
            startDTP.Text = "*-2h";
            endDTP.Text = "*";

            // Log System Initialization
            logForm = new LogDialog(control,this);
           
            // Initialize AFViewControllers
            AFNamedCollectionList<AFAttribute> atts = new AFNamedCollectionList<AFAttribute>();
            AFNamedCollectionList<AFEventFrame> frames = new AFNamedCollectionList<AFEventFrame>();
            avcAttributes.AFSetObject(atts, null, null, null);
            avcAttributes.ContextMenuStrip = null;
            avcEventAttributes.AFSetObject(atts, null, null, null);
            avcEventFrames.AFSetObject(frames, null, null, null);

            //Initialize Data Preference Dialog
            dataPrefDialog = new DataPreferences(this);

           
            //Control AfTreeView1.ContextMenuSTrip
            afmenu = afTreeViewElements.ContextMenuStrip as AFMenu;
            if (afmenu != null)
            { 
                // Event raised when the menu control is opening.  
                afmenu.Opening += new CancelEventHandler(afmenu_Opening);
            }

            //Connect the Database Picker to the System Picker
            afDatabasePicker1.SystemPicker = afServerPicker;

            //Initialize Connection
            initializeAfServerPicker();

            Status("Loaded from the AF System " + _curServer);
        }
        private void PItoMatlabForm_Closing(object sender, FormClosingEventArgs e)
        {
            //Allow saving prior to exiting. Only allows .txt files save
            if (!LogSystem.isLogEmpty())
            {
                DialogResult result1 = MessageBox.Show("Do you want to save your work?", "Save your work before exiting", MessageBoxButtons.YesNoCancel);
                if (result1 == DialogResult.Yes)
                    saveExports();
                if (result1 == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Sets the string to the Status Strip at the bottom of the application.
        /// </summary>
        /// <param name="status">The string shown</param>
        public void Status(string status)
        {
            StatusStripStatus.Text = status;
        }

        /// <summary>
        ///  Multiple steps. 1) gets PIPoints fo the Server 
        ///                  2) Checks AFSecurity, for admin access and removes ability to import.
        ///                  3) Initializes Database and EventFrameFindCtrl.
        /// </summary>
        private void initializeAfServerPicker()
        {
            PISystem sys = afServerPicker.PISystem; //PI System != AF Server

            _curServer = sys.Name;
            PIServer serv = PIServer.FindPIServer(sys, sys.Name);

            List<PIPoint> piPoints = control.getPIPoints(sys, serv);
            avcPIPoints.AFSetObject(piPoints, afDatabasePicker1.AFDatabase, null, null);

            // Decides if you can import or not. Hides the UI. //TODO: Check
            AFSecurity security = sys.Security;
            if (security.HasAdmin)
            {
                isAdministrator = true;
                InformationDirectionPanel.Visible = true;
            }
            else
                InformationDirectionPanel.Visible = false;

            if (_curDatabase == null)
            {
                afDatabasePicker1.SetAFDatabase(sys.Databases[1], sys.Databases[1]);
                afEventFrameFindCtrl.Database = afDatabasePicker1.AFDatabase;
            }
        }
        

        #region Save Files

        /// <summary>
        /// Brings up a SaveFileDialog.
        /// </summary>
        /// <param name="filter">The file type filter</param>
        /// <returns> The save location</returns>
        private string SaveFileDialog(string filter)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save file";
            sfd.Filter = filter;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                return path;
            }
            return "";
        }

        /// <summary>
        /// Saves the Exports to a user-specified .txt File.
        /// </summary>
        private void saveExports()
        {
            string path = SaveFileDialog("|*.txt");
            if (path != string.Empty)
                control.saveCurrentLog(path);
        }

        /// <summary>
        ///  TODO: Not Finished. Writes the Matlab code that produces the same data calls.
        /// </summary>
        private void saveMatlab()
        {
            string path = SaveFileDialog("|*.m");
            if (path != string.Empty)
            {
                control.saveMatlabLog(path);
            }
        }

        /// <summary>
        /// Pass the file path from the MainForm to MainControl
        /// </summary>
        /// <param name="path"> The path to the file.</param>
        public void importSavedLog(string path)
        {
            string[] infos = control.importLog(path);
            _curDatabase = infos[1];
            _curServer = infos[0];         

        }

        #endregion

        #region Exporting to Matlab and Importing AF
        /// <summary>
        /// Export PI Data. Gets items from the AFViewControl of PIPoints.
        /// </summary>
        private void exportPIData()
        {
            if (avcPIPoints.ListHasSelectedItems)
            {
                object piPointList = avcPIPoints.AFSelection;
                try
                {
                    List<PIPoint> list = (List<PIPoint>)piPointList;
                    foreach (PIPoint point in list)
                    {
                        string strItem = point.ToString();
                        string server = afServerPicker.Text;
                        passPIDataRequest(server, strItem);
                    }
                }
                catch
                {
                    PIPoint point = (PIPoint)piPointList;
                    string strItem = point.ToString();
                    string server = afServerPicker.Text;
                    passPIDataRequest(server, strItem);
                }


            }

        }

        /// <summary>
        /// Export AF Data. Gets the Attribute from the AFViewControl of Element Attributes.
        /// </summary>
        private void exportAFData()
        {
            if(avcAttributes.ListHasSelectedItems)
            {
                string name = avcAttributes.AFSelection.ToString();
                if (name != null)
                {
                    string srv_db = "'" + _curServer + "'_'" + _curDatabase + "'";
                    control.getAFData(srv_db, name, getUserVariableName(name), _curPath, startDTP.Text, endDTP.Text, true);
                    if (!tb_MatlabName.ReadOnly)
                        tb_MatlabName.ReadOnly = true;

                }
            }

        }

        /// <summary>
        /// Import AF Data into the Asset Framework.
        /// </summary>
        private void importAFData()
        {
            try
            {
                if (tb_MatlabName.Text == string.Empty)
                {
                    tb_MatlabName.Focus();
                    return;
                }

                // string name = lb_Atts.SelectedItem as string;
                string name = avcAttributes.AFSelection.ToString();
                control.ImportToAF(_curPath, tb_MatlabName.Text, name);
            }
            catch
            {
                tb_MatlabName.Focus();
                return;
            }
        }

        /// <summary>
        /// Exports the Event Frame Data, using the AFViewControl to select an EventFrame and EventFrame Attribute.
        /// </summary>
        private void exportEventFrameData()
        {
            string name = avcEventAttributes.AFSelection.ToString();
            if (name != null)
            {
                string srv_db = "'" + _curServer + "'_'" + _curDatabase + "'";

                AFAccess.getEventFrameData(srv_db, name, getUserVariableName(name), (AFEventFrame)avcEventFrames.AFSelection, true);
            }
        }

        #endregion

        #region Access Interactions


        /// <summary>
        /// Sends a PIData request to MainControl. Uses AFSDK.
        /// </summary>
        /// <param name="server">The PISystem Server used.</param>
        /// <param name="pipoint"> The name of the PIPoint</param>
        private void passPIDataRequest(string server, string pipoint)
        {
            Status("Getting data for " + pipoint);
            control.getPIData(pipoint, server, getUserVariableName(pipoint), startDTP.Text, endDTP.Text, true);

        }

        /// <summary>
        /// Shows the list of Attributes and their values in the AFViewControl.
        /// </summary>
        /// <param name="atts">AFAttributes to be shown.</param>
        private void InitializeAttributeListBox(AFAttributes atts)
        {
            avcAttributes.AFSetObject(atts, afDatabasePicker1.AFDatabase, null, null);
        }

        /// <summary>
        ///  Checks Matlab Variable Name textbox for a variable name
        /// </summary>
        /// <param name="objectName"> The attribute name</param>
        /// <returns> Either the name of the attribute or the user-defined variable name</returns>
        public string getUserVariableName(string objectName)
        {
            string name = objectName;
            if (checkB_varNameMatlab.Checked)
            {
                objectName = tb_MatlabName.Text;
                checkB_varNameMatlab.Checked = false;
            }
            if (objectName == "")
            {
                return name;
            }
            return objectName;
        }

        #endregion

        #region AssetFramework Tab


            #region AFTreeView for the Elements

            /// <summary>
            ///  Expands the TreeView along the element path. Iterative process that stops when node is found.
            /// </summary>
            /// <param name="node"> The starting node or node being evaluated. </param>
            /// <param name="element"> The element that is being searched for. </param>
            private bool findTreeNode(TreeNode node, AFElement element)
            {
                string path = element.GetPath();
                if (path.Contains(node.Text) || node.Text == "Elements")
                {
                    node.Expand();
                    string[] split = Regex.Split(path, node.Text); //evaluate path string
                    if (split.Length > 1 && split[1] == string.Empty)
                    {
                        afTreeViewElements.AFSelect(element, element.Parent, path);
                        node.EnsureVisible();
                        node.ToolTipText = path; // If not set here is null, because of dummy node.
                        AFTreeViewNode_Selected(this, null);
                        return true;
                    }
                    else
                    {
                        foreach (TreeNode child in node.Nodes)
                        {
                            if (findTreeNode(child, element))
                                return true;
                        }
                    }
                }
                return false;
            }

            /// <summary>
            ///  If it is a new search, the elements that fit the criteria are collected and the first is selected.
            ///  Else it iterates through the collection of elements and expands to the node.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void bSearchElements_Click(object sender, EventArgs e)
            {

                currentTreeSearchTimes++;
                if (currentTreeSearch == tbElementSearchName.Text)
                {
                    if (currentSearchResults.Count == 0) //No search results
                    {
                        Status("Couldn't find Element Name");
                        return;
                    }
                    else if (currentTreeSearchTimes < currentSearchResults.Count) // iterate through.
                    {
                        findTreeNode(afTreeViewElements.Nodes[0], currentSearchResults[currentTreeSearchTimes]);
                    }
                    else //restart iteration through.
                    {
                        currentTreeSearchTimes = 0;
                        findTreeNode(afTreeViewElements.Nodes[0], currentSearchResults[currentTreeSearchTimes]);

                    }

                }
                else //Load Search Results
                {
                    currentTreeSearchTimes = 0;
                    currentTreeSearch = tbElementSearchName.Text;
                    AFDatabase afdb = control.getAFDatabase();
                    currentSearchResults = AFElement.FindElements(afdb, null, "*" + tbElementSearchName.Text + "*", AFSearchField.Name, true, AFSortField.Name, AFSortOrder.Ascending, Int32.MaxValue);

                    if (currentSearchResults.Count > 0)
                        findTreeNode(afTreeViewElements.Nodes[0], currentSearchResults[currentTreeSearchTimes]);
                }



            }

            /// <summary>
            ///  When a node is selected, the attribute box updates and the path is saved.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void AFTreeViewNode_Selected(object sender, TreeViewEventArgs e)
            {
                try
                {
                    string path = afTreeViewElements.SelectedNode.ToolTipText;
                    string elemName = afTreeViewElements.SelectedNode.Text;
                    _curPath = path;
                    if (elemName != "Elements")
                    {
                        InitializeAttributeListBox(control.getAttributes(_curPath));
                    }
                }
                catch { }
            }


            /// <summary>
            ///  Handles the afTreeView Menu Item calls, brings up the FindElements Dialog and EventFrame Dialog
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void afTreeViewElements_MenuItemClicked(object sender, MenuItemClickedEventArgs e)
            {
                try
                {
                    e.Handled = true;
                    bool persistUserData = true;
                    bool multiSelect = true;
                    string myPersistID = "MyPersistID";
                    if ((AFMenu.MenuCommand)e.ClickedItem.MergeIndex == AFMenu.MenuCommand.FindChildren)
                    {

                        AFNamedCollectionList<AFElement> elements = null;
                        DialogResult dr = AFOperations.FindElements(this, afDatabasePicker1.AFDatabase, out elements, multiSelect, persistUserData, myPersistID);

                        //Clear Search and Load new search
                        if (dr == DialogResult.OK)
                        {
                            currentSearchResults = elements;
                            currentTreeSearchTimes = 0;
                            currentTreeSearch = "";
                            tbElementSearchName.Text = "";

                            if (currentSearchResults.Count > 0)
                                findTreeNode(afTreeViewElements.Nodes[0], currentSearchResults[currentTreeSearchTimes]);
                        }


                    }
                    else if ((AFMenu.MenuCommand)e.ClickedItem.MergeIndex == AFMenu.MenuCommand.FindEventFrames)
                    {

                        AFNamedCollectionList<AFEventFrame> frames = null;
                        AFOperations.FindEventFrames(this, afDatabasePicker1.AFDatabase, out frames, true, true, "PersistID");

                        if (frames.Count > 0)
                        {
                            avcEventFrames.AFSetObject(frames, afDatabasePicker1.AFDatabase, null, null);
                          
                            avcEventFrames.AFSelection = frames[0];
                            object selected = avcEventFrames.AFSelection;
                            avcEventFrames_ItemSelected(this, null);


                        }
                    }
                }
                catch { }
            }

            /// <summary>
            /// Event raised  the menu control is opening.  
            ///  Handles the opening of the AFTreeView ContextMenuStrip to override visibility of menu items.
            ///  TODO: could vary between admin and non-admin users.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void afmenu_Opening(object sender, CancelEventArgs e)
            {
                // Get the AF menu.  
                AFMenu afmenu = sender as AFMenu;
                if (afmenu != null)
                {
                    bool visible = true;
                    foreach (ToolStripItem item in afmenu.Items)
                    {
                        if (visible)
                        {
                            ToolStripSeparator separatorItem = item as ToolStripSeparator;
                            if (separatorItem != null)
                                visible = false;
                            ToolStripMenuItem menu = item as ToolStripMenuItem;
                            if (menu != null)
                            {
                                foreach (ToolStripItem mItem in menu.DropDownItems)
                                {
                                    if (mItem.Text != "Chi&ldren..." && mItem.Text != "Event &Frames...")
                                    {
                                        mItem.Visible = false;
                                    }
                                    else
                                    {
                                        mItem.Visible = true;
                                        // mItem.Click += new EventHandler(afmenu_clicked);
                                    }
                                }
                            }

                        }
                        item.Visible = visible;

                    }
                }
            }

            #endregion



        #endregion

        #region EventFrames Tab

        /// <summary>
        ///  Updates the Event Attibutes AFViewControl and set the Date Time to that of the EventFrame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void avcEventFrames_ItemSelected(object sender, SelectionChangeEventArgs e)
        {
            object afObject = avcEventFrames.AFSelection;
            try
            {
                AFEventFrame frame = (AFEventFrame)afObject;
                avcEventAttributes.AFSetObject(frame.Attributes, afDatabasePicker1.AFDatabase, null, null);
                startDTP.Text = frame.StartTime.ToString();
                endDTP.Text = frame.EndTime.ToString();
            }
            catch
            {

            }
        }

        /// <summary>
        ///  Uses the AFEventFrameFindControl, but overrides the EventFrameBrowser to FindEventFrames (AFOperations).
        ///  Opens dialog to select eventframes to be shown in the AFViewControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void afEventFrameFindCtrl_DialogButtonPressing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            AFNamedCollectionList<AFEventFrame> frames = null;

            bool b = true;
            
        //    afEventFrameFindCtrl.FindEventFrame(afDatabasePicker1.AFDatabase, true, ref b);
         //   afEventFrameFindCtrl
                    

          // AFEventFrame frame = afEventFrameFindCtrl.FindEventFrame(afDatabasePicker1.AFDatabase, false, ref b);
            
          
            
            AFOperations.FindEventFrames(this, afDatabasePicker1.AFDatabase, out frames, true, true, "PersistID");

            if (frames.Count > 0)
            {
                avcEventFrames.AFSetObject(frames, afDatabasePicker1.AFDatabase, null, null);

                avcEventFrames.AFSelection = frames[0];
                object selected = avcEventFrames.AFSelection;
                avcEventFrames_ItemSelected(this, null);


            }
        }

        /// <summary>
        /// The FindEventFrameCriteria Dialog updates the event frame to one EventFrame, which is shown in the AFViewController
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void afEventFrameFindCtrl_AFEventFrameUpdated(object sender, CancelEventArgs e)
        {
            //GET Results from FindDialog

            AFEventFrame frame = afEventFrameFindCtrl.AFEventFrame;
            avcEventFrames.AFSelection = frame;
            if (avcEventFrames.AFSelection == null)
            {
                AFNamedCollectionList<AFEventFrame> frames = new AFNamedCollectionList<AFEventFrame>() { frame };
                avcEventFrames.AFSetObject(frames, afDatabasePicker1.AFDatabase, null, null);

                avcEventFrames.AFSelection = frames[0];
                object selected = avcEventFrames.AFSelection;
                avcEventFrames_ItemSelected(this, null);
            }

        }

        /// <summary>
        /// Starts a simple Name search using the text from the textbox.
        /// Updates the AFViewControl of elements that match the criteria.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bEFSearch_Click(object sender, EventArgs e)
        {
            string searchEF = tbEventFrameSearch.Text;
            AFNamedCollectionList<AFEventFrame> frames = null;
            frames = AFEventFrame.FindEventFrames(afDatabasePicker1.AFDatabase, null, "*" + searchEF + "*", AFSearchField.Name, true, AFSortField.Name, AFSortOrder.Ascending, 0, Int32.MaxValue);

            if (frames.Count > 0)
            {
                avcEventFrames.AFSetObject(frames, afDatabasePicker1.AFDatabase, null, null);

                avcEventFrames.AFSelection = frames[0];
                object selected = avcEventFrames.AFSelection;
                avcEventFrames_ItemSelected(this, null);
            }
        }


        #endregion

        #region PIPoint Tab
         // There is no necessary handles of a PIPoint ListItem being chosen.
        #endregion

        #region CommonFormActions

        //MainForm Buttons Clicked

        /// <summary>
        /// Shows the Data Preferences Dialog for user changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdvancedDataClick(object sender, EventArgs e)
        {
            if (dataPrefDialog.Visible == true)
            {
                dataPrefDialog.Close();
            }
            else
            {
                dataPrefDialog.Show();
                dataPrefDialog.Focus();
            }

        }

        /// <summary>
        ///  Passes the Data Preferences changed to the Main Control.
        /// </summary>
        /// <param name="ts"> true: provides timestamps along with data</param>
        /// <param name="datapref"> Based on the GetValues, 0(raw), negative(sampling), positive(profiled sampling)</param>
        /// <param name="format"> string version of passed data.</param>
        public void passDataPrefChanges(bool ts, int datapref, string format)
        {
            control.currentDataPrefChanges(ts, datapref, format);
        }

        /// <summary>
        /// Evaluates based on the tabPage, which export method to call.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportToMatlab_Click(object sender, EventArgs e)
        {
            int tabInt = tabControl1.SelectedIndex;
            if (tabInt == 2)
            {
                 exportPIData();
            }
            else if (tabInt == 1)
            {
                exportEventFrameData();
            }

            if (tabInt == 0)
            {
                if (importing)
                {
                    importAFData();
                }
                else
                {
                    exportAFData();
                }

            }
        }

        //MENU ITEMS
        public void ImportFileMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Find Import File";
            ofd.Filter = "|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Status("Importing from " + ofd.FileName);
                string filename = ofd.SafeFileName; //don't know if we want multiple file download, should work
                string path = ofd.FileName;
                importSavedLog(path);
                Status("Finished Importing");
            }
        }
        public void SaveFileMenuItem_Click(object sender, EventArgs e)
        {
            saveExports();
        }
        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logForm.Show();
        }
        private void openMatlabMenuItem_Click(object sender, EventArgs e)
        {
            control.checkMatlab(false);
        }

        //NOT IMPLEMENTED
        private void saveMatlabMenuItem_Click(object sender, EventArgs e)
        {
            saveMatlab();
        }

        //View Changes 
        private void MatlabNameCheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            if (check.Checked)
                tb_MatlabName.ReadOnly = false;            
            else
                tb_MatlabName.ReadOnly = true;

        }
        private void tb_MatlabName_Click(object sender, EventArgs e)
        {
            tb_MatlabName.ReadOnly = false;
            checkB_varNameMatlab.Checked = true;

        }
        private void tb_MatlabName_Leave(object sender, EventArgs e)
        {
            if (!importing)
            {
                if (tb_MatlabName.Text == string.Empty)
                {
                    tb_MatlabName.ReadOnly = true;
                }
            }


        }

        private void TabIndex_Changed(object sender, EventArgs e)
        {
            int index = tabControl1.SelectedIndex;
            switch (index)
            {
                case 0:
                    if (isAdministrator)
                    {
                        InformationDirectionPanel.Visible = true;
                        if (radioExport.Checked)
                            radioInformationDirectionChanged(radioExport, null);
                        else
                            radioInformationDirectionChanged(radioImport, null);
                    }
                    else
                    {
                        bn_Export.Text = "Export to Matlab";
                        radioInformationDirectionChanged(radioExport, null);
                    }
                    break;
                case 1:
                    bn_Export.Text = "Export to Matlab";
                    radioInformationDirectionChanged(radioExport, null);
                    InformationDirectionPanel.Visible = false;
                    break;
                case 2:
                    bn_Export.Text = "Export to Matlab";
                    radioInformationDirectionChanged(radioExport, null);
                    InformationDirectionPanel.Visible = false;
                    break;
            }
        }

        // Import vs. Export
        private void radioInformationDirectionChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Text == "Export to Matlab")
            {
                bn_Export.Text = "Export to Matlab";
                importing = false;
                checkB_varNameMatlab.Enabled = true;
                checkB_varNameMatlab.Visible = true;
            }
            else
            {
                bn_Export.Text = "Import to AF";
                importing = true;
                checkB_varNameMatlab.Enabled = false;
                checkB_varNameMatlab.Visible = false;
                tb_MatlabName.ReadOnly = false;
            }
        }

        //KeyBoard
        private void EnterPressed(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {
                if ((TextBox)sender == tbElementSearchName)
                    bSearchElements_Click(sender, null);
                else if ((TextBox)sender == tb_MatlabName)
                    ExportToMatlab_Click(sender, null);
            }
        }

        //Server Connection Changes
        private void afServerPicker_ConnectionChange(object sender, SelectionChangeEventArgs e)
        {
            if (afServerPicker.Text != _curServer)
            {
                initializeAfServerPicker();
            }
        }

        /// <summary>
        /// Updates the current AFDatabase and the AFTreeView to match.
        /// Clears the AFViewControl of the Event Frames. (Not sure if we want to do this).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void afDatabasePicker1_SelectionChange(object sender, SelectionChangeEventArgs e)
        {
            try
            {
                string db = afDatabasePicker1.Text;

                control.setAFDatabase(db);
                AFDatabase afdb = control.getAFDatabase();

                afTreeViewElements.SetAFRoot(afdb.Elements, null, "");
                afTreeViewElements.ShowElements = true;
                afTreeViewElements.Nodes[0].Expand();
                _curDatabase = db;

                afEventFrameFindCtrl.Database = afDatabasePicker1.AFDatabase;
                avcEventFrames.AFSetObject(new AFNamedCollectionList<AFEventFrame>(), afdb, null, null);//Clear event frames if database switched.

                afTreeViewElements.Focus();
            }
            catch { }

        }

        //Main Form
        /// <summary>
        /// Assures that the secondary Forms are hidden when the Main Form is focused on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainHasFocus(object sender, EventArgs e)
        {
            if (dataPrefDialog != null)
                dataPrefDialog.Hide();
            logForm.Hide();
        }

        #endregion


        // Class Properties
        public DataPreferences dataPrefDialog;

        private string _curServer, _curDatabase, _curPath; //Track current states        
        private LogDialog logForm; //The Log
        private ListView logFormView;

        private AFNamedCollectionList<AFElement> currentSearchResults; //Track Search of AFTreeView
        private string currentTreeSearch;
        private int currentTreeSearchTimes;

        private MainControl control; //Main Control - to pass along requests and settings
        private AFMenu afmenu; // Menu in the AFTreeView

        private bool isAdministrator; //If administrator access is given
        private bool importing;//If data is being imported.




    }
    
}
