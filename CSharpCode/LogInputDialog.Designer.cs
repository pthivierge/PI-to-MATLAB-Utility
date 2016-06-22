
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


﻿namespace MATLABfromCSharp
{
    partial class LogInputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInputDialog));
            this.tb_MatlabName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bn_checkMatlabName = new System.Windows.Forms.Button();
            this.bn_OkMatlabName = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.EndTimeLabel = new System.Windows.Forms.Label();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.startDTP = new OSIsoft.AF.UI.AFDateTimePickerCtrl();
            this.endDTP = new OSIsoft.AF.UI.AFDateTimePickerCtrl();
            this.SuspendLayout();
            // 
            // tb_MatlabName
            // 
            this.tb_MatlabName.Enabled = false;
            this.tb_MatlabName.Location = new System.Drawing.Point(139, 21);
            this.tb_MatlabName.Name = "tb_MatlabName";
            this.tb_MatlabName.Size = new System.Drawing.Size(205, 20);
            this.tb_MatlabName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Variable Name:";
            // 
            // bn_checkMatlabName
            // 
            this.bn_checkMatlabName.Location = new System.Drawing.Point(282, 143);
            this.bn_checkMatlabName.Name = "bn_checkMatlabName";
            this.bn_checkMatlabName.Size = new System.Drawing.Size(91, 35);
            this.bn_checkMatlabName.TabIndex = 11;
            this.bn_checkMatlabName.Text = "Cancel";
            this.bn_checkMatlabName.UseVisualStyleBackColor = true;
            this.bn_checkMatlabName.Click += new System.EventHandler(this.CancelEdit_Click);
            // 
            // bn_OkMatlabName
            // 
            this.bn_OkMatlabName.Location = new System.Drawing.Point(185, 143);
            this.bn_OkMatlabName.Name = "bn_OkMatlabName";
            this.bn_OkMatlabName.Size = new System.Drawing.Size(91, 35);
            this.bn_OkMatlabName.TabIndex = 12;
            this.bn_OkMatlabName.Text = "Ok";
            this.bn_OkMatlabName.UseVisualStyleBackColor = true;
            this.bn_OkMatlabName.Click += new System.EventHandler(this.OkEdit_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Calendar.png");
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Location = new System.Drawing.Point(25, 100);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.EndTimeLabel.TabIndex = 26;
            this.EndTimeLabel.Text = "End Time:";
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Location = new System.Drawing.Point(25, 64);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(58, 13);
            this.StartTimeLabel.TabIndex = 25;
            this.StartTimeLabel.Text = "Start Time:";
            // 
            // startDTP
            // 
            this.startDTP.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.startDTP.ImageIndex = 1;
            this.startDTP.Location = new System.Drawing.Point(139, 53);
            this.startDTP.Margin = new System.Windows.Forms.Padding(4);
            this.startDTP.MinimumSize = new System.Drawing.Size(0, 22);
            this.startDTP.Name = "startDTP";
            this.startDTP.Size = new System.Drawing.Size(205, 24);
            this.startDTP.TabIndex = 31;
            // 
            // endDTP
            // 
            this.endDTP.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.endDTP.ImageIndex = 1;
            this.endDTP.Location = new System.Drawing.Point(139, 89);
            this.endDTP.Margin = new System.Windows.Forms.Padding(4);
            this.endDTP.MinimumSize = new System.Drawing.Size(0, 22);
            this.endDTP.Name = "endDTP";
            this.endDTP.Size = new System.Drawing.Size(205, 24);
            this.endDTP.TabIndex = 32;
            // 
            // LogInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 196);
            this.Controls.Add(this.endDTP);
            this.Controls.Add(this.startDTP);
            this.Controls.Add(this.EndTimeLabel);
            this.Controls.Add(this.StartTimeLabel);
            this.Controls.Add(this.bn_OkMatlabName);
            this.Controls.Add(this.bn_checkMatlabName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_MatlabName);
            this.Name = "LogInputDialog";
            this.Text = "Log Input Editor";
            this.Load += new System.EventHandler(this.Dialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_MatlabName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bn_checkMatlabName;
        private System.Windows.Forms.Button bn_OkMatlabName;
        private System.Windows.Forms.Label EndTimeLabel;
        private System.Windows.Forms.Label StartTimeLabel;
        private System.Windows.Forms.ImageList imageList1;
        private OSIsoft.AF.UI.AFDateTimePickerCtrl startDTP;
        private OSIsoft.AF.UI.AFDateTimePickerCtrl endDTP;
    }
}