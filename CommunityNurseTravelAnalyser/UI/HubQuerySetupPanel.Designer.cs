namespace HomeVisitTravelAnalyser.UI
{
    partial class HubQuerySetupPanel
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Region");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Easting");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Northing");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lvw_hubSelectedFields = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txthubTable = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lvw_hubSelectedFields);
            this.groupBox1.Controls.Add(this.txthubTable);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hub Query Setup";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Selected Fields";
            // 
            // lvw_hubSelectedFields
            // 
            this.lvw_hubSelectedFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.lvw_hubSelectedFields.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.lvw_hubSelectedFields.Location = new System.Drawing.Point(156, 45);
            this.lvw_hubSelectedFields.Name = "lvw_hubSelectedFields";
            this.lvw_hubSelectedFields.Size = new System.Drawing.Size(575, 112);
            this.lvw_hubSelectedFields.TabIndex = 45;
            this.lvw_hubSelectedFields.UseCompatibleStateImageBehavior = false;
            this.lvw_hubSelectedFields.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "FieldName";
            this.columnHeader5.Width = 555;
            // 
            // txthubTable
            // 
            this.txthubTable.Location = new System.Drawing.Point(156, 19);
            this.txthubTable.Name = "txthubTable";
            this.txthubTable.Size = new System.Drawing.Size(575, 20);
            this.txthubTable.TabIndex = 43;
            this.txthubTable.Text = "Hubs";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Table";
            // 
            // HubQuerySetupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "HubQuerySetupPanel";
            this.Size = new System.Drawing.Size(746, 178);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView lvw_hubSelectedFields;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox txthubTable;
        private System.Windows.Forms.Label label9;
    }
}
