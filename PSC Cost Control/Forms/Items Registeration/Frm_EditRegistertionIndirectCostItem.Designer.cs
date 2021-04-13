﻿
namespace PSC_Cost_Control.Forms.Items_Registeration
{
    partial class Frm_EditRegistertionIndirectCostItem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_IdProject = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_ProjectCodeItemOld = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_BOQItemOld = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_NameProjectOld = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Update = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cm_BOQItemOld = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_SearchByBOQItem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DGV_ProjectCode = new System.Windows.Forms.DataGridView();
            this.ch_RegisterProjectCode = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProjectCode_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectCode_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_SearchByProjectCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_IndirectCostItem = new System.Windows.Forms.DataGridView();
            this.ch_RegisterIndirectCostItem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IndirectCostItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndirectCostItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ProjectCode)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_IndirectCostItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_IdProject);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.txt_ProjectCodeItemOld);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.txt_BOQItemOld);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.txt_NameProjectOld);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(817, 137);
            this.panel1.TabIndex = 0;
            // 
            // txt_IdProject
            // 
            this.txt_IdProject.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_IdProject.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_IdProject.Location = new System.Drawing.Point(266, 6);
            this.txt_IdProject.Margin = new System.Windows.Forms.Padding(4);
            this.txt_IdProject.Name = "txt_IdProject";
            this.txt_IdProject.Size = new System.Drawing.Size(372, 26);
            this.txt_IdProject.TabIndex = 14;
            this.txt_IdProject.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(190, 9);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 19);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Id Project :";
            this.labelControl3.Visible = false;
            // 
            // txt_ProjectCodeItemOld
            // 
            this.txt_ProjectCodeItemOld.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_ProjectCodeItemOld.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_ProjectCodeItemOld.Location = new System.Drawing.Point(84, 93);
            this.txt_ProjectCodeItemOld.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ProjectCodeItemOld.Name = "txt_ProjectCodeItemOld";
            this.txt_ProjectCodeItemOld.ReadOnly = true;
            this.txt_ProjectCodeItemOld.Size = new System.Drawing.Size(286, 26);
            this.txt_ProjectCodeItemOld.TabIndex = 12;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(84, 66);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(188, 19);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Name Project Code Item Old :";
            // 
            // txt_BOQItemOld
            // 
            this.txt_BOQItemOld.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_BOQItemOld.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_BOQItemOld.Location = new System.Drawing.Point(472, 91);
            this.txt_BOQItemOld.Margin = new System.Windows.Forms.Padding(4);
            this.txt_BOQItemOld.Name = "txt_BOQItemOld";
            this.txt_BOQItemOld.ReadOnly = true;
            this.txt_BOQItemOld.Size = new System.Drawing.Size(278, 26);
            this.txt_BOQItemOld.TabIndex = 10;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(472, 66);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(185, 19);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Name Indirect Cost Item Old :";
            // 
            // txt_NameProjectOld
            // 
            this.txt_NameProjectOld.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_NameProjectOld.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_NameProjectOld.Location = new System.Drawing.Point(266, 36);
            this.txt_NameProjectOld.Margin = new System.Windows.Forms.Padding(4);
            this.txt_NameProjectOld.Name = "txt_NameProjectOld";
            this.txt_NameProjectOld.Size = new System.Drawing.Size(372, 26);
            this.txt_NameProjectOld.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(166, 39);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(92, 19);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Name Project :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Update);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 548);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(817, 80);
            this.panel2.TabIndex = 1;
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.PapayaWhip;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("Times New Roman", 16F);
            this.btn_Update.Location = new System.Drawing.Point(239, 17);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(338, 46);
            this.btn_Update.TabIndex = 1;
            this.btn_Update.Text = ">>> Update <<<";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DGV_IndirectCostItem);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(404, 137);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(413, 411);
            this.panel3.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.cm_BOQItemOld);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.txt_SearchByBOQItem);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(413, 139);
            this.panel8.TabIndex = 0;
            // 
            // cm_BOQItemOld
            // 
            this.cm_BOQItemOld.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cm_BOQItemOld.FormattingEnabled = true;
            this.cm_BOQItemOld.Items.AddRange(new object[] {
            "Structure",
            "indirect"});
            this.cm_BOQItemOld.Location = new System.Drawing.Point(71, 40);
            this.cm_BOQItemOld.Name = "cm_BOQItemOld";
            this.cm_BOQItemOld.Size = new System.Drawing.Size(240, 27);
            this.cm_BOQItemOld.TabIndex = 8;
            this.cm_BOQItemOld.DropDown += new System.EventHandler(this.cm_BOQItemOld_DropDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "BOQs :";
            // 
            // txt_SearchByBOQItem
            // 
            this.txt_SearchByBOQItem.Location = new System.Drawing.Point(141, 95);
            this.txt_SearchByBOQItem.Name = "txt_SearchByBOQItem";
            this.txt_SearchByBOQItem.Size = new System.Drawing.Size(206, 26);
            this.txt_SearchByBOQItem.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Search By Item Name :";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Moccasin;
            this.panel11.Controls.Add(this.label3);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Margin = new System.Windows.Forms.Padding(4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(413, 36);
            this.panel11.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Indirect Cost Item";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.DGV_ProjectCode);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 137);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(404, 411);
            this.panel4.TabIndex = 4;
            // 
            // DGV_ProjectCode
            // 
            this.DGV_ProjectCode.AllowUserToAddRows = false;
            this.DGV_ProjectCode.AllowUserToDeleteRows = false;
            this.DGV_ProjectCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_ProjectCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ProjectCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ch_RegisterProjectCode,
            this.ProjectCode_Id,
            this.ProjectCode_Description});
            this.DGV_ProjectCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_ProjectCode.Location = new System.Drawing.Point(0, 139);
            this.DGV_ProjectCode.Margin = new System.Windows.Forms.Padding(4);
            this.DGV_ProjectCode.Name = "DGV_ProjectCode";
            this.DGV_ProjectCode.Size = new System.Drawing.Size(404, 272);
            this.DGV_ProjectCode.TabIndex = 2;
            this.DGV_ProjectCode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_ProjectCode_CellContentClick);
            // 
            // ch_RegisterProjectCode
            // 
            this.ch_RegisterProjectCode.HeaderText = "Register Project Code";
            this.ch_RegisterProjectCode.Name = "ch_RegisterProjectCode";
            this.ch_RegisterProjectCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ch_RegisterProjectCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ProjectCode_Id
            // 
            this.ProjectCode_Id.HeaderText = "Project Code Id";
            this.ProjectCode_Id.Name = "ProjectCode_Id";
            this.ProjectCode_Id.ReadOnly = true;
            // 
            // ProjectCode_Description
            // 
            this.ProjectCode_Description.HeaderText = "Project Code Description";
            this.ProjectCode_Description.Name = "ProjectCode_Description";
            this.ProjectCode_Description.ReadOnly = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txt_SearchByProjectCode);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(404, 139);
            this.panel6.TabIndex = 0;
            // 
            // txt_SearchByProjectCode
            // 
            this.txt_SearchByProjectCode.Location = new System.Drawing.Point(107, 91);
            this.txt_SearchByProjectCode.Name = "txt_SearchByProjectCode";
            this.txt_SearchByProjectCode.Size = new System.Drawing.Size(214, 26);
            this.txt_SearchByProjectCode.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Search By Item Name :";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Moccasin;
            this.panel9.Controls.Add(this.label1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(404, 36);
            this.panel9.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Code";
            // 
            // DGV_IndirectCostItem
            // 
            this.DGV_IndirectCostItem.AllowUserToAddRows = false;
            this.DGV_IndirectCostItem.AllowUserToDeleteRows = false;
            this.DGV_IndirectCostItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_IndirectCostItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_IndirectCostItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ch_RegisterIndirectCostItem,
            this.IndirectCostItemId,
            this.IndirectCostItemDescription});
            this.DGV_IndirectCostItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_IndirectCostItem.Location = new System.Drawing.Point(0, 139);
            this.DGV_IndirectCostItem.Margin = new System.Windows.Forms.Padding(4);
            this.DGV_IndirectCostItem.Name = "DGV_IndirectCostItem";
            this.DGV_IndirectCostItem.ReadOnly = true;
            this.DGV_IndirectCostItem.Size = new System.Drawing.Size(413, 272);
            this.DGV_IndirectCostItem.TabIndex = 3;
            // 
            // ch_RegisterIndirectCostItem
            // 
            this.ch_RegisterIndirectCostItem.HeaderText = "Register Indirect Cost Item";
            this.ch_RegisterIndirectCostItem.Name = "ch_RegisterIndirectCostItem";
            this.ch_RegisterIndirectCostItem.ReadOnly = true;
            this.ch_RegisterIndirectCostItem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ch_RegisterIndirectCostItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IndirectCostItemId
            // 
            this.IndirectCostItemId.DataPropertyName = "IndirectCostItemId";
            this.IndirectCostItemId.HeaderText = "Indirect Cost Item Id";
            this.IndirectCostItemId.Name = "IndirectCostItemId";
            this.IndirectCostItemId.ReadOnly = true;
            // 
            // IndirectCostItemDescription
            // 
            this.IndirectCostItemDescription.DataPropertyName = "IndirectCostItemDescription";
            this.IndirectCostItemDescription.HeaderText = "Indirect Cost Item Description";
            this.IndirectCostItemDescription.Name = "IndirectCostItemDescription";
            this.IndirectCostItemDescription.ReadOnly = true;
            // 
            // Frm_EditRegistertionIndirectCostItem
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 628);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Frm_EditRegistertionIndirectCostItem";
            this.Text = "Form Categories Project Code";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ProjectCode)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_IndirectCostItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_SearchByBOQItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txt_SearchByProjectCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Update;
        public System.Windows.Forms.TextBox txt_NameProjectOld;
        public System.Windows.Forms.TextBox txt_ProjectCodeItemOld;
        public System.Windows.Forms.TextBox txt_BOQItemOld;
        public System.Windows.Forms.ComboBox cm_BOQItemOld;
        public System.Windows.Forms.DataGridView DGV_ProjectCode;
        public System.Windows.Forms.TextBox txt_IdProject;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ch_RegisterProjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectCode_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectCode_Description;
        private System.Windows.Forms.DataGridView DGV_IndirectCostItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ch_RegisterIndirectCostItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndirectCostItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndirectCostItemDescription;
    }
}