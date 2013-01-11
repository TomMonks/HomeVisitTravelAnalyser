namespace CommunityNurseTravelAnalyser.UI
{
    partial class ResultsPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportResultsToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meanDifferenceConfidenceIntervalPanel1 = new CommunityNurseTravelAnalyser.UI.MeanDifferenceConfidenceIntervalPanel();
            this.allocationResultsPanel1 = new CommunityNurseTravelAnalyser.UI.AllocationResultsPanel();
            this.comparisonByChartPanel1 = new CommunityNurseTravelAnalyser.UI.ComparisonByChartPanel();
            this.resultsComparisonPanel1 = new CommunityNurseTravelAnalyser.UI.ResultsComparisonPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportResultsToExcelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(188, 48);
            // 
            // exportResultsToExcelToolStripMenuItem
            // 
            this.exportResultsToExcelToolStripMenuItem.Image = global::CommunityNurseTravelAnalyser.Properties.Resources.excel;
            this.exportResultsToExcelToolStripMenuItem.Name = "exportResultsToExcelToolStripMenuItem";
            this.exportResultsToExcelToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exportResultsToExcelToolStripMenuItem.Text = "Export results to Excel";
            this.exportResultsToExcelToolStripMenuItem.Click += new System.EventHandler(this.ExportResultsToExcelToolStripMenuItemClick);
            // 
            // meanDifferenceConfidenceIntervalPanel1
            // 
            this.meanDifferenceConfidenceIntervalPanel1.Location = new System.Drawing.Point(3, 122);
            this.meanDifferenceConfidenceIntervalPanel1.Name = "meanDifferenceConfidenceIntervalPanel1";
            this.meanDifferenceConfidenceIntervalPanel1.Size = new System.Drawing.Size(497, 97);
            this.meanDifferenceConfidenceIntervalPanel1.TabIndex = 3;
            // 
            // allocationResultsPanel1
            // 
            this.allocationResultsPanel1.Location = new System.Drawing.Point(3, 3);
            this.allocationResultsPanel1.Name = "allocationResultsPanel1";
            this.allocationResultsPanel1.Size = new System.Drawing.Size(497, 113);
            this.allocationResultsPanel1.TabIndex = 2;
            // 
            // comparisonByChartPanel1
            // 
            this.comparisonByChartPanel1.Location = new System.Drawing.Point(8, 225);
            this.comparisonByChartPanel1.Name = "comparisonByChartPanel1";
            this.comparisonByChartPanel1.Size = new System.Drawing.Size(492, 291);
            this.comparisonByChartPanel1.TabIndex = 1;
            // 
            // resultsComparisonPanel1
            // 
            this.resultsComparisonPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsComparisonPanel1.Location = new System.Drawing.Point(501, 3);
            this.resultsComparisonPanel1.Name = "resultsComparisonPanel1";
            this.resultsComparisonPanel1.Size = new System.Drawing.Size(573, 532);
            this.resultsComparisonPanel1.TabIndex = 0;
            // 
            // ResultsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.meanDifferenceConfidenceIntervalPanel1);
            this.Controls.Add(this.allocationResultsPanel1);
            this.Controls.Add(this.comparisonByChartPanel1);
            this.Controls.Add(this.resultsComparisonPanel1);
            this.Name = "ResultsPanel";
            this.Size = new System.Drawing.Size(1077, 527);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ToolStripMenuItem exportResultsToExcelToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

        #endregion

        private ResultsComparisonPanel resultsComparisonPanel1;
        private ComparisonByChartPanel comparisonByChartPanel1;
        private AllocationResultsPanel allocationResultsPanel1;
        private MeanDifferenceConfidenceIntervalPanel meanDifferenceConfidenceIntervalPanel1;

    }
}
