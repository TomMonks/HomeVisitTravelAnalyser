namespace CommunityNurseTravelAnalyser.UI
{
    partial class ResultsComparisonPanel
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
            this.localityResultsPanel2 = new CommunityNurseTravelAnalyser.UI.LocalityResultsPanel();
            this.localityResultsPanel1 = new CommunityNurseTravelAnalyser.UI.LocalityResultsPanel();
            this.SuspendLayout();
            // 
            // localityResultsPanel2
            // 
            this.localityResultsPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localityResultsPanel2.Location = new System.Drawing.Point(3, 263);
            this.localityResultsPanel2.Name = "localityResultsPanel2";
            this.localityResultsPanel2.ResultsGroupName = "Patients allocated by GP postcode";
            this.localityResultsPanel2.Size = new System.Drawing.Size(638, 265);
            this.localityResultsPanel2.TabIndex = 1;
            // 
            // localityResultsPanel1
            // 
            this.localityResultsPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localityResultsPanel1.Location = new System.Drawing.Point(3, 3);
            this.localityResultsPanel1.Name = "localityResultsPanel1";
            this.localityResultsPanel1.ResultsGroupName = "Patients allocated by home postcode";
            this.localityResultsPanel1.Size = new System.Drawing.Size(638, 265);
            this.localityResultsPanel1.TabIndex = 0;
            // 
            // ResultsComparisonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.localityResultsPanel2);
            this.Controls.Add(this.localityResultsPanel1);
            this.Name = "ResultsComparisonPanel";
            this.Size = new System.Drawing.Size(641, 532);
            this.ResumeLayout(false);

        }

        #endregion

        private LocalityResultsPanel localityResultsPanel1;
        private LocalityResultsPanel localityResultsPanel2;
    }
}
