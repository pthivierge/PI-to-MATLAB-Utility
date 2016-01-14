namespace MATLABfromCSharp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tb_MatlabName = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bn_Export = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.avcAttributes = new OSIsoft.AF.UI.AFViewControl();
            this.afTreeViewElements = new OSIsoft.AF.UI.AFTreeView();
            this.tbElementSearchName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.afDatabasePicker1 = new OSIsoft.AF.UI.AFDatabasePicker();
            this.bSearchElements = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.db_label = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbEventFrameSearch = new System.Windows.Forms.TextBox();
            this.bEFSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.afEventFrameFindCtrl = new OSIsoft.AF.UI.AFEventFrameFindCtrl();
            this.avcEventAttributes = new OSIsoft.AF.UI.AFViewControl();
            this.avcEventFrames = new OSIsoft.AF.UI.AFViewControl();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.avcPIPoints = new OSIsoft.AF.UI.AFViewControl();
            this.label6 = new System.Windows.Forms.Label();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMatlabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.EndTimeLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bnAdvancedDataSettings = new System.Windows.Forms.Button();
            this.checkB_varNameMatlab = new System.Windows.Forms.CheckBox();
            this.afServerPicker = new OSIsoft.AF.UI.PISystemPicker();
            this.startDTP = new OSIsoft.AF.UI.AFDateTimePickerCtrl();
            this.endDTP = new OSIsoft.AF.UI.AFDateTimePickerCtrl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.radioExport = new System.Windows.Forms.RadioButton();
            this.radioImport = new System.Windows.Forms.RadioButton();
            this.InformationDirectionPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.InformationDirectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_MatlabName
            // 
            this.tb_MatlabName.Location = new System.Drawing.Point(148, 477);
            this.tb_MatlabName.Name = "tb_MatlabName";
            this.tb_MatlabName.ReadOnly = true;
            this.tb_MatlabName.Size = new System.Drawing.Size(307, 20);
            this.tb_MatlabName.TabIndex = 8;
            this.tb_MatlabName.Click += new System.EventHandler(this.tb_MatlabName_Click);
            this.tb_MatlabName.DoubleClick += new System.EventHandler(this.tb_MatlabName_Click);
            this.tb_MatlabName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressed);
            this.tb_MatlabName.Leave += new System.EventHandler(this.tb_MatlabName_Leave);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Calendar.png");
            this.imageList1.Images.SetKeyName(1, "Element.png");
            this.imageList1.Images.SetKeyName(2, "Elements.png");
            this.imageList1.Images.SetKeyName(3, "ElementSelect.png");
            this.imageList1.Images.SetKeyName(4, "ElementsSelected.png");
            this.imageList1.Images.SetKeyName(5, "PITag.png");
            // 
            // bn_Export
            // 
            this.bn_Export.Location = new System.Drawing.Point(523, 472);
            this.bn_Export.Name = "bn_Export";
            this.bn_Export.Size = new System.Drawing.Size(108, 28);
            this.bn_Export.TabIndex = 10;
            this.bn_Export.Text = "Export to Matlab";
            this.bn_Export.UseVisualStyleBackColor = true;
            this.bn_Export.Click += new System.EventHandler(this.ExportToMatlab_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.avcAttributes);
            this.panel2.Controls.Add(this.afTreeViewElements);
            this.panel2.Controls.Add(this.tbElementSearchName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.afDatabasePicker1);
            this.panel2.Controls.Add(this.bSearchElements);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.db_label);
            this.panel2.Location = new System.Drawing.Point(6, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 343);
            this.panel2.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Element Name:";
            // 
            // avcAttributes
            // 
            this.avcAttributes.AccessibleDescription = "View Control for displaying AF objects";
            this.avcAttributes.AccessibleName = "View Control";
            this.avcAttributes.BackColor = System.Drawing.Color.Transparent;
            this.avcAttributes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.avcAttributes.DisplayPathLabel = false;
            this.avcAttributes.HelpContext = ((long)(0));
            this.avcAttributes.Location = new System.Drawing.Point(297, 91);
            this.avcAttributes.Name = "avcAttributes";
            this.avcAttributes.ReadOnly = true;
            this.avcAttributes.Size = new System.Drawing.Size(302, 238);
            this.avcAttributes.TabIndex = 39;
            // 
            // afTreeViewElements
            // 
            this.afTreeViewElements.HideSelection = false;
            this.afTreeViewElements.Location = new System.Drawing.Point(8, 91);
            this.afTreeViewElements.Name = "afTreeViewElements";
            this.afTreeViewElements.ReadOnly = true;
            this.afTreeViewElements.ShowNodeToolTips = true;
            this.afTreeViewElements.Size = new System.Drawing.Size(286, 238);
            this.afTreeViewElements.TabIndex = 28;
            this.afTreeViewElements.MenuItemClicked += new OSIsoft.AF.UI.MenuItemClickedEventHandler(this.afTreeViewElements_MenuItemClicked);
            this.afTreeViewElements.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AFTreeViewNode_Selected);
            // 
            // tbElementSearchName
            // 
            this.tbElementSearchName.Location = new System.Drawing.Point(100, 44);
            this.tbElementSearchName.Name = "tbElementSearchName";
            this.tbElementSearchName.Size = new System.Drawing.Size(379, 20);
            this.tbElementSearchName.TabIndex = 5;
            this.tbElementSearchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Attributes";
            // 
            // afDatabasePicker1
            // 
            this.afDatabasePicker1.AccessibleDescription = "Database Picker";
            this.afDatabasePicker1.AccessibleName = "Database Picker";
            this.afDatabasePicker1.Location = new System.Drawing.Point(100, 12);
            this.afDatabasePicker1.Name = "afDatabasePicker1";
            this.afDatabasePicker1.ShowBegin = false;
            this.afDatabasePicker1.ShowDelete = false;
            this.afDatabasePicker1.ShowEnd = false;
            this.afDatabasePicker1.ShowFind = false;
            this.afDatabasePicker1.ShowList = false;
            this.afDatabasePicker1.ShowNavigation = false;
            this.afDatabasePicker1.ShowNew = false;
            this.afDatabasePicker1.ShowNext = false;
            this.afDatabasePicker1.ShowPrevious = false;
            this.afDatabasePicker1.ShowProperties = false;
            this.afDatabasePicker1.Size = new System.Drawing.Size(195, 22);
            this.afDatabasePicker1.TabIndex = 28;
            this.afDatabasePicker1.SelectionChange += new OSIsoft.AF.UI.SelectionChangeEventHandler(this.afDatabasePicker1_SelectionChange);
            // 
            // bSearchElements
            // 
            this.bSearchElements.Location = new System.Drawing.Point(485, 39);
            this.bSearchElements.Name = "bSearchElements";
            this.bSearchElements.Size = new System.Drawing.Size(108, 28);
            this.bSearchElements.TabIndex = 5;
            this.bSearchElements.Text = "Search ";
            this.bSearchElements.UseVisualStyleBackColor = true;
            this.bSearchElements.Click += new System.EventHandler(this.bSearchElements_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Elements";
            // 
            // db_label
            // 
            this.db_label.AutoSize = true;
            this.db_label.Location = new System.Drawing.Point(7, 12);
            this.db_label.Name = "db_label";
            this.db_label.Size = new System.Drawing.Size(87, 13);
            this.db_label.TabIndex = 5;
            this.db_label.Text = "Database Name:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(627, 382);
            this.tabControl1.TabIndex = 13;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabIndex_Changed);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(619, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Asset Framework";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbEventFrameSearch);
            this.tabPage3.Controls.Add(this.bEFSearch);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.afEventFrameFindCtrl);
            this.tabPage3.Controls.Add(this.avcEventAttributes);
            this.tabPage3.Controls.Add(this.avcEventFrames);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(619, 356);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Event Frames";
            // 
            // tbEventFrameSearch
            // 
            this.tbEventFrameSearch.Location = new System.Drawing.Point(125, 11);
            this.tbEventFrameSearch.Name = "tbEventFrameSearch";
            this.tbEventFrameSearch.Size = new System.Drawing.Size(321, 20);
            this.tbEventFrameSearch.TabIndex = 44;
            // 
            // bEFSearch
            // 
            this.bEFSearch.Location = new System.Drawing.Point(489, 8);
            this.bEFSearch.Name = "bEFSearch";
            this.bEFSearch.Size = new System.Drawing.Size(108, 23);
            this.bEFSearch.TabIndex = 43;
            this.bEFSearch.Text = "Search ";
            this.bEFSearch.UseVisualStyleBackColor = true;
            this.bEFSearch.Click += new System.EventHandler(this.bEFSearch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Event Frames:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Search Event Frames";
            // 
            // afEventFrameFindCtrl
            // 
            this.afEventFrameFindCtrl.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.afEventFrameFindCtrl.Location = new System.Drawing.Point(445, 8);
            this.afEventFrameFindCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.afEventFrameFindCtrl.MinimumSize = new System.Drawing.Size(0, 22);
            this.afEventFrameFindCtrl.Name = "afEventFrameFindCtrl";
            this.afEventFrameFindCtrl.ShowFindButton = true;
            this.afEventFrameFindCtrl.ShowFullPath = false;
            this.afEventFrameFindCtrl.Size = new System.Drawing.Size(45, 24);
            this.afEventFrameFindCtrl.TabIndex = 41;
            this.afEventFrameFindCtrl.AFEventFrameUpdated += new OSIsoft.AF.UI.AFEventFrameFindCtrl.AFEventFrameUpdatedEventHandler(this.afEventFrameFindCtrl_AFEventFrameUpdated);
            this.afEventFrameFindCtrl.DialogButtonPressing += new OSIsoft.AF.UI.AFBaseUserControl.DialogButtonPressingEventHandler(this.afEventFrameFindCtrl_DialogButtonPressing);
            // 
            // avcEventAttributes
            // 
            this.avcEventAttributes.AccessibleDescription = "View Control for displaying AF objects";
            this.avcEventAttributes.AccessibleName = "View Control";
            this.avcEventAttributes.BackColor = System.Drawing.Color.Transparent;
            this.avcEventAttributes.DisplayPathLabel = false;
            this.avcEventAttributes.HelpContext = ((long)(0));
            this.avcEventAttributes.Location = new System.Drawing.Point(422, 63);
            this.avcEventAttributes.Name = "avcEventAttributes";
            this.avcEventAttributes.ReadOnly = true;
            this.avcEventAttributes.Size = new System.Drawing.Size(191, 284);
            this.avcEventAttributes.TabIndex = 40;
            // 
            // avcEventFrames
            // 
            this.avcEventFrames.AccessibleDescription = "View Control for displaying AF objects";
            this.avcEventFrames.AccessibleName = "View Control";
            this.avcEventFrames.BackColor = System.Drawing.Color.Transparent;
            this.avcEventFrames.DisplayPathLabel = false;
            this.avcEventFrames.HelpContext = ((long)(0));
            this.avcEventFrames.Location = new System.Drawing.Point(6, 45);
            this.avcEventFrames.Name = "avcEventFrames";
            this.avcEventFrames.ReadOnly = true;
            this.avcEventFrames.Size = new System.Drawing.Size(410, 302);
            this.avcEventFrames.TabIndex = 40;
            this.avcEventFrames.ItemSelected += new OSIsoft.AF.UI.ItemSelectedEventHandler(this.avcEventFrames_ItemSelected);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Attributes:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.avcPIPoints);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(619, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PI Points";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // avcPIPoints
            // 
            this.avcPIPoints.AccessibleDescription = "View Control for displaying AF objects";
            this.avcPIPoints.AccessibleName = "View Control";
            this.avcPIPoints.BackColor = System.Drawing.Color.Transparent;
            this.avcPIPoints.DisplayPathLabel = false;
            this.avcPIPoints.HelpContext = ((long)(0));
            this.avcPIPoints.Location = new System.Drawing.Point(6, 15);
            this.avcPIPoints.Name = "avcPIPoints";
            this.avcPIPoints.ReadOnly = true;
            this.avcPIPoints.Size = new System.Drawing.Size(607, 335);
            this.avcPIPoints.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 18;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "PI Points";
            this.columnHeader5.Width = 1000;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(648, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveFileMenuItem,
            this.ImportFileMenuItem,
            this.viewLogToolStripMenuItem,
            this.saveMatlabMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // SaveFileMenuItem
            // 
            this.SaveFileMenuItem.Name = "SaveFileMenuItem";
            this.SaveFileMenuItem.Size = new System.Drawing.Size(155, 22);
            this.SaveFileMenuItem.Text = "Save...";
            this.SaveFileMenuItem.Click += new System.EventHandler(this.SaveFileMenuItem_Click);
            // 
            // ImportFileMenuItem
            // 
            this.ImportFileMenuItem.Name = "ImportFileMenuItem";
            this.ImportFileMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ImportFileMenuItem.Text = "Import File...";
            this.ImportFileMenuItem.Click += new System.EventHandler(this.ImportFileMenuItem_Click);
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.viewLogToolStripMenuItem.Text = "View Log ...";
            this.viewLogToolStripMenuItem.Click += new System.EventHandler(this.viewLogToolStripMenuItem_Click);
            // 
            // saveMatlabMenuItem
            // 
            this.saveMatlabMenuItem.Name = "saveMatlabMenuItem";
            this.saveMatlabMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveMatlabMenuItem.Text = "Open Matlab ...";
            this.saveMatlabMenuItem.Click += new System.EventHandler(this.openMatlabMenuItem_Click);
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Location = new System.Drawing.Point(35, 456);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(58, 13);
            this.StartTimeLabel.TabIndex = 15;
            this.StartTimeLabel.Text = "Start Time:";
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Location = new System.Drawing.Point(327, 456);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.EndTimeLabel.TabIndex = 16;
            this.EndTimeLabel.Text = "End Time:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStripLabel,
            this.StatusStripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 541);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(648, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusStripLabel
            // 
            this.StatusStripLabel.Name = "StatusStripLabel";
            this.StatusStripLabel.Size = new System.Drawing.Size(42, 17);
            this.StatusStripLabel.Text = "Status:";
            // 
            // StatusStripStatus
            // 
            this.StatusStripStatus.Name = "StatusStripStatus";
            this.StatusStripStatus.Size = new System.Drawing.Size(36, 17);
            this.StatusStripStatus.Text = "None";
            // 
            // bnAdvancedDataSettings
            // 
            this.bnAdvancedDataSettings.Location = new System.Drawing.Point(10, 513);
            this.bnAdvancedDataSettings.Name = "bnAdvancedDataSettings";
            this.bnAdvancedDataSettings.Size = new System.Drawing.Size(169, 23);
            this.bnAdvancedDataSettings.TabIndex = 27;
            this.bnAdvancedDataSettings.Text = "Advanced Data Settings >>";
            this.bnAdvancedDataSettings.UseVisualStyleBackColor = true;
            this.bnAdvancedDataSettings.Click += new System.EventHandler(this.AdvancedDataClick);
            // 
            // checkB_varNameMatlab
            // 
            this.checkB_varNameMatlab.AutoSize = true;
            this.checkB_varNameMatlab.Location = new System.Drawing.Point(12, 479);
            this.checkB_varNameMatlab.Name = "checkB_varNameMatlab";
            this.checkB_varNameMatlab.Size = new System.Drawing.Size(133, 17);
            this.checkB_varNameMatlab.TabIndex = 7;
            this.checkB_varNameMatlab.Text = "Matlab Variable Name:";
            this.checkB_varNameMatlab.UseVisualStyleBackColor = true;
            this.checkB_varNameMatlab.CheckedChanged += new System.EventHandler(this.MatlabNameCheckedChanged);
            // 
            // afServerPicker
            // 
            this.afServerPicker.AccessibleDescription = "PI System Picker";
            this.afServerPicker.AccessibleName = "PI System Picker";
            this.afServerPicker.ConnectAutomatically = true;
            this.afServerPicker.Cursor = System.Windows.Forms.Cursors.Default;
            this.afServerPicker.EnableNavigation = false;
            this.afServerPicker.EnablePrevious = false;
            this.afServerPicker.Location = new System.Drawing.Point(78, 5);
            this.afServerPicker.LoginPromptSetting = OSIsoft.AF.UI.PISystemPicker.LoginPromptSettingOptions.Default;
            this.afServerPicker.Name = "afServerPicker";
            this.afServerPicker.ShowBegin = false;
            this.afServerPicker.ShowDelete = false;
            this.afServerPicker.ShowEnd = false;
            this.afServerPicker.ShowFind = false;
            this.afServerPicker.ShowNavigation = false;
            this.afServerPicker.ShowNew = false;
            this.afServerPicker.ShowNext = false;
            this.afServerPicker.ShowPrevious = false;
            this.afServerPicker.Size = new System.Drawing.Size(544, 22);
            this.afServerPicker.TabIndex = 29;
            this.afServerPicker.ConnectionChange += new OSIsoft.AF.UI.ConnectionChangeEventHandler(this.afServerPicker_ConnectionChange);
            // 
            // startDTP
            // 
            this.startDTP.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.startDTP.ImageIndex = 1;
            this.startDTP.Location = new System.Drawing.Point(98, 449);
            this.startDTP.Margin = new System.Windows.Forms.Padding(4);
            this.startDTP.MinimumSize = new System.Drawing.Size(0, 22);
            this.startDTP.Name = "startDTP";
            this.startDTP.Size = new System.Drawing.Size(215, 24);
            this.startDTP.TabIndex = 32;
            // 
            // endDTP
            // 
            this.endDTP.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.endDTP.ImageIndex = 1;
            this.endDTP.Location = new System.Drawing.Point(387, 449);
            this.endDTP.Margin = new System.Windows.Forms.Padding(4);
            this.endDTP.MinimumSize = new System.Drawing.Size(0, 22);
            this.endDTP.Name = "endDTP";
            this.endDTP.Size = new System.Drawing.Size(215, 24);
            this.endDTP.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.afServerPicker);
            this.panel3.Location = new System.Drawing.Point(14, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(627, 34);
            this.panel3.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "AF Server:";
            // 
            // radioExport
            // 
            this.radioExport.AutoSize = true;
            this.radioExport.Checked = true;
            this.radioExport.Location = new System.Drawing.Point(14, 6);
            this.radioExport.Name = "radioExport";
            this.radioExport.Size = new System.Drawing.Size(102, 17);
            this.radioExport.TabIndex = 34;
            this.radioExport.TabStop = true;
            this.radioExport.Text = "Export to Matlab";
            this.radioExport.UseVisualStyleBackColor = true;
            this.radioExport.CheckedChanged += new System.EventHandler(this.radioInformationDirectionChanged);
            // 
            // radioImport
            // 
            this.radioImport.AutoSize = true;
            this.radioImport.Location = new System.Drawing.Point(138, 6);
            this.radioImport.Name = "radioImport";
            this.radioImport.Size = new System.Drawing.Size(82, 17);
            this.radioImport.TabIndex = 35;
            this.radioImport.Text = "Import to AF";
            this.radioImport.UseVisualStyleBackColor = true;
            this.radioImport.CheckedChanged += new System.EventHandler(this.radioInformationDirectionChanged);
            // 
            // InformationDirectionPanel
            // 
            this.InformationDirectionPanel.Controls.Add(this.radioImport);
            this.InformationDirectionPanel.Controls.Add(this.radioExport);
            this.InformationDirectionPanel.Location = new System.Drawing.Point(398, 506);
            this.InformationDirectionPanel.Name = "InformationDirectionPanel";
            this.InformationDirectionPanel.Size = new System.Drawing.Size(233, 30);
            this.InformationDirectionPanel.TabIndex = 36;
            this.InformationDirectionPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Matlab Variable Name:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(648, 563);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InformationDirectionPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.bn_Export);
            this.Controls.Add(this.endDTP);
            this.Controls.Add(this.startDTP);
            this.Controls.Add(this.bnAdvancedDataSettings);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.EndTimeLabel);
            this.Controls.Add(this.StartTimeLabel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tb_MatlabName);
            this.Controls.Add(this.checkB_varNameMatlab);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(664, 602);
            this.MinimumSize = new System.Drawing.Size(664, 602);
            this.Name = "MainForm";
            this.Text = "PI System to Matlab";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PItoMatlabForm_Closing);
            this.Load += new System.EventHandler(this.PItoMatlabForm_Load);
            this.Click += new System.EventHandler(this.MainHasFocus);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.InformationDirectionPanel.ResumeLayout(false);
            this.InformationDirectionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_MatlabName; //AFTreeView
        private System.Windows.Forms.Button bn_Export;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label db_label;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportFileMenuItem;
        private System.Windows.Forms.Label StartTimeLabel;
        private System.Windows.Forms.Label EndTimeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbElementSearchName;
        private System.Windows.Forms.Button bSearchElements;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripLabel;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button bnAdvancedDataSettings;
        private System.Windows.Forms.CheckBox checkB_varNameMatlab;
        private System.Windows.Forms.ToolStripMenuItem saveMatlabMenuItem;
        private OSIsoft.AF.UI.AFTreeView afTreeViewElements;
        private OSIsoft.AF.UI.AFDatabasePicker afDatabasePicker1;
        private OSIsoft.AF.UI.PISystemPicker afServerPicker;
        private OSIsoft.AF.UI.AFDateTimePickerCtrl startDTP;
        private OSIsoft.AF.UI.AFDateTimePickerCtrl endDTP;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioExport;
        private System.Windows.Forms.RadioButton radioImport;
        private System.Windows.Forms.Panel InformationDirectionPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private OSIsoft.AF.UI.AFViewControl avcAttributes;
        private OSIsoft.AF.UI.AFViewControl avcEventFrames;
        private OSIsoft.AF.UI.AFViewControl avcEventAttributes;
        private OSIsoft.AF.UI.AFViewControl avcPIPoints;
        private System.Windows.Forms.Label label2;
        private OSIsoft.AF.UI.AFEventFrameFindCtrl afEventFrameFindCtrl;
        private System.Windows.Forms.Button bEFSearch;
        private System.Windows.Forms.TextBox tbEventFrameSearch;

    }
}

