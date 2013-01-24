namespace HomeVisitTravelAnalyser.UI
{
    partial class LocalityQuerySetupPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalityQuerySetupPanel));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Easting");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Northing");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Date");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Central/North East");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("North West");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Plympton/Plymstock");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("South East");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("South West");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "Date",
            "Date"}, -1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "Locality",
            "Locality"}, -1);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "Easting",
            "Easting"}, -1);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            "Northing",
            "Northing"}, -1);
            this.label6 = new System.Windows.Forms.Label();
            this.txt_DateFieldName = new System.Windows.Forms.TextBox();
            this.txtFile = new CustomGUI.RecentFileTextBox();
            this.recentFilesMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lvw_Locality = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lvw_mappings = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_file = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.hubQuerySetupPanel1 = new HomeVisitTravelAnalyser.UI.HubQuerySetupPanel();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Date Field Name";
            // 
            // txt_DateFieldName
            // 
            this.txt_DateFieldName.Location = new System.Drawing.Point(162, 66);
            this.txt_DateFieldName.Name = "txt_DateFieldName";
            this.txt_DateFieldName.Size = new System.Drawing.Size(575, 20);
            this.txt_DateFieldName.TabIndex = 29;
            this.txt_DateFieldName.Text = "Date";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(162, 14);
            this.txtFile.Name = "txtFile";
            this.txtFile.RecentFiles = ((System.Collections.Generic.List<string>)(resources.GetObject("txtFile.RecentFiles")));
            this.txtFile.Size = new System.Drawing.Size(548, 20);
            this.txtFile.TabIndex = 17;
            this.txtFile.Text = "C:\\Plymouth\\CommunityNurse.accdb";
            // 
            // recentFilesMenuStrip
            // 
            this.recentFilesMenuStrip.Name = "lastMenuStrip";
            this.recentFilesMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Selected Fields";
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(162, 40);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(575, 20);
            this.txtTable.TabIndex = 19;
            this.txtTable.Text = "HomeVisits";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView1.Location = new System.Drawing.Point(162, 269);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(575, 112);
            this.listView1.TabIndex = 25;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "FieldName";
            this.columnHeader1.Width = 555;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "MS Access file";
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(162, 233);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(575, 20);
            this.dateTo.TabIndex = 24;
            this.dateTo.Value = new System.DateTime(2012, 8, 31, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Table";
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(162, 207);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(575, 20);
            this.dateFrom.TabIndex = 23;
            this.dateFrom.Value = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "From";
            // 
            // lvw_Locality
            // 
            this.lvw_Locality.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvw_Locality.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.lvw_Locality.Location = new System.Drawing.Point(162, 396);
            this.lvw_Locality.Name = "lvw_Locality";
            this.lvw_Locality.Size = new System.Drawing.Size(575, 144);
            this.lvw_Locality.TabIndex = 31;
            this.lvw_Locality.UseCompatibleStateImageBehavior = false;
            this.lvw_Locality.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Locality";
            this.columnHeader2.Width = 555;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 396);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Selected Localities";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Database Field Mappings";
            // 
            // lvw_mappings
            // 
            this.lvw_mappings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvw_mappings.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12});
            this.lvw_mappings.Location = new System.Drawing.Point(162, 92);
            this.lvw_mappings.Name = "lvw_mappings";
            this.lvw_mappings.Size = new System.Drawing.Size(575, 109);
            this.lvw_mappings.TabIndex = 37;
            this.lvw_mappings.UseCompatibleStateImageBehavior = false;
            this.lvw_mappings.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Field";
            this.columnHeader3.Width = 165;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "FieldName";
            this.columnHeader4.Width = 238;
            // 
            // bt_file
            // 
            this.bt_file.Location = new System.Drawing.Point(717, 14);
            this.bt_file.Name = "bt_file";
            this.bt_file.Size = new System.Drawing.Size(20, 23);
            this.bt_file.TabIndex = 38;
            this.bt_file.Text = "...";
            this.bt_file.UseVisualStyleBackColor = true;
            this.bt_file.Click += new System.EventHandler(this.bt_file_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // hubQuerySetupPanel1
            // 
            this.hubQuerySetupPanel1.DatabasePath = null;
            this.hubQuerySetupPanel1.Location = new System.Drawing.Point(3, 554);
            this.hubQuerySetupPanel1.Name = "hubQuerySetupPanel1";
            this.hubQuerySetupPanel1.SelectedFields = ((System.Collections.Generic.List<string>)(resources.GetObject("hubQuerySetupPanel1.SelectedFields")));
            this.hubQuerySetupPanel1.Size = new System.Drawing.Size(746, 178);
            this.hubQuerySetupPanel1.SourceTable = "Hubs";
            this.hubQuerySetupPanel1.TabIndex = 39;
            // 
            // LocalityQuerySetupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.hubQuerySetupPanel1);
            this.Controls.Add(this.bt_file);
            this.Controls.Add(this.lvw_mappings);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lvw_Locality);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_DateFieldName);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.label3);
            this.Name = "LocalityQuerySetupPanel";
            this.Size = new System.Drawing.Size(640, 580);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_DateFieldName;
        private CustomGUI.RecentFileTextBox txtFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvw_Locality;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvw_mappings;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button bt_file;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private HubQuerySetupPanel hubQuerySetupPanel1;
        private System.Windows.Forms.ContextMenuStrip recentFilesMenuStrip;
    }
}
