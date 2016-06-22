
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
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MATLABfromCSharp
{
    public partial class LogInputDialog : Form
    {
        private LogDialog parentForm;
        private LogInput logInput;

        /// <summary>
        /// Constructor of the LogInputDialog for Editting of LogInputs.
        /// </summary>
        /// <param name="parentForm"> The LogDialog that made this dialog</param>
        /// <param name="loginput"> The LogInput to be edited.</param>
        public LogInputDialog(LogDialog parentForm, LogInput loginput)
        {
            this.parentForm = parentForm;
            this.logInput = loginput;
            InitializeComponent();
            tb_MatlabName.Enabled = true;
        }

        /// <summary>
        /// Setup dialog with the information from the current log input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dialog_Load(object sender, EventArgs e)
        {
            tb_MatlabName.Text = logInput.getKeyVariableName();

            if (logInput.getAbsoluteTime() != null)
            {
                string[] absolute = logInput.getAbsoluteTime();
                startDTP.Text = absolute[0];
                endDTP.Text = absolute[1];
            }
            else
            {
                startDTP.Text = logInput.getTimeRange().StartTime.ToString();
                endDTP.Text = logInput.getTimeRange().EndTime.ToString();
            }
            string path = logInput.getPath();
            if(path.Contains("EventFrames")) //Cannot Edit Event Frames Time
            {
                startDTP.Enabled = false;
                endDTP.Enabled = false;
            }
            else
            {
                startDTP.Enabled = true;
                endDTP.Enabled = true;
            }

        }

        // Button Actions
        /// <summary>
        ///  User oks the changes and the new edits are passed with the previous logInput.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkEdit_Click(object sender, EventArgs e)
        {
            string name = tb_MatlabName.Text;
            string startTime = startDTP.Text;
            string endTime = endDTP.Text;

            parentForm.EditLog(name, startTime, endTime, logInput);
            tb_MatlabName.Enabled = false;
            this.Close();
        }

        /// <summary>
        ///  No Edit is made and the dialog closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelEdit_Click(object sender, EventArgs e)
        {
            tb_MatlabName.Enabled = false;
            this.Close();
        }

       

        
    }
}
