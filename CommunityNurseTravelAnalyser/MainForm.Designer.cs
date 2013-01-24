namespace HomeVisitTravelAnalyser
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
            this.tabControl1 = new CustomGUI.ExtendedTabControl();
            this.tp_AnalysisOptions = new System.Windows.Forms.TabPage();
            this.analysisOptionPanel1 = new HomeVisitTravelAnalyser.UI.AnalysisOptionPanel();
            this.tp_HomeConfig = new System.Windows.Forms.TabPage();
            this.localityQuerySetupPanel1 = new HomeVisitTravelAnalyser.UI.LocalityQuerySetupPanel();
            this.tp_GPConfig = new System.Windows.Forms.TabPage();
            this.localityQuerySetupPanel2 = new HomeVisitTravelAnalyser.UI.LocalityQuerySetupPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.homePostcodeConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gPAllocationConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tp_AnalysisOptions.SuspendLayout();
            this.tp_HomeConfig.SuspendLayout();
            this.tp_GPConfig.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tp_AnalysisOptions);
            this.tabControl1.Controls.Add(this.tp_HomeConfig);
            this.tabControl1.Controls.Add(this.tp_GPConfig);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1036, 540);
            this.tabControl1.TabIndex = 13;
            // 
            // tp_AnalysisOptions
            // 
            this.tp_AnalysisOptions.Controls.Add(this.analysisOptionPanel1);
            this.tp_AnalysisOptions.ImageIndex = 0;
            this.tp_AnalysisOptions.Location = new System.Drawing.Point(4, 23);
            this.tp_AnalysisOptions.Name = "tp_AnalysisOptions";
            this.tp_AnalysisOptions.Size = new System.Drawing.Size(1028, 513);
            this.tp_AnalysisOptions.TabIndex = 2;
            this.tp_AnalysisOptions.Text = "Analysis Options";
            this.tp_AnalysisOptions.UseVisualStyleBackColor = true;
            // 
            // analysisOptionPanel1
            // 
            this.analysisOptionPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisOptionPanel1.AutoScroll = true;
            this.analysisOptionPanel1.Location = new System.Drawing.Point(8, 3);
            this.analysisOptionPanel1.Name = "analysisOptionPanel1";
            this.analysisOptionPanel1.Size = new System.Drawing.Size(1017, 507);
            this.analysisOptionPanel1.TabIndex = 0;
            // 
            // tp_HomeConfig
            // 
            this.tp_HomeConfig.Controls.Add(this.localityQuerySetupPanel1);
            this.tp_HomeConfig.ImageIndex = 1;
            this.tp_HomeConfig.Location = new System.Drawing.Point(4, 23);
            this.tp_HomeConfig.Name = "tp_HomeConfig";
            this.tp_HomeConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tp_HomeConfig.Size = new System.Drawing.Size(1028, 513);
            this.tp_HomeConfig.TabIndex = 0;
            this.tp_HomeConfig.Text = "Home Locality Settings";
            this.tp_HomeConfig.UseVisualStyleBackColor = true;
            // 
            // localityQuerySetupPanel1
            // 
            this.localityQuerySetupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localityQuerySetupPanel1.AutoScroll = true;
            this.localityQuerySetupPanel1.FieldMappings = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("localityQuerySetupPanel1.FieldMappings")));
            this.localityQuerySetupPanel1.FromDate = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            this.localityQuerySetupPanel1.Location = new System.Drawing.Point(8, 6);
            this.localityQuerySetupPanel1.Name = "localityQuerySetupPanel1";
            this.localityQuerySetupPanel1.Size = new System.Drawing.Size(1014, 499);
            this.localityQuerySetupPanel1.TabIndex = 1;
            this.localityQuerySetupPanel1.ToDate = new System.DateTime(2012, 8, 31, 0, 0, 0, 0);
            // 
            // tp_GPConfig
            // 
            this.tp_GPConfig.Controls.Add(this.localityQuerySetupPanel2);
            this.tp_GPConfig.ImageIndex = 1;
            this.tp_GPConfig.Location = new System.Drawing.Point(4, 23);
            this.tp_GPConfig.Name = "tp_GPConfig";
            this.tp_GPConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tp_GPConfig.Size = new System.Drawing.Size(1028, 513);
            this.tp_GPConfig.TabIndex = 1;
            this.tp_GPConfig.Text = "GP Locality Settings";
            this.tp_GPConfig.UseVisualStyleBackColor = true;
            // 
            // localityQuerySetupPanel2
            // 
            this.localityQuerySetupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localityQuerySetupPanel2.AutoScroll = true;
            this.localityQuerySetupPanel2.FieldMappings = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("localityQuerySetupPanel2.FieldMappings")));
            this.localityQuerySetupPanel2.FromDate = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            this.localityQuerySetupPanel2.Location = new System.Drawing.Point(8, 6);
            this.localityQuerySetupPanel2.Name = "localityQuerySetupPanel2";
            this.localityQuerySetupPanel2.Size = new System.Drawing.Size(1014, 499);
            this.localityQuerySetupPanel2.TabIndex = 1;
            this.localityQuerySetupPanel2.ToDate = new System.DateTime(2012, 8, 31, 0, 0, 0, 0);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "sprocket_dark.png");
            this.imageList1.Images.SetKeyName(1, "pin.png");
            this.imageList1.Images.SetKeyName(2, "dialog_cancel.ico");
            this.imageList1.Images.SetKeyName(3, "chart_bar.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1041, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runAnalysisToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // runAnalysisToolStripMenuItem
            // 
            this.runAnalysisToolStripMenuItem.Name = "runAnalysisToolStripMenuItem";
            this.runAnalysisToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.runAnalysisToolStripMenuItem.Text = "Run Analysis";
            this.runAnalysisToolStripMenuItem.Click += new System.EventHandler(this.runAnalysisToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analysisOptionsToolStripMenuItem,
            this.toolStripSeparator2,
            this.homePostcodeConfigToolStripMenuItem,
            this.gPAllocationConfigToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // analysisOptionsToolStripMenuItem
            // 
            this.analysisOptionsToolStripMenuItem.Name = "analysisOptionsToolStripMenuItem";
            this.analysisOptionsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.analysisOptionsToolStripMenuItem.Text = "Options";
            this.analysisOptionsToolStripMenuItem.Click += new System.EventHandler(this.analysisOptionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // homePostcodeConfigToolStripMenuItem
            // 
            this.homePostcodeConfigToolStripMenuItem.Name = "homePostcodeConfigToolStripMenuItem";
            this.homePostcodeConfigToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.homePostcodeConfigToolStripMenuItem.Text = "Home allocation config";
            this.homePostcodeConfigToolStripMenuItem.Click += new System.EventHandler(this.homePostcodeConfigToolStripMenuItem_Click);
            // 
            // gPAllocationConfigToolStripMenuItem
            // 
            this.gPAllocationConfigToolStripMenuItem.Name = "gPAllocationConfigToolStripMenuItem";
            this.gPAllocationConfigToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.gPAllocationConfigToolStripMenuItem.Text = "GP allocation config";
            this.gPAllocationConfigToolStripMenuItem.Click += new System.EventHandler(this.gPAllocationConfigToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.aboutToolStripMenuItem.Text = "About Community Nurse Travel Analyser";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1041, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::HomeVisitTravelAnalyser.Properties.Resources.play_green;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Run analysis with selected options";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::HomeVisitTravelAnalyser.Properties.Resources.dialog_cancel;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Exit Community Nurse Travel Analyser";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 592);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Home Visit Travel Analyser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tp_AnalysisOptions.ResumeLayout(false);
            this.tp_HomeConfig.ResumeLayout(false);
            this.tp_GPConfig.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private CustomGUI.ExtendedTabControl tabControl1;
        private System.Windows.Forms.TabPage tp_GPConfig;
        private System.Windows.Forms.TabPage tp_HomeConfig;
        private HomeVisitTravelAnalyser.UI.LocalityQuerySetupPanel localityQuerySetupPanel1;
        private HomeVisitTravelAnalyser.UI.LocalityQuerySetupPanel localityQuerySetupPanel2;
        private System.Windows.Forms.TabPage tp_AnalysisOptions;
        private HomeVisitTravelAnalyser.UI.AnalysisOptionPanel analysisOptionPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem homePostcodeConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gPAllocationConfigToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;

    }
}

