namespace MATLABfromCSharp
{
    partial class LogDialog
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
            this.lv_LogDialog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllLogInputsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_LogDialog
            // 
            this.lv_LogDialog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv_LogDialog.FullRowSelect = true;
            this.lv_LogDialog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_LogDialog.Location = new System.Drawing.Point(12, 27);
            this.lv_LogDialog.MultiSelect = false;
            this.lv_LogDialog.Name = "lv_LogDialog";
            this.lv_LogDialog.Size = new System.Drawing.Size(664, 300);
            this.lv_LogDialog.TabIndex = 1;
            this.lv_LogDialog.UseCompatibleStateImageBehavior = false;
            this.lv_LogDialog.DoubleClick += new System.EventHandler(this.ItemDoubleClick);
            this.lv_LogDialog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogKeyPressed);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Variable Name";
            this.columnHeader1.Width = 125;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Element";
            this.columnHeader2.Width = 125;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Attribute";
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Time Range";
            this.columnHeader4.Width = 300;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Delete_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(187, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Edit_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(521, 345);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 32);
            this.button3.TabIndex = 4;
            this.button3.Text = "Ok";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OK_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(688, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveFileMenuItem,
            this.ImportFileMenuItem,
            this.deleteAllLogInputsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // SaveFileMenuItem
            // 
            this.SaveFileMenuItem.Name = "SaveFileMenuItem";
            this.SaveFileMenuItem.Size = new System.Drawing.Size(195, 22);
            this.SaveFileMenuItem.Text = "Save...";
            this.SaveFileMenuItem.Click += new System.EventHandler(this.SaveFileMenuItem_Click);
            // 
            // ImportFileMenuItem
            // 
            this.ImportFileMenuItem.Name = "ImportFileMenuItem";
            this.ImportFileMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ImportFileMenuItem.Text = "Import File...";
            this.ImportFileMenuItem.Click += new System.EventHandler(this.ImportFileMenuItem_Click);
            // 
            // deleteAllLogInputsToolStripMenuItem
            // 
            this.deleteAllLogInputsToolStripMenuItem.Name = "deleteAllLogInputsToolStripMenuItem";
            this.deleteAllLogInputsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.deleteAllLogInputsToolStripMenuItem.Text = "Delete All Log Inputs ...";
            this.deleteAllLogInputsToolStripMenuItem.Click += new System.EventHandler(this.deleteAllLogInputsToolStripMenuItem_Click);
            // 
            // LogDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 398);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lv_LogDialog);
            this.Name = "LogDialog";
            this.Text = "Log of Exported Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogDialog_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_LogDialog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllLogInputsToolStripMenuItem;
    }
}