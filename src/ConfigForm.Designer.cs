namespace Coroin.EmBars
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        System.ComponentModel.IContainer components = null;

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
        void InitializeComponent()
        {
            this.dialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.lblExpirationMessage = new System.Windows.Forms.Label();
            this.lblConfig = new System.Windows.Forms.Label();
            this.lblBuildMessage = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.ctlSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.bullRangeMax = new System.Windows.Forms.NumericUpDown();
            this.bullRangeMin = new System.Windows.Forms.NumericUpDown();
            this.cboCloseOption = new System.Windows.Forms.ComboBox();
            this.cboOpenOption = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tcConfig = new System.Windows.Forms.TabControl();
            this.tpBull = new System.Windows.Forms.TabPage();
            this.gbBullLinks = new System.Windows.Forms.GroupBox();
            this.bullLinkContract = new System.Windows.Forms.LinkLabel();
            this.bullLinkExpand = new System.Windows.Forms.LinkLabel();
            this.bullLinkFixed = new System.Windows.Forms.LinkLabel();
            this.gbBullCont = new System.Windows.Forms.GroupBox();
            this.lblBullContinuePrev = new System.Windows.Forms.Label();
            this.bullContValue = new System.Windows.Forms.NumericUpDown();
            this.gbBullInit = new System.Windows.Forms.GroupBox();
            this.bullInitPrev = new System.Windows.Forms.RadioButton();
            this.bullInitMax = new System.Windows.Forms.RadioButton();
            this.bullInitValue = new System.Windows.Forms.NumericUpDown();
            this.bullInitMin = new System.Windows.Forms.RadioButton();
            this.tpBear = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bearLinkContract = new System.Windows.Forms.LinkLabel();
            this.bearLinkExpand = new System.Windows.Forms.LinkLabel();
            this.bearLinkFixed = new System.Windows.Forms.LinkLabel();
            this.gbContinuationBear = new System.Windows.Forms.GroupBox();
            this.lblBearContinuePrev = new System.Windows.Forms.Label();
            this.bearContValue = new System.Windows.Forms.NumericUpDown();
            this.gbInitializationBear = new System.Windows.Forms.GroupBox();
            this.bearInitPrev = new System.Windows.Forms.RadioButton();
            this.bearInitMax = new System.Windows.Forms.RadioButton();
            this.bearInitValue = new System.Windows.Forms.NumericUpDown();
            this.bearInitMin = new System.Windows.Forms.RadioButton();
            this.bearRangeMin = new System.Windows.Forms.NumericUpDown();
            this.bearRangeMax = new System.Windows.Forms.NumericUpDown();
            this.tpOptions = new System.Windows.Forms.TabPage();
            this.gbCloseOptions = new System.Windows.Forms.GroupBox();
            this.lblCloseOptionHelp = new System.Windows.Forms.Label();
            this.gbOpenOption = new System.Windows.Forms.GroupBox();
            this.lblOpenOptionHelp = new System.Windows.Forms.Label();
            this.tpHelp = new System.Windows.Forms.TabPage();
            this.helpBuild = new System.Windows.Forms.Label();
            this.helpText = new System.Windows.Forms.Label();
            this.linkHelpFAQ = new System.Windows.Forms.LinkLabel();
            this.linkHelpLicense = new System.Windows.Forms.LinkLabel();
            this.linkHelpContact = new System.Windows.Forms.LinkLabel();
            this.linkHelpVideo = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bullRangeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bullRangeMin)).BeginInit();
            this.tcConfig.SuspendLayout();
            this.tpBull.SuspendLayout();
            this.gbBullLinks.SuspendLayout();
            this.gbBullCont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bullContValue)).BeginInit();
            this.gbBullInit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bullInitValue)).BeginInit();
            this.tpBear.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbContinuationBear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bearContValue)).BeginInit();
            this.gbInitializationBear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bearInitValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bearRangeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bearRangeMax)).BeginInit();
            this.tpOptions.SuspendLayout();
            this.gbCloseOptions.SuspendLayout();
            this.gbOpenOption.SuspendLayout();
            this.tpHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // dialogOpen
            // 
            this.dialogOpen.CheckFileExists = false;
            this.dialogOpen.DefaultExt = "xml";
            this.dialogOpen.FileName = "EmBars-Config-1.xml";
            this.dialogOpen.Filter = "config files|*.xml";
            this.dialogOpen.SupportMultiDottedExtensions = true;
            this.dialogOpen.Title = "Select Config File";
            // 
            // lblExpirationMessage
            // 
            this.lblExpirationMessage.Location = new System.Drawing.Point(0, 0);
            this.lblExpirationMessage.Name = "lblExpirationMessage";
            this.lblExpirationMessage.Size = new System.Drawing.Size(100, 23);
            this.lblExpirationMessage.TabIndex = 125;
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.lblConfig.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfig.ForeColor = System.Drawing.Color.Navy;
            this.lblConfig.Location = new System.Drawing.Point(230, 43);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(42, 14);
            this.lblConfig.TabIndex = 122;
            this.lblConfig.Text = "# {0}";
            // 
            // lblBuildMessage
            // 
            this.lblBuildMessage.AutoSize = true;
            this.lblBuildMessage.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildMessage.ForeColor = System.Drawing.Color.Black;
            this.lblBuildMessage.Location = new System.Drawing.Point(62, 417);
            this.lblBuildMessage.Name = "lblBuildMessage";
            this.lblBuildMessage.Size = new System.Drawing.Size(98, 14);
            this.lblBuildMessage.TabIndex = 120;
            this.lblBuildMessage.Text = "--copyright--";
            this.lblBuildMessage.Click += new System.EventHandler(this.buildMessage_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOpen.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOpen.Location = new System.Drawing.Point(29, 343);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(65, 30);
            this.btnOpen.TabIndex = 119;
            this.btnOpen.Text = "open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // ctlSaveFileDialog
            // 
            this.ctlSaveFileDialog.DefaultExt = "xml";
            this.ctlSaveFileDialog.FileName = "EmBars-MyConfig.xml";
            this.ctlSaveFileDialog.Filter = "config files|*.xml";
            this.ctlSaveFileDialog.SupportMultiDottedExtensions = true;
            this.ctlSaveFileDialog.Title = "Save Config File";
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMessage.ForeColor = System.Drawing.Color.Navy;
            this.lblStatusMessage.Location = new System.Drawing.Point(13, 43);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(84, 14);
            this.lblStatusMessage.TabIndex = 117;
            this.lblStatusMessage.Text = "Loading ...";
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveAs.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveAs.Location = new System.Drawing.Point(110, 378);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(65, 30);
            this.btnSaveAs.TabIndex = 116;
            this.btnSaveAs.Text = "save as";
            this.btnSaveAs.UseVisualStyleBackColor = false;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // bullRangeMax
            // 
            this.bullRangeMax.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.bullRangeMax.Location = new System.Drawing.Point(163, 49);
            this.bullRangeMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bullRangeMax.Name = "bullRangeMax";
            this.bullRangeMax.Size = new System.Drawing.Size(47, 20);
            this.bullRangeMax.TabIndex = 115;
            this.bullRangeMax.Tag = "bull";
            this.bullRangeMax.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.bullRangeMax.ValueChanged += new System.EventHandler(this.bullRangeMax_ValueChanged);
            // 
            // bullRangeMin
            // 
            this.bullRangeMin.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.bullRangeMin.Location = new System.Drawing.Point(163, 23);
            this.bullRangeMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bullRangeMin.Name = "bullRangeMin";
            this.bullRangeMin.Size = new System.Drawing.Size(47, 20);
            this.bullRangeMin.TabIndex = 114;
            this.bullRangeMin.Tag = "bull";
            this.bullRangeMin.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.bullRangeMin.ValueChanged += new System.EventHandler(this.bullRangeMin_ValueChanged);
            // 
            // cboCloseOption
            // 
            this.cboCloseOption.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.cboCloseOption.FormattingEnabled = true;
            this.cboCloseOption.Location = new System.Drawing.Point(10, 16);
            this.cboCloseOption.Name = "cboCloseOption";
            this.cboCloseOption.Size = new System.Drawing.Size(120, 22);
            this.cboCloseOption.TabIndex = 108;
            this.cboCloseOption.SelectedIndexChanged += new System.EventHandler(this.closeOption_SelectedIndexChanged);
            // 
            // cboOpenOption
            // 
            this.cboOpenOption.DropDownWidth = 80;
            this.cboOpenOption.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.cboOpenOption.FormattingEnabled = true;
            this.cboOpenOption.Location = new System.Drawing.Point(10, 17);
            this.cboOpenOption.Name = "cboOpenOption";
            this.cboOpenOption.Size = new System.Drawing.Size(120, 22);
            this.cboOpenOption.TabIndex = 107;
            this.cboOpenOption.SelectedIndexChanged += new System.EventHandler(this.openOption_SelectedIndexChanged);
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnApply.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnApply.Location = new System.Drawing.Point(29, 378);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(65, 30);
            this.btnApply.TabIndex = 118;
            this.btnApply.Text = "apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(191, 378);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 30);
            this.btnClose.TabIndex = 126;
            this.btnClose.Text = "close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Courier New", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(13, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 20);
            this.lblTitle.TabIndex = 127;
            this.lblTitle.Text = "EmBars Configuration Tool";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(110, 343);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 30);
            this.btnSave.TabIndex = 128;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReset.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(191, 343);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(65, 30);
            this.btnReset.TabIndex = 129;
            this.btnReset.Text = "reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tcConfig
            // 
            this.tcConfig.Controls.Add(this.tpBull);
            this.tcConfig.Controls.Add(this.tpBear);
            this.tcConfig.Controls.Add(this.tpOptions);
            this.tcConfig.Controls.Add(this.tpHelp);
            this.tcConfig.ItemSize = new System.Drawing.Size(60, 20);
            this.tcConfig.Location = new System.Drawing.Point(15, 65);
            this.tcConfig.Name = "tcConfig";
            this.tcConfig.SelectedIndex = 0;
            this.tcConfig.Size = new System.Drawing.Size(255, 270);
            this.tcConfig.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcConfig.TabIndex = 130;
            this.tcConfig.Tag = "bear";
            // 
            // tpBull
            // 
            this.tpBull.BackColor = System.Drawing.SystemColors.Control;
            this.tpBull.Controls.Add(this.gbBullLinks);
            this.tpBull.Controls.Add(this.gbBullCont);
            this.tpBull.Controls.Add(this.gbBullInit);
            this.tpBull.Location = new System.Drawing.Point(4, 24);
            this.tpBull.Name = "tpBull";
            this.tpBull.Padding = new System.Windows.Forms.Padding(3);
            this.tpBull.Size = new System.Drawing.Size(247, 242);
            this.tpBull.TabIndex = 1;
            this.tpBull.Text = "Bull";
            // 
            // gbBullLinks
            // 
            this.gbBullLinks.Controls.Add(this.bullLinkContract);
            this.gbBullLinks.Controls.Add(this.bullLinkExpand);
            this.gbBullLinks.Controls.Add(this.bullLinkFixed);
            this.gbBullLinks.Location = new System.Drawing.Point(13, 10);
            this.gbBullLinks.Name = "gbBullLinks";
            this.gbBullLinks.Size = new System.Drawing.Size(220, 45);
            this.gbBullLinks.TabIndex = 134;
            this.gbBullLinks.TabStop = false;
            this.gbBullLinks.Text = "Quick Links";
            // 
            // bullLinkContract
            // 
            this.bullLinkContract.AutoSize = true;
            this.bullLinkContract.Location = new System.Drawing.Point(140, 18);
            this.bullLinkContract.Name = "bullLinkContract";
            this.bullLinkContract.Size = new System.Drawing.Size(63, 14);
            this.bullLinkContract.TabIndex = 2;
            this.bullLinkContract.TabStop = true;
            this.bullLinkContract.Tag = "bull";
            this.bullLinkContract.Text = "Contract";
            this.bullLinkContract.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.bullLinkContract_LinkClicked);
            // 
            // bullLinkExpand
            // 
            this.bullLinkExpand.AutoSize = true;
            this.bullLinkExpand.Location = new System.Drawing.Point(75, 18);
            this.bullLinkExpand.Name = "bullLinkExpand";
            this.bullLinkExpand.Size = new System.Drawing.Size(49, 14);
            this.bullLinkExpand.TabIndex = 1;
            this.bullLinkExpand.TabStop = true;
            this.bullLinkExpand.Tag = "bull";
            this.bullLinkExpand.Text = "Expand";
            this.bullLinkExpand.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.bullLinkExpand_LinkClicked);
            // 
            // bullLinkFixed
            // 
            this.bullLinkFixed.AutoSize = true;
            this.bullLinkFixed.Location = new System.Drawing.Point(17, 18);
            this.bullLinkFixed.Name = "bullLinkFixed";
            this.bullLinkFixed.Size = new System.Drawing.Size(42, 14);
            this.bullLinkFixed.TabIndex = 0;
            this.bullLinkFixed.TabStop = true;
            this.bullLinkFixed.Tag = "bull";
            this.bullLinkFixed.Text = "Fixed";
            this.bullLinkFixed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.bullLinkFixed_LinkClicked);
            // 
            // gbBullCont
            // 
            this.gbBullCont.Controls.Add(this.lblBullContinuePrev);
            this.gbBullCont.Controls.Add(this.bullContValue);
            this.gbBullCont.Location = new System.Drawing.Point(13, 181);
            this.gbBullCont.Name = "gbBullCont";
            this.gbBullCont.Size = new System.Drawing.Size(220, 45);
            this.gbBullCont.TabIndex = 133;
            this.gbBullCont.TabStop = false;
            this.gbBullCont.Text = "Trend Continuation";
            // 
            // lblBullContinuePrev
            // 
            this.lblBullContinuePrev.AutoSize = true;
            this.lblBullContinuePrev.Location = new System.Drawing.Point(13, 20);
            this.lblBullContinuePrev.Name = "lblBullContinuePrev";
            this.lblBullContinuePrev.Size = new System.Drawing.Size(91, 14);
            this.lblBullContinuePrev.TabIndex = 130;
            this.lblBullContinuePrev.Text = "Previous +/-";
            // 
            // bullContValue
            // 
            this.bullContValue.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.bullContValue.Location = new System.Drawing.Point(163, 14);
            this.bullContValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.bullContValue.Name = "bullContValue";
            this.bullContValue.Size = new System.Drawing.Size(47, 20);
            this.bullContValue.TabIndex = 129;
            this.bullContValue.Tag = "bull";
            this.bullContValue.ValueChanged += new System.EventHandler(this.bullContValue_ValueChanged);
            // 
            // gbBullInit
            // 
            this.gbBullInit.Controls.Add(this.bullInitPrev);
            this.gbBullInit.Controls.Add(this.bullInitMax);
            this.gbBullInit.Controls.Add(this.bullInitValue);
            this.gbBullInit.Controls.Add(this.bullInitMin);
            this.gbBullInit.Controls.Add(this.bullRangeMin);
            this.gbBullInit.Controls.Add(this.bullRangeMax);
            this.gbBullInit.Location = new System.Drawing.Point(13, 63);
            this.gbBullInit.Name = "gbBullInit";
            this.gbBullInit.Size = new System.Drawing.Size(220, 110);
            this.gbBullInit.TabIndex = 132;
            this.gbBullInit.TabStop = false;
            this.gbBullInit.Text = "Trend Init";
            // 
            // bullInitPrev
            // 
            this.bullInitPrev.AutoSize = true;
            this.bullInitPrev.Location = new System.Drawing.Point(16, 77);
            this.bullInitPrev.Name = "bullInitPrev";
            this.bullInitPrev.Size = new System.Drawing.Size(109, 18);
            this.bullInitPrev.TabIndex = 2;
            this.bullInitPrev.TabStop = true;
            this.bullInitPrev.Tag = "bull";
            this.bullInitPrev.Text = "Previo&us +/-";
            this.bullInitPrev.UseVisualStyleBackColor = true;
            this.bullInitPrev.CheckedChanged += new System.EventHandler(this.bullInitPrev_CheckedChanged);
            // 
            // bullInitMax
            // 
            this.bullInitMax.AutoSize = true;
            this.bullInitMax.Location = new System.Drawing.Point(16, 51);
            this.bullInitMax.Name = "bullInitMax";
            this.bullInitMax.Size = new System.Drawing.Size(88, 18);
            this.bullInitMax.TabIndex = 1;
            this.bullInitMax.Tag = "bull";
            this.bullInitMax.Text = "Range Ma&x";
            this.bullInitMax.UseVisualStyleBackColor = true;
            this.bullInitMax.CheckedChanged += new System.EventHandler(this.bullInitMax_CheckedChanged);
            // 
            // bullInitValue
            // 
            this.bullInitValue.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.bullInitValue.Location = new System.Drawing.Point(163, 75);
            this.bullInitValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.bullInitValue.Name = "bullInitValue";
            this.bullInitValue.Size = new System.Drawing.Size(47, 20);
            this.bullInitValue.TabIndex = 128;
            this.bullInitValue.Tag = "bull";
            this.bullInitValue.ValueChanged += new System.EventHandler(this.bullInitValue_ValueChanged);
            // 
            // bullInitMin
            // 
            this.bullInitMin.AutoSize = true;
            this.bullInitMin.Location = new System.Drawing.Point(16, 25);
            this.bullInitMin.Name = "bullInitMin";
            this.bullInitMin.Size = new System.Drawing.Size(88, 18);
            this.bullInitMin.TabIndex = 0;
            this.bullInitMin.Tag = "bull";
            this.bullInitMin.Text = "Range Mi&n";
            this.bullInitMin.UseVisualStyleBackColor = true;
            this.bullInitMin.CheckedChanged += new System.EventHandler(this.bullInitMin_CheckedChanged);
            // 
            // tpBear
            // 
            this.tpBear.BackColor = System.Drawing.SystemColors.Control;
            this.tpBear.Controls.Add(this.groupBox1);
            this.tpBear.Controls.Add(this.gbContinuationBear);
            this.tpBear.Controls.Add(this.gbInitializationBear);
            this.tpBear.Location = new System.Drawing.Point(4, 24);
            this.tpBear.Name = "tpBear";
            this.tpBear.Padding = new System.Windows.Forms.Padding(3);
            this.tpBear.Size = new System.Drawing.Size(247, 242);
            this.tpBear.TabIndex = 2;
            this.tpBear.Text = "Bear";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bearLinkContract);
            this.groupBox1.Controls.Add(this.bearLinkExpand);
            this.groupBox1.Controls.Add(this.bearLinkFixed);
            this.groupBox1.Location = new System.Drawing.Point(13, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 45);
            this.groupBox1.TabIndex = 137;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quick Links";
            // 
            // bearLinkContract
            // 
            this.bearLinkContract.AutoSize = true;
            this.bearLinkContract.Location = new System.Drawing.Point(140, 18);
            this.bearLinkContract.Name = "bearLinkContract";
            this.bearLinkContract.Size = new System.Drawing.Size(63, 14);
            this.bearLinkContract.TabIndex = 2;
            this.bearLinkContract.TabStop = true;
            this.bearLinkContract.Tag = "bear";
            this.bearLinkContract.Text = "Contract";
            this.bearLinkContract.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.bearLinkContract_LinkClicked);
            // 
            // bearLinkExpand
            // 
            this.bearLinkExpand.AutoSize = true;
            this.bearLinkExpand.Location = new System.Drawing.Point(75, 18);
            this.bearLinkExpand.Name = "bearLinkExpand";
            this.bearLinkExpand.Size = new System.Drawing.Size(49, 14);
            this.bearLinkExpand.TabIndex = 1;
            this.bearLinkExpand.TabStop = true;
            this.bearLinkExpand.Tag = "bear";
            this.bearLinkExpand.Text = "Expand";
            this.bearLinkExpand.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.bearLinkExpand_LinkClicked);
            // 
            // bearLinkFixed
            // 
            this.bearLinkFixed.AutoSize = true;
            this.bearLinkFixed.Location = new System.Drawing.Point(17, 18);
            this.bearLinkFixed.Name = "bearLinkFixed";
            this.bearLinkFixed.Size = new System.Drawing.Size(42, 14);
            this.bearLinkFixed.TabIndex = 0;
            this.bearLinkFixed.TabStop = true;
            this.bearLinkFixed.Tag = "bear";
            this.bearLinkFixed.Text = "Fixed";
            this.bearLinkFixed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.bearLinkFixed_LinkClicked);
            // 
            // gbContinuationBear
            // 
            this.gbContinuationBear.Controls.Add(this.lblBearContinuePrev);
            this.gbContinuationBear.Controls.Add(this.bearContValue);
            this.gbContinuationBear.Location = new System.Drawing.Point(13, 181);
            this.gbContinuationBear.Name = "gbContinuationBear";
            this.gbContinuationBear.Size = new System.Drawing.Size(220, 45);
            this.gbContinuationBear.TabIndex = 136;
            this.gbContinuationBear.TabStop = false;
            this.gbContinuationBear.Text = "Trend Continuation";
            // 
            // lblBearContinuePrev
            // 
            this.lblBearContinuePrev.AutoSize = true;
            this.lblBearContinuePrev.Location = new System.Drawing.Point(13, 20);
            this.lblBearContinuePrev.Name = "lblBearContinuePrev";
            this.lblBearContinuePrev.Size = new System.Drawing.Size(91, 14);
            this.lblBearContinuePrev.TabIndex = 131;
            this.lblBearContinuePrev.Text = "Previous +/-";
            // 
            // bearContValue
            // 
            this.bearContValue.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.bearContValue.Location = new System.Drawing.Point(163, 14);
            this.bearContValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.bearContValue.Name = "bearContValue";
            this.bearContValue.Size = new System.Drawing.Size(47, 20);
            this.bearContValue.TabIndex = 129;
            this.bearContValue.Tag = "bear";
            this.bearContValue.ValueChanged += new System.EventHandler(this.bearContValue_ValueChanged);
            // 
            // gbInitializationBear
            // 
            this.gbInitializationBear.Controls.Add(this.bearInitPrev);
            this.gbInitializationBear.Controls.Add(this.bearInitMax);
            this.gbInitializationBear.Controls.Add(this.bearInitValue);
            this.gbInitializationBear.Controls.Add(this.bearInitMin);
            this.gbInitializationBear.Controls.Add(this.bearRangeMin);
            this.gbInitializationBear.Controls.Add(this.bearRangeMax);
            this.gbInitializationBear.Location = new System.Drawing.Point(13, 63);
            this.gbInitializationBear.Name = "gbInitializationBear";
            this.gbInitializationBear.Size = new System.Drawing.Size(220, 110);
            this.gbInitializationBear.TabIndex = 135;
            this.gbInitializationBear.TabStop = false;
            this.gbInitializationBear.Text = "Trend Init";
            // 
            // bearInitPrev
            // 
            this.bearInitPrev.AutoSize = true;
            this.bearInitPrev.Location = new System.Drawing.Point(16, 77);
            this.bearInitPrev.Name = "bearInitPrev";
            this.bearInitPrev.Size = new System.Drawing.Size(109, 18);
            this.bearInitPrev.TabIndex = 2;
            this.bearInitPrev.TabStop = true;
            this.bearInitPrev.Tag = "bear";
            this.bearInitPrev.Text = "Previo&us +/-";
            this.bearInitPrev.UseVisualStyleBackColor = true;
            this.bearInitPrev.CheckedChanged += new System.EventHandler(this.bearInitPrev_CheckedChanged);
            // 
            // bearInitMax
            // 
            this.bearInitMax.AutoSize = true;
            this.bearInitMax.Location = new System.Drawing.Point(16, 51);
            this.bearInitMax.Name = "bearInitMax";
            this.bearInitMax.Size = new System.Drawing.Size(88, 18);
            this.bearInitMax.TabIndex = 1;
            this.bearInitMax.Tag = "bear";
            this.bearInitMax.Text = "Range Ma&x";
            this.bearInitMax.UseVisualStyleBackColor = true;
            this.bearInitMax.CheckedChanged += new System.EventHandler(this.bearInitMax_CheckedChanged);
            // 
            // bearInitValue
            // 
            this.bearInitValue.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.bearInitValue.Location = new System.Drawing.Point(163, 75);
            this.bearInitValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.bearInitValue.Name = "bearInitValue";
            this.bearInitValue.Size = new System.Drawing.Size(47, 20);
            this.bearInitValue.TabIndex = 128;
            this.bearInitValue.Tag = "bear";
            this.bearInitValue.ValueChanged += new System.EventHandler(this.bearInitValue_ValueChanged);
            // 
            // bearInitMin
            // 
            this.bearInitMin.AutoSize = true;
            this.bearInitMin.Location = new System.Drawing.Point(16, 25);
            this.bearInitMin.Name = "bearInitMin";
            this.bearInitMin.Size = new System.Drawing.Size(88, 18);
            this.bearInitMin.TabIndex = 0;
            this.bearInitMin.Tag = "bear";
            this.bearInitMin.Text = "Range Mi&n";
            this.bearInitMin.UseVisualStyleBackColor = true;
            this.bearInitMin.CheckedChanged += new System.EventHandler(this.bearInitMin_CheckedChanged);
            // 
            // bearRangeMin
            // 
            this.bearRangeMin.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.bearRangeMin.Location = new System.Drawing.Point(163, 23);
            this.bearRangeMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bearRangeMin.Name = "bearRangeMin";
            this.bearRangeMin.Size = new System.Drawing.Size(47, 20);
            this.bearRangeMin.TabIndex = 114;
            this.bearRangeMin.Tag = "bear";
            this.bearRangeMin.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.bearRangeMin.ValueChanged += new System.EventHandler(this.bearRangeMin_ValueChanged);
            // 
            // bearRangeMax
            // 
            this.bearRangeMax.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.bearRangeMax.Location = new System.Drawing.Point(163, 49);
            this.bearRangeMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bearRangeMax.Name = "bearRangeMax";
            this.bearRangeMax.Size = new System.Drawing.Size(47, 20);
            this.bearRangeMax.TabIndex = 115;
            this.bearRangeMax.Tag = "bear";
            this.bearRangeMax.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.bearRangeMax.ValueChanged += new System.EventHandler(this.bearRangeMax_ValueChanged);
            // 
            // tpOptions
            // 
            this.tpOptions.BackColor = System.Drawing.SystemColors.Control;
            this.tpOptions.Controls.Add(this.gbCloseOptions);
            this.tpOptions.Controls.Add(this.gbOpenOption);
            this.tpOptions.Location = new System.Drawing.Point(4, 24);
            this.tpOptions.Name = "tpOptions";
            this.tpOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tpOptions.Size = new System.Drawing.Size(247, 242);
            this.tpOptions.TabIndex = 0;
            this.tpOptions.Text = "Options";
            // 
            // gbCloseOptions
            // 
            this.gbCloseOptions.Controls.Add(this.cboCloseOption);
            this.gbCloseOptions.Controls.Add(this.lblCloseOptionHelp);
            this.gbCloseOptions.Location = new System.Drawing.Point(8, 103);
            this.gbCloseOptions.Name = "gbCloseOptions";
            this.gbCloseOptions.Size = new System.Drawing.Size(220, 75);
            this.gbCloseOptions.TabIndex = 114;
            this.gbCloseOptions.TabStop = false;
            this.gbCloseOptions.Text = "Close Options:";
            // 
            // lblCloseOptionHelp
            // 
            this.lblCloseOptionHelp.AutoSize = true;
            this.lblCloseOptionHelp.Location = new System.Drawing.Point(10, 40);
            this.lblCloseOptionHelp.Name = "lblCloseOptionHelp";
            this.lblCloseOptionHelp.Size = new System.Drawing.Size(203, 28);
            this.lblCloseOptionHelp.TabIndex = 112;
            this.lblCloseOptionHelp.Text = "TickThru price exceeds range\r\nOnTouch price prints range";
            // 
            // gbOpenOption
            // 
            this.gbOpenOption.Controls.Add(this.cboOpenOption);
            this.gbOpenOption.Controls.Add(this.lblOpenOptionHelp);
            this.gbOpenOption.Location = new System.Drawing.Point(8, 11);
            this.gbOpenOption.Name = "gbOpenOption";
            this.gbOpenOption.Size = new System.Drawing.Size(220, 75);
            this.gbOpenOption.TabIndex = 113;
            this.gbOpenOption.TabStop = false;
            this.gbOpenOption.Text = "Open Options:";
            // 
            // lblOpenOptionHelp
            // 
            this.lblOpenOptionHelp.AutoSize = true;
            this.lblOpenOptionHelp.Location = new System.Drawing.Point(10, 41);
            this.lblOpenOptionHelp.Name = "lblOpenOptionHelp";
            this.lblOpenOptionHelp.Size = new System.Drawing.Size(189, 28);
            this.lblOpenOptionHelp.TabIndex = 111;
            this.lblOpenOptionHelp.Text = "TrueOpen uses actual price\r\nNoGap uses previous close";
            // 
            // tpHelp
            // 
            this.tpHelp.BackColor = System.Drawing.SystemColors.Control;
            this.tpHelp.Controls.Add(this.helpBuild);
            this.tpHelp.Controls.Add(this.helpText);
            this.tpHelp.Controls.Add(this.linkHelpFAQ);
            this.tpHelp.Controls.Add(this.linkHelpLicense);
            this.tpHelp.Controls.Add(this.linkHelpContact);
            this.tpHelp.Controls.Add(this.linkHelpVideo);
            this.tpHelp.Controls.Add(this.lblExpirationMessage);
            this.tpHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpHelp.Location = new System.Drawing.Point(4, 24);
            this.tpHelp.Name = "tpHelp";
            this.tpHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tpHelp.Size = new System.Drawing.Size(247, 242);
            this.tpHelp.TabIndex = 5;
            this.tpHelp.Text = "Help";
            // 
            // helpBuild
            // 
            this.helpBuild.AutoSize = true;
            this.helpBuild.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.helpBuild.Location = new System.Drawing.Point(10, 17);
            this.helpBuild.Name = "helpBuild";
            this.helpBuild.Size = new System.Drawing.Size(105, 14);
            this.helpBuild.TabIndex = 127;
            this.helpBuild.Text = "--build-info--";
            // 
            // helpText
            // 
            this.helpText.Location = new System.Drawing.Point(14, 47);
            this.helpText.Name = "helpText";
            this.helpText.Size = new System.Drawing.Size(220, 30);
            this.helpText.TabIndex = 126;
            this.helpText.Text = "To learn more about EmBars, please click on these links:";
            // 
            // linkHelpFAQ
            // 
            this.linkHelpFAQ.AutoSize = true;
            this.linkHelpFAQ.Location = new System.Drawing.Point(14, 93);
            this.linkHelpFAQ.Name = "linkHelpFAQ";
            this.linkHelpFAQ.Size = new System.Drawing.Size(56, 14);
            this.linkHelpFAQ.TabIndex = 124;
            this.linkHelpFAQ.TabStop = true;
            this.linkHelpFAQ.Text = "Support";
            this.linkHelpFAQ.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHelpFAQ_LinkClicked);
            // 
            // linkHelpLicense
            // 
            this.linkHelpLicense.AutoSize = true;
            this.linkHelpLicense.Location = new System.Drawing.Point(14, 183);
            this.linkHelpLicense.Name = "linkHelpLicense";
            this.linkHelpLicense.Size = new System.Drawing.Size(56, 14);
            this.linkHelpLicense.TabIndex = 3;
            this.linkHelpLicense.TabStop = true;
            this.linkHelpLicense.Text = "License";
            this.linkHelpLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHelpLicense_LinkClicked);
            // 
            // linkHelpContact
            // 
            this.linkHelpContact.AutoSize = true;
            this.linkHelpContact.Location = new System.Drawing.Point(14, 153);
            this.linkHelpContact.Name = "linkHelpContact";
            this.linkHelpContact.Size = new System.Drawing.Size(56, 14);
            this.linkHelpContact.TabIndex = 1;
            this.linkHelpContact.TabStop = true;
            this.linkHelpContact.Text = "Contact";
            this.linkHelpContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHelpContact_LinkClicked);
            // 
            // linkHelpVideo
            // 
            this.linkHelpVideo.AutoSize = true;
            this.linkHelpVideo.Location = new System.Drawing.Point(14, 123);
            this.linkHelpVideo.Name = "linkHelpVideo";
            this.linkHelpVideo.Size = new System.Drawing.Size(49, 14);
            this.linkHelpVideo.TabIndex = 0;
            this.linkHelpVideo.TabStop = true;
            this.linkHelpVideo.Text = "Videos";
            this.linkHelpVideo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHelpVideo_LinkClicked);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(284, 442);
            this.ControlBox = false;
            this.Controls.Add(this.tcConfig);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblConfig);
            this.Controls.Add(this.lblBuildMessage);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblStatusMessage);
            this.Controls.Add(this.btnSaveAs);
            this.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.MinimumSize = new System.Drawing.Size(300, 458);
            this.Name = "ConfigForm";
            this.Opacity = 0.9D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EmBars";
            ((System.ComponentModel.ISupportInitialize)(this.bullRangeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bullRangeMin)).EndInit();
            this.tcConfig.ResumeLayout(false);
            this.tpBull.ResumeLayout(false);
            this.gbBullLinks.ResumeLayout(false);
            this.gbBullLinks.PerformLayout();
            this.gbBullCont.ResumeLayout(false);
            this.gbBullCont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bullContValue)).EndInit();
            this.gbBullInit.ResumeLayout(false);
            this.gbBullInit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bullInitValue)).EndInit();
            this.tpBear.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbContinuationBear.ResumeLayout(false);
            this.gbContinuationBear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bearContValue)).EndInit();
            this.gbInitializationBear.ResumeLayout(false);
            this.gbInitializationBear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bearInitValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bearRangeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bearRangeMax)).EndInit();
            this.tpOptions.ResumeLayout(false);
            this.gbCloseOptions.ResumeLayout(false);
            this.gbCloseOptions.PerformLayout();
            this.gbOpenOption.ResumeLayout(false);
            this.gbOpenOption.PerformLayout();
            this.tpHelp.ResumeLayout(false);
            this.tpHelp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        System.Windows.Forms.OpenFileDialog dialogOpen;
        System.Windows.Forms.Label lblExpirationMessage;
        System.Windows.Forms.Label lblConfig;
        System.Windows.Forms.Button btnOpen;
        System.Windows.Forms.SaveFileDialog ctlSaveFileDialog;
        System.Windows.Forms.Label lblStatusMessage;
        System.Windows.Forms.Button btnSaveAs;
        System.Windows.Forms.NumericUpDown bullRangeMax;
        System.Windows.Forms.NumericUpDown bullRangeMin;
        System.Windows.Forms.ComboBox cboCloseOption;
        System.Windows.Forms.ComboBox cboOpenOption;
        System.Windows.Forms.Button btnApply;
        System.Windows.Forms.Button btnClose;
        System.Windows.Forms.Label lblTitle;
        System.Windows.Forms.Button btnSave;
        System.Windows.Forms.Button btnReset;
        System.Windows.Forms.Label lblBuildMessage;
        System.Windows.Forms.TabControl tcConfig;
        System.Windows.Forms.TabPage tpOptions;
        System.Windows.Forms.TabPage tpBull;
        System.Windows.Forms.NumericUpDown bullInitValue;
        System.Windows.Forms.TabPage tpBear;
        System.Windows.Forms.TabPage tpHelp;
        System.Windows.Forms.GroupBox gbBullInit;
        System.Windows.Forms.GroupBox gbBullCont;
        System.Windows.Forms.NumericUpDown bullContValue;
        System.Windows.Forms.RadioButton bullInitPrev;
        System.Windows.Forms.RadioButton bullInitMax;
        System.Windows.Forms.RadioButton bullInitMin;
        System.Windows.Forms.GroupBox gbInitializationBear;
        System.Windows.Forms.RadioButton bearInitPrev;
        System.Windows.Forms.RadioButton bearInitMax;
        System.Windows.Forms.NumericUpDown bearInitValue;
        System.Windows.Forms.RadioButton bearInitMin;
        System.Windows.Forms.NumericUpDown bearRangeMin;
        System.Windows.Forms.NumericUpDown bearRangeMax;
        System.Windows.Forms.LinkLabel linkHelpContact;
        System.Windows.Forms.LinkLabel linkHelpVideo;
        System.Windows.Forms.LinkLabel linkHelpLicense;
        System.Windows.Forms.GroupBox gbContinuationBear;
        System.Windows.Forms.NumericUpDown bearContValue;
        System.Windows.Forms.Label lblBullContinuePrev;
        System.Windows.Forms.Label lblBearContinuePrev;
        System.Windows.Forms.Label lblCloseOptionHelp;
        System.Windows.Forms.Label lblOpenOptionHelp;
        System.Windows.Forms.GroupBox gbOpenOption;
        System.Windows.Forms.GroupBox gbCloseOptions;
        System.Windows.Forms.LinkLabel linkHelpFAQ;
        System.Windows.Forms.GroupBox gbBullLinks;
        System.Windows.Forms.LinkLabel bullLinkContract;
        System.Windows.Forms.LinkLabel bullLinkExpand;
        System.Windows.Forms.LinkLabel bullLinkFixed;
        System.Windows.Forms.GroupBox groupBox1;
        System.Windows.Forms.LinkLabel bearLinkContract;
        System.Windows.Forms.LinkLabel bearLinkExpand;
        System.Windows.Forms.LinkLabel bearLinkFixed;
        private System.Windows.Forms.Label helpText;
        private System.Windows.Forms.Label helpBuild;
    }
}