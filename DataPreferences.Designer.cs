
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
    partial class DataPreferences
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.okDataButton = new System.Windows.Forms.Button();
            this.mTBIntervals = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reducedRadio = new System.Windows.Forms.RadioButton();
            this.IntervalRadio = new System.Windows.Forms.RadioButton();
            this.rawRadio = new System.Windows.Forms.RadioButton();
            this.checkTimestamps = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.okDataButton);
            this.panel1.Controls.Add(this.mTBIntervals);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.checkTimestamps);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 203);
            this.panel1.TabIndex = 1;
            // 
            // okDataButton
            // 
            this.okDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okDataButton.Location = new System.Drawing.Point(302, 170);
            this.okDataButton.Name = "okDataButton";
            this.okDataButton.Size = new System.Drawing.Size(97, 22);
            this.okDataButton.TabIndex = 20;
            this.okDataButton.Text = "OK";
            this.okDataButton.UseVisualStyleBackColor = true;
            this.okDataButton.Click += new System.EventHandler(this.okDataButton_Click);
            // 
            // mTBIntervals
            // 
            this.mTBIntervals.Location = new System.Drawing.Point(144, 140);
            this.mTBIntervals.Mask = "00000";
            this.mTBIntervals.Name = "mTBIntervals";
            this.mTBIntervals.Size = new System.Drawing.Size(100, 20);
            this.mTBIntervals.TabIndex = 19;
            this.mTBIntervals.ValidatingType = typeof(int);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reducedRadio);
            this.groupBox1.Controls.Add(this.IntervalRadio);
            this.groupBox1.Controls.Add(this.rawRadio);
            this.groupBox1.Location = new System.Drawing.Point(81, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 85);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // reducedRadio
            // 
            this.reducedRadio.AutoSize = true;
            this.reducedRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reducedRadio.Location = new System.Drawing.Point(12, 60);
            this.reducedRadio.Name = "reducedRadio";
            this.reducedRadio.Size = new System.Drawing.Size(106, 17);
            this.reducedRadio.TabIndex = 4;
            this.reducedRadio.TabStop = true;
            this.reducedRadio.Text = "Profiled Sampling";
            this.reducedRadio.UseVisualStyleBackColor = true;
            this.reducedRadio.CheckedChanged += new System.EventHandler(this.DataRadio_CheckedChanged);
            // 
            // IntervalRadio
            // 
            this.IntervalRadio.AutoSize = true;
            this.IntervalRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IntervalRadio.Location = new System.Drawing.Point(12, 36);
            this.IntervalRadio.Name = "IntervalRadio";
            this.IntervalRadio.Size = new System.Drawing.Size(68, 17);
            this.IntervalRadio.TabIndex = 3;
            this.IntervalRadio.TabStop = true;
            this.IntervalRadio.Text = "Sampling";
            this.IntervalRadio.UseVisualStyleBackColor = true;
            this.IntervalRadio.CheckedChanged += new System.EventHandler(this.DataRadio_CheckedChanged);
            // 
            // rawRadio
            // 
            this.rawRadio.AutoSize = true;
            this.rawRadio.Checked = true;
            this.rawRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rawRadio.Location = new System.Drawing.Point(12, 12);
            this.rawRadio.Name = "rawRadio";
            this.rawRadio.Size = new System.Drawing.Size(73, 17);
            this.rawRadio.TabIndex = 2;
            this.rawRadio.TabStop = true;
            this.rawRadio.Text = "Raw Data";
            this.rawRadio.UseVisualStyleBackColor = true;
            this.rawRadio.CheckedChanged += new System.EventHandler(this.DataRadio_CheckedChanged);
            // 
            // checkTimestamps
            // 
            this.checkTimestamps.AutoSize = true;
            this.checkTimestamps.Checked = true;
            this.checkTimestamps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkTimestamps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTimestamps.Location = new System.Drawing.Point(12, 174);
            this.checkTimestamps.Name = "checkTimestamps";
            this.checkTimestamps.Size = new System.Drawing.Size(120, 17);
            this.checkTimestamps.TabIndex = 12;
            this.checkTimestamps.Text = "Include Timestamps";
            this.checkTimestamps.UseVisualStyleBackColor = true;
            this.checkTimestamps.CheckedChanged += new System.EventHandler(this.checkTimestamps_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(220, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "(start, end, min, max, exceptional)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(221, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "5 points per Sampling Interval";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(222, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Evenly spaced interpolated data values";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(221, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "All of the Data points";
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Number of Values:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "PI Point Data:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 5, 270, 5);
            this.label1.Size = new System.Drawing.Size(375, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Data options";
            // 
            // DataPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 221);
            this.Controls.Add(this.panel1);
            this.Name = "DataPreferences";
            this.Text = "Advanced Data Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataPreferences_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton reducedRadio;
        private System.Windows.Forms.RadioButton IntervalRadio;
        private System.Windows.Forms.RadioButton rawRadio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkTimestamps;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mTBIntervals;
        private System.Windows.Forms.Button okDataButton;
    }
}