using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using OSIsoft.AF.Time;

namespace MATLABfromCSharp
{
    public partial class LogDialog : Form
    {
        MainControl control;
        MainForm form;

        /// <summary>
        /// Constructor of the Log Dialog.
        /// </summary>
        /// <param name="control"> The Main Control.</param>
        /// <param name="form"> The Main Form.</param>
        public LogDialog(MainControl control, MainForm form)
        {
            InitializeComponent();
            lv_LogDialog.View = View.Details;
            LogSystem.addView(lv_LogDialog);
            this.control = control;
            this.form = form;
        }

        private void LogDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        /// <summary>
        ///  Resulting Action of editting the List View.
        ///  1) Edit the List Item
        ///  2) Re-log the item 
        ///  3) Edit the Matlab workspace.
        /// </summary>
        /// <param name="name"> The new variable name. (or the same)</param>
        /// <param name="start"> The new start time. (or the same)</param>
        /// <param name="end"> The new end time. (or the same)</param>
        /// <param name="previous"></param>
        public void EditLog(string name, string start, string end, LogInput previous)
        {
            MatlabAccess.removeMatlabVariable(previous.getKeyVariableName()); 
            if(previous.getKeyVariableName() != name)
                name = MatlabAccess.modifyMatlabName(name);
            if (name == string.Empty)
                name = previous.getKeyVariableName();
            string attName = previous.getAttribute();
            string path = previous.getPath();
            string elem = previous.getElement();

            //EDIT LIST VIEW
            if (AFAccess.isAbsoluteTimeString(start, end, previous))
            {
                lv_LogDialog.SelectedItems[0].SubItems[3].Text = start + " = " + end;
                lv_LogDialog.SelectedItems[0].Text = name;
            }
            else
            {
                AFTimeRange range = new AFTimeRange(start, end);
                lv_LogDialog.SelectedItems[0].SubItems[3].Text = range.ToString();
                lv_LogDialog.SelectedItems[0].Text = name;
            }

           
            //EDIT ACTUAL LOG 
            LogSystem.removeLogInput(previous.getKeyVariableName(), previous.getServerDatabase());

            //Workspace Edit - remove variable, getNewData
            if (path == "PI.Point")
            {
                string[] info = Regex.Split(previous.getServerDatabase(), "'");
                control.getPIData(attName, info[1], name, start, end,false);
            }
            else
                control.getAFData(previous.getServerDatabase(), attName, name, path, start, end, false);

            
        }

        /// <summary>
        ///  Removes the log Input from the LogSystem and the list view.
        /// </summary>
        /// <param name="selected"> Unique variable name of list View Item.</param>
        public void DeleteListItem(string selected)
        {
            LogInput logInput = LogSystem.getLogInput(selected);
            LogSystem.removeLogInput(selected, logInput.getServerDatabase());
        }

        /// <summary>
        ///  Opens a LogInput Editor Dialog. Can change the times and the variable name.
        /// </summary>
        /// <param name="selected"> The unique variable name of the seleced List View item.</param>
        private void EditDialog(string selected)
        {
            LogInput log = LogSystem.getLogInput(selected);
            LogInputDialog lid = new LogInputDialog(this, log);
            lid.Show();
        }


        // Menu Items
        private void SaveFileMenuItem_Click(object sender, EventArgs e)
        {
            form.SaveFileMenuItem_Click(sender, e);
        }
        private void ImportFileMenuItem_Click(object sender, EventArgs e)
        {
            form.ImportFileMenuItem_Click(sender, e);
        }
        private void deleteAllLogInputsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!LogSystem.isLogEmpty())
            {
                DialogResult result1 = MessageBox.Show("Delete all Logged Values", "Are you sure you want to delete all logged exports?", MessageBoxButtons.OKCancel);
                if (result1 == DialogResult.OK)
                {
                    foreach (ListViewItem item in lv_LogDialog.Items)
                    {
                        string selected = item.Text;
                        DeleteListItem(selected);
                        item.Remove();
                    }
                }
            }



        }

        // Buttons
        private void Delete_Click(object sender, EventArgs e)
        {
            if (lv_LogDialog.SelectedItems.Count > 0)
            {
                string selected = lv_LogDialog.SelectedItems[0].Text;
                DeleteListItem(selected);
                lv_LogDialog.SelectedItems[0].Remove();
            }
        }
        private void OK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            if (lv_LogDialog.SelectedItems.Count > 0)
            {
                string selected = lv_LogDialog.SelectedItems[0].Text;
                EditDialog(selected);
            }
        }

        // List View Actions
        private void ItemDoubleClick(object sender, EventArgs e)
        {
            ListView list = (ListView)sender;
            string selected = list.SelectedItems[0].Text;
            EditDialog(selected);
        }
        private void LogKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lv_LogDialog.SelectedItems.Count > 0)
                {
                    ListView list = (ListView)sender;
                    string selected = list.SelectedItems[0].Text;
                    DeleteListItem(selected);
                    lv_LogDialog.SelectedItems[0].Remove();
                }
                //removeMatlabVariable(selected); // ??? do we want to do this
            }
        }














       
    }
}
