namespace HomeVisitTravelAnalyser.UI
{
    partial class AnalysisOptionPanel
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
            this.chk_Dispersion = new System.Windows.Forms.CheckBox();
            this.chk_Distance = new System.Windows.Forms.CheckBox();
            this.grp_TSP = new System.Windows.Forms.GroupBox();
            this.grp_baseOptions = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rb_baseRandom = new System.Windows.Forms.RadioButton();
            this.rb_baseCentroid = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_seed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_samples = new System.Windows.Forms.TextBox();
            this.grp_search = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.rd_steepestdecent = new System.Windows.Forms.RadioButton();
            this.rd_ordinarydecent = new System.Windows.Forms.RadioButton();
            this.lbl_cities = new System.Windows.Forms.Label();
            this.txt_cities = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_centroidDay = new System.Windows.Forms.RadioButton();
            this.rd_centroidAll = new System.Windows.Forms.RadioButton();
            this.grp_TSP.SuspendLayout();
            this.grp_baseOptions.SuspendLayout();
            this.grp_search.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chk_Dispersion
            // 
            this.chk_Dispersion.AutoSize = true;
            this.chk_Dispersion.Location = new System.Drawing.Point(13, 44);
            this.chk_Dispersion.Name = "chk_Dispersion";
            this.chk_Dispersion.Size = new System.Drawing.Size(133, 17);
            this.chk_Dispersion.TabIndex = 0;
            this.chk_Dispersion.Text = "Distance from Centroid";
            this.chk_Dispersion.UseVisualStyleBackColor = true;
            this.chk_Dispersion.CheckedChanged += new System.EventHandler(this.chk_Dispersion_CheckedChanged);
            // 
            // chk_Distance
            // 
            this.chk_Distance.AutoSize = true;
            this.chk_Distance.Location = new System.Drawing.Point(13, 67);
            this.chk_Distance.Name = "chk_Distance";
            this.chk_Distance.Size = new System.Drawing.Size(160, 17);
            this.chk_Distance.TabIndex = 1;
            this.chk_Distance.Text = "Traveling Salesman Analysis";
            this.chk_Distance.UseVisualStyleBackColor = true;
            this.chk_Distance.CheckedChanged += new System.EventHandler(this.chk_Distance_CheckedChanged);
            // 
            // grp_TSP
            // 
            this.grp_TSP.Controls.Add(this.grp_baseOptions);
            this.grp_TSP.Controls.Add(this.label3);
            this.grp_TSP.Controls.Add(this.txt_seed);
            this.grp_TSP.Controls.Add(this.label1);
            this.grp_TSP.Controls.Add(this.txt_samples);
            this.grp_TSP.Controls.Add(this.grp_search);
            this.grp_TSP.Controls.Add(this.lbl_cities);
            this.grp_TSP.Controls.Add(this.txt_cities);
            this.grp_TSP.Enabled = false;
            this.grp_TSP.Location = new System.Drawing.Point(402, 15);
            this.grp_TSP.Name = "grp_TSP";
            this.grp_TSP.Size = new System.Drawing.Size(528, 377);
            this.grp_TSP.TabIndex = 2;
            this.grp_TSP.TabStop = false;
            this.grp_TSP.Text = "Travelling Salesment Options";
            // 
            // grp_baseOptions
            // 
            this.grp_baseOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_baseOptions.Controls.Add(this.radioButton2);
            this.grp_baseOptions.Controls.Add(this.rb_baseRandom);
            this.grp_baseOptions.Controls.Add(this.rb_baseCentroid);
            this.grp_baseOptions.Location = new System.Drawing.Point(265, 11);
            this.grp_baseOptions.Name = "grp_baseOptions";
            this.grp_baseOptions.Size = new System.Drawing.Size(245, 100);
            this.grp_baseOptions.TabIndex = 7;
            this.grp_baseOptions.TabStop = false;
            this.grp_baseOptions.Text = "Base Options";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 67);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Locality Hub ";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // rb_baseRandom
            // 
            this.rb_baseRandom.AutoSize = true;
            this.rb_baseRandom.Location = new System.Drawing.Point(16, 44);
            this.rb_baseRandom.Name = "rb_baseRandom";
            this.rb_baseRandom.Size = new System.Drawing.Size(130, 17);
            this.rb_baseRandom.TabIndex = 1;
            this.rb_baseRandom.Text = "Random within locality";
            this.rb_baseRandom.UseVisualStyleBackColor = true;
            // 
            // rb_baseCentroid
            // 
            this.rb_baseCentroid.AutoSize = true;
            this.rb_baseCentroid.Checked = true;
            this.rb_baseCentroid.Location = new System.Drawing.Point(16, 22);
            this.rb_baseCentroid.Name = "rb_baseCentroid";
            this.rb_baseCentroid.Size = new System.Drawing.Size(102, 17);
            this.rb_baseCentroid.TabIndex = 0;
            this.rb_baseCentroid.TabStop = true;
            this.rb_baseCentroid.Text = "Locality centroid";
            this.rb_baseCentroid.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Random seed";
            // 
            // txt_seed
            // 
            this.txt_seed.Location = new System.Drawing.Point(137, 82);
            this.txt_seed.Name = "txt_seed";
            this.txt_seed.Size = new System.Drawing.Size(100, 20);
            this.txt_seed.TabIndex = 5;
            this.txt_seed.Text = "999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Samples per locality";
            // 
            // txt_samples
            // 
            this.txt_samples.Location = new System.Drawing.Point(137, 56);
            this.txt_samples.Name = "txt_samples";
            this.txt_samples.Size = new System.Drawing.Size(100, 20);
            this.txt_samples.TabIndex = 3;
            this.txt_samples.Text = "50";
            // 
            // grp_search
            // 
            this.grp_search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_search.Controls.Add(this.radioButton1);
            this.grp_search.Controls.Add(this.richTextBox1);
            this.grp_search.Controls.Add(this.rd_steepestdecent);
            this.grp_search.Controls.Add(this.rd_ordinarydecent);
            this.grp_search.Location = new System.Drawing.Point(19, 117);
            this.grp_search.Name = "grp_search";
            this.grp_search.Size = new System.Drawing.Size(491, 235);
            this.grp_search.TabIndex = 2;
            this.grp_search.TabStop = false;
            this.grp_search.Text = "Local Search Strategy";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 79);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(143, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.Text = "Brute Force (all solutions)";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(237, 33);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(248, 196);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // rd_steepestdecent
            // 
            this.rd_steepestdecent.AutoSize = true;
            this.rd_steepestdecent.Location = new System.Drawing.Point(17, 56);
            this.rd_steepestdecent.Name = "rd_steepestdecent";
            this.rd_steepestdecent.Size = new System.Drawing.Size(105, 17);
            this.rd_steepestdecent.TabIndex = 1;
            this.rd_steepestdecent.Text = "Steepest Decent";
            this.rd_steepestdecent.UseVisualStyleBackColor = true;
            // 
            // rd_ordinarydecent
            // 
            this.rd_ordinarydecent.AutoSize = true;
            this.rd_ordinarydecent.Checked = true;
            this.rd_ordinarydecent.Location = new System.Drawing.Point(17, 33);
            this.rd_ordinarydecent.Name = "rd_ordinarydecent";
            this.rd_ordinarydecent.Size = new System.Drawing.Size(194, 17);
            this.rd_ordinarydecent.TabIndex = 0;
            this.rd_ordinarydecent.TabStop = true;
            this.rd_ordinarydecent.Text = "Ordinary Decent (First Improvement)";
            this.rd_ordinarydecent.UseVisualStyleBackColor = true;
            this.rd_ordinarydecent.CheckedChanged += new System.EventHandler(this.rd_ordinarydecent_CheckedChanged);
            // 
            // lbl_cities
            // 
            this.lbl_cities.AutoSize = true;
            this.lbl_cities.Location = new System.Drawing.Point(16, 33);
            this.lbl_cities.Name = "lbl_cities";
            this.lbl_cities.Size = new System.Drawing.Size(61, 13);
            this.lbl_cities.TabIndex = 1;
            this.lbl_cities.Text = "Tour length";
            // 
            // txt_cities
            // 
            this.txt_cities.Location = new System.Drawing.Point(137, 30);
            this.txt_cities.Name = "txt_cities";
            this.txt_cities.Size = new System.Drawing.Size(100, 20);
            this.txt_cities.TabIndex = 0;
            this.txt_cities.Text = "8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Analysis will be run for all locations";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_centroidDay);
            this.groupBox1.Controls.Add(this.rd_centroidAll);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(194, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 377);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Centroid Analysis Options";
            // 
            // rd_centroidDay
            // 
            this.rd_centroidDay.AutoSize = true;
            this.rd_centroidDay.Location = new System.Drawing.Point(16, 56);
            this.rd_centroidDay.Name = "rd_centroidDay";
            this.rd_centroidDay.Size = new System.Drawing.Size(161, 17);
            this.rd_centroidDay.TabIndex = 1;
            this.rd_centroidDay.Text = "Process each day seperately";
            this.rd_centroidDay.UseVisualStyleBackColor = true;
            // 
            // rd_centroidAll
            // 
            this.rd_centroidAll.AutoSize = true;
            this.rd_centroidAll.Checked = true;
            this.rd_centroidAll.Location = new System.Drawing.Point(16, 32);
            this.rd_centroidAll.Name = "rd_centroidAll";
            this.rd_centroidAll.Size = new System.Drawing.Size(115, 17);
            this.rd_centroidAll.TabIndex = 0;
            this.rd_centroidAll.TabStop = true;
            this.rd_centroidAll.Text = "Locality as a whole";
            this.rd_centroidAll.UseVisualStyleBackColor = true;
            // 
            // AnalysisOptionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grp_TSP);
            this.Controls.Add(this.chk_Distance);
            this.Controls.Add(this.chk_Dispersion);
            this.Name = "AnalysisOptionPanel";
            this.Size = new System.Drawing.Size(937, 401);
            this.Load += new System.EventHandler(this.AnalysisOptionPanel_Load);
            this.grp_TSP.ResumeLayout(false);
            this.grp_TSP.PerformLayout();
            this.grp_baseOptions.ResumeLayout(false);
            this.grp_baseOptions.PerformLayout();
            this.grp_search.ResumeLayout(false);
            this.grp_search.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_Dispersion;
        private System.Windows.Forms.CheckBox chk_Distance;
        private System.Windows.Forms.GroupBox grp_TSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_samples;
        private System.Windows.Forms.GroupBox grp_search;
        private System.Windows.Forms.RadioButton rd_steepestdecent;
        private System.Windows.Forms.RadioButton rd_ordinarydecent;
        private System.Windows.Forms.Label lbl_cities;
        private System.Windows.Forms.TextBox txt_cities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_seed;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rd_centroidDay;
        private System.Windows.Forms.RadioButton rd_centroidAll;
        private System.Windows.Forms.GroupBox grp_baseOptions;
        private System.Windows.Forms.RadioButton rb_baseRandom;
        private System.Windows.Forms.RadioButton rb_baseCentroid;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}
