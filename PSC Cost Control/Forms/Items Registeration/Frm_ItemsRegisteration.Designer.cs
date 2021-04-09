
namespace PSC_Cost_Control.Forms.Items_Registeration
{
    partial class Frm_ItemsRegisteration
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cm_IndirectCostItems = new System.Windows.Forms.ComboBox();
            this.cm_BOQItems = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cm_Project = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cm_Project);
            this.panel1.Controls.Add(this.cm_BOQItems);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.cm_IndirectCostItems);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.windowsUIButtonPanel1);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 182);
            this.panel1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(244, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 19);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Projects :";
            // 
            // windowsUIButtonPanel1
            // 
            this.windowsUIButtonPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            windowsUIButtonImageOptions1.ImageUri.Uri = "Save;Size32x32;GrayScaled";
            this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Show", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanel1.Location = new System.Drawing.Point(206, 99);
            this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.Size = new System.Drawing.Size(446, 77);
            this.windowsUIButtonPanel1.TabIndex = 9;
            this.windowsUIButtonPanel1.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButtonPanel1_ButtonClick);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(30, 56);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(123, 19);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Indirect Cost Items :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 182);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(856, 333);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Name});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(856, 333);
            this.dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.FillWeight = 122.0564F;
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // cm_IndirectCostItems
            // 
            this.cm_IndirectCostItems.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cm_IndirectCostItems.FormattingEnabled = true;
            this.cm_IndirectCostItems.Items.AddRange(new object[] {
            "Structure",
            "indirect"});
            this.cm_IndirectCostItems.Location = new System.Drawing.Point(159, 53);
            this.cm_IndirectCostItems.Name = "cm_IndirectCostItems";
            this.cm_IndirectCostItems.Size = new System.Drawing.Size(217, 27);
            this.cm_IndirectCostItems.TabIndex = 12;
            // 
            // cm_BOQItems
            // 
            this.cm_BOQItems.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cm_BOQItems.FormattingEnabled = true;
            this.cm_BOQItems.Items.AddRange(new object[] {
            "Structure",
            "indirect"});
            this.cm_BOQItems.Location = new System.Drawing.Point(541, 53);
            this.cm_BOQItems.Name = "cm_BOQItems";
            this.cm_BOQItems.Size = new System.Drawing.Size(253, 27);
            this.cm_BOQItems.TabIndex = 14;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(457, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 19);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "BOQ Items :";
            // 
            // cm_Project
            // 
            this.cm_Project.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cm_Project.FormattingEnabled = true;
            this.cm_Project.Items.AddRange(new object[] {
            "Structure",
            "indirect"});
            this.cm_Project.Location = new System.Drawing.Point(307, 9);
            this.cm_Project.Name = "cm_Project";
            this.cm_Project.Size = new System.Drawing.Size(253, 27);
            this.cm_Project.TabIndex = 15;
            // 
            // Frm_ItemsRegisteration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 515);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_ItemsRegisteration";
            this.Text = "Form Categories Project Code";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.ComboBox cm_BOQItems;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox cm_IndirectCostItems;
        private System.Windows.Forms.ComboBox cm_Project;
    }
}