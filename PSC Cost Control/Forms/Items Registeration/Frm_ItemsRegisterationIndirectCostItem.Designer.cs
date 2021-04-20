
namespace PSC_Cost_Control.Forms.Items_Registeration
{
    partial class Frm_ItemsRegisterationIndirectCostItem
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txt_Projects = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Regiter = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DGV_IndirectCost = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cm_SearchByIndirectCost = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_SearchByIndirectCost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DGV_ProjectCode = new System.Windows.Forms.DataGridView();
            this.ch_RegisterProjectCode = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProjectCode_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectCode_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_SearchByProjectCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DGV_RegistBOQItem = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txt_SearchByRegistBOQItem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ch_RegisterIndirectCostItem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IndirectCostId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndirectCostDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_RegisterEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BoqRegisterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoqResisterIndirectCostId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoqResisterProjectCodeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoqResisterIndirectCostDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoqResisterProjectCodeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_IndirectCost)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ProjectCode)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RegistBOQItem)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1307, 87);
            this.panel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl1.Controls.Add(this.txt_Projects);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(351, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(605, 73);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Projects";
            // 
            // txt_Projects
            // 
            this.txt_Projects.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Projects.Location = new System.Drawing.Point(121, 29);
            this.txt_Projects.Name = "txt_Projects";
            this.txt_Projects.Size = new System.Drawing.Size(322, 32);
            this.txt_Projects.TabIndex = 5;
            this.txt_Projects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Projects_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(36, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 23);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Projects :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btn_Regiter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 526);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1307, 73);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PapayaWhip;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 16F);
            this.button1.Location = new System.Drawing.Point(330, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(338, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = ">>> Save All Registeration <<<";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Regiter
            // 
            this.btn_Regiter.BackColor = System.Drawing.Color.PapayaWhip;
            this.btn_Regiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Regiter.Font = new System.Drawing.Font("Times New Roman", 16F);
            this.btn_Regiter.Location = new System.Drawing.Point(739, 15);
            this.btn_Regiter.Name = "btn_Regiter";
            this.btn_Regiter.Size = new System.Drawing.Size(338, 46);
            this.btn_Regiter.TabIndex = 0;
            this.btn_Regiter.Text = ">>> Register <<<";
            this.btn_Regiter.UseVisualStyleBackColor = false;
            this.btn_Regiter.Click += new System.EventHandler(this.btn_Regiter_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.DGV_IndirectCost);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(947, 87);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 439);
            this.panel3.TabIndex = 2;
            // 
            // DGV_IndirectCost
            // 
            this.DGV_IndirectCost.AllowUserToAddRows = false;
            this.DGV_IndirectCost.AllowUserToDeleteRows = false;
            this.DGV_IndirectCost.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_IndirectCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_IndirectCost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ch_RegisterIndirectCostItem,
            this.IndirectCostId,
            this.IndirectCostDescription});
            this.DGV_IndirectCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_IndirectCost.Location = new System.Drawing.Point(0, 139);
            this.DGV_IndirectCost.Margin = new System.Windows.Forms.Padding(4);
            this.DGV_IndirectCost.Name = "DGV_IndirectCost";
            this.DGV_IndirectCost.Size = new System.Drawing.Size(358, 298);
            this.DGV_IndirectCost.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.cm_SearchByIndirectCost);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.txt_SearchByIndirectCost);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(358, 139);
            this.panel8.TabIndex = 0;
            // 
            // cm_SearchByIndirectCost
            // 
            this.cm_SearchByIndirectCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cm_SearchByIndirectCost.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cm_SearchByIndirectCost.FormattingEnabled = true;
            this.cm_SearchByIndirectCost.Items.AddRange(new object[] {
            "Structure",
            "indirect"});
            this.cm_SearchByIndirectCost.Location = new System.Drawing.Point(81, 39);
            this.cm_SearchByIndirectCost.Name = "cm_SearchByIndirectCost";
            this.cm_SearchByIndirectCost.Size = new System.Drawing.Size(238, 27);
            this.cm_SearchByIndirectCost.TabIndex = 8;
            this.cm_SearchByIndirectCost.DropDownClosed += new System.EventHandler(this.cm_BOQItem_DropDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "BOQs :";
            // 
            // txt_SearchByIndirectCost
            // 
            this.txt_SearchByIndirectCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_SearchByIndirectCost.Location = new System.Drawing.Point(141, 105);
            this.txt_SearchByIndirectCost.Name = "txt_SearchByIndirectCost";
            this.txt_SearchByIndirectCost.Size = new System.Drawing.Size(204, 26);
            this.txt_SearchByIndirectCost.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Search By Item Name :";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Moccasin;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.label3);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Margin = new System.Windows.Forms.Padding(4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(356, 36);
            this.panel11.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Indirect Cost";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.DGV_ProjectCode);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 87);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(423, 439);
            this.panel4.TabIndex = 3;
            // 
            // DGV_ProjectCode
            // 
            this.DGV_ProjectCode.AllowUserToAddRows = false;
            this.DGV_ProjectCode.AllowUserToDeleteRows = false;
            this.DGV_ProjectCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_ProjectCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ProjectCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ch_RegisterProjectCode,
            this.ProjectCode_Description,
            this.ProjectCode_Id});
            this.DGV_ProjectCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_ProjectCode.Location = new System.Drawing.Point(0, 139);
            this.DGV_ProjectCode.Margin = new System.Windows.Forms.Padding(4);
            this.DGV_ProjectCode.Name = "DGV_ProjectCode";
            this.DGV_ProjectCode.Size = new System.Drawing.Size(421, 298);
            this.DGV_ProjectCode.TabIndex = 1;
            // 
            // ch_RegisterProjectCode
            // 
            this.ch_RegisterProjectCode.HeaderText = "Register Project Code";
            this.ch_RegisterProjectCode.Name = "ch_RegisterProjectCode";
            this.ch_RegisterProjectCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ProjectCode_Description
            // 
            this.ProjectCode_Description.DataPropertyName = "ProjectCode_Description";
            this.ProjectCode_Description.HeaderText = "Project Code Description";
            this.ProjectCode_Description.Name = "ProjectCode_Description";
            // 
            // ProjectCode_Id
            // 
            this.ProjectCode_Id.DataPropertyName = "ProjectCode_Id";
            this.ProjectCode_Id.HeaderText = "Project Code Id";
            this.ProjectCode_Id.Name = "ProjectCode_Id";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txt_SearchByProjectCode);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(421, 139);
            this.panel6.TabIndex = 0;
            // 
            // txt_SearchByProjectCode
            // 
            this.txt_SearchByProjectCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_SearchByProjectCode.Location = new System.Drawing.Point(106, 90);
            this.txt_SearchByProjectCode.Name = "txt_SearchByProjectCode";
            this.txt_SearchByProjectCode.Size = new System.Drawing.Size(212, 26);
            this.txt_SearchByProjectCode.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Search By Item Name :";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Moccasin;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.label1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(419, 36);
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
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.DGV_RegistBOQItem);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(423, 87);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(524, 439);
            this.panel5.TabIndex = 4;
            // 
            // DGV_RegistBOQItem
            // 
            this.DGV_RegistBOQItem.AllowUserToAddRows = false;
            this.DGV_RegistBOQItem.AllowUserToDeleteRows = false;
            this.DGV_RegistBOQItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_RegistBOQItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_RegistBOQItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btn_RegisterEdit,
            this.BoqRegisterId,
            this.BoqResisterIndirectCostId,
            this.BoqResisterProjectCodeId,
            this.BoqResisterIndirectCostDescription,
            this.BoqResisterProjectCodeDescription});
            this.DGV_RegistBOQItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_RegistBOQItem.Location = new System.Drawing.Point(0, 139);
            this.DGV_RegistBOQItem.Margin = new System.Windows.Forms.Padding(4);
            this.DGV_RegistBOQItem.Name = "DGV_RegistBOQItem";
            this.DGV_RegistBOQItem.ReadOnly = true;
            this.DGV_RegistBOQItem.Size = new System.Drawing.Size(522, 298);
            this.DGV_RegistBOQItem.TabIndex = 2;
            this.DGV_RegistBOQItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_RegistBOQItem_CellContentClick);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.txt_SearchByRegistBOQItem);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(522, 139);
            this.panel7.TabIndex = 0;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // txt_SearchByRegistBOQItem
            // 
            this.txt_SearchByRegistBOQItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_SearchByRegistBOQItem.Location = new System.Drawing.Point(117, 90);
            this.txt_SearchByRegistBOQItem.Name = "txt_SearchByRegistBOQItem";
            this.txt_SearchByRegistBOQItem.Size = new System.Drawing.Size(228, 26);
            this.txt_SearchByRegistBOQItem.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Search By Item Name :";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Moccasin;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.label2);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(520, 36);
            this.panel10.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Registeration BOQ Items";
            // 
            // ch_RegisterIndirectCostItem
            // 
            this.ch_RegisterIndirectCostItem.HeaderText = "Register Indirect Cost Item";
            this.ch_RegisterIndirectCostItem.Name = "ch_RegisterIndirectCostItem";
            this.ch_RegisterIndirectCostItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IndirectCostId
            // 
            this.IndirectCostId.DataPropertyName = "IndirectCostId";
            this.IndirectCostId.HeaderText = "Indirect Cost Id";
            this.IndirectCostId.Name = "IndirectCostId";
            // 
            // IndirectCostDescription
            // 
            this.IndirectCostDescription.DataPropertyName = "IndirectCostDescription";
            this.IndirectCostDescription.HeaderText = "BOQ Item Description";
            this.IndirectCostDescription.Name = "IndirectCostDescription";
            // 
            // btn_RegisterEdit
            // 
            this.btn_RegisterEdit.HeaderText = "Register Edit";
            this.btn_RegisterEdit.Name = "btn_RegisterEdit";
            this.btn_RegisterEdit.ReadOnly = true;
            this.btn_RegisterEdit.Text = "Register Edit";
            this.btn_RegisterEdit.ToolTipText = "Register Edit";
            this.btn_RegisterEdit.UseColumnTextForButtonValue = true;
            // 
            // BoqRegisterId
            // 
            this.BoqRegisterId.DataPropertyName = "BoqRegisterId";
            this.BoqRegisterId.HeaderText = "Boq Register Id";
            this.BoqRegisterId.Name = "BoqRegisterId";
            this.BoqRegisterId.ReadOnly = true;
            // 
            // BoqResisterIndirectCostId
            // 
            this.BoqResisterIndirectCostId.DataPropertyName = "BoqResisterIndirectCostId";
            this.BoqResisterIndirectCostId.HeaderText = "Boq Resister Indirect Cost Id";
            this.BoqResisterIndirectCostId.Name = "BoqResisterIndirectCostId";
            this.BoqResisterIndirectCostId.ReadOnly = true;
            this.BoqResisterIndirectCostId.Visible = false;
            // 
            // BoqResisterProjectCodeId
            // 
            this.BoqResisterProjectCodeId.DataPropertyName = "BoqResisterProjectCodeId";
            this.BoqResisterProjectCodeId.HeaderText = "Boq Resister Project Code Id";
            this.BoqResisterProjectCodeId.Name = "BoqResisterProjectCodeId";
            this.BoqResisterProjectCodeId.ReadOnly = true;
            this.BoqResisterProjectCodeId.Visible = false;
            // 
            // BoqResisterIndirectCostDescription
            // 
            this.BoqResisterIndirectCostDescription.DataPropertyName = "BoqResisterIndirectCostDescription";
            this.BoqResisterIndirectCostDescription.HeaderText = "Indirect Cost Description";
            this.BoqResisterIndirectCostDescription.Name = "BoqResisterIndirectCostDescription";
            this.BoqResisterIndirectCostDescription.ReadOnly = true;
            // 
            // BoqResisterProjectCodeDescription
            // 
            this.BoqResisterProjectCodeDescription.DataPropertyName = "BoqResisterProjectCodeDescription";
            this.BoqResisterProjectCodeDescription.HeaderText = "Project Code Description";
            this.BoqResisterProjectCodeDescription.Name = "BoqResisterProjectCodeDescription";
            this.BoqResisterProjectCodeDescription.ReadOnly = true;
            // 
            // Frm_ItemsRegisterationIndirectCostItem
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 599);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_ItemsRegisterationIndirectCostItem";
            this.Text = "Form Registeration BOQ Items";
            this.Load += new System.EventHandler(this.Frm_ItemsRegisterationBOQItems_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_IndirectCost)).EndInit();
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
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RegistBOQItem)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView DGV_ProjectCode;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txt_SearchByProjectCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView DGV_RegistBOQItem;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SearchByIndirectCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_SearchByRegistBOQItem;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TextBox txt_Projects;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btn_Regiter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cm_SearchByIndirectCost;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DGV_IndirectCost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ch_RegisterProjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectCode_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectCode_Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ch_RegisterIndirectCostItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndirectCostId;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndirectCostDescription;
        private System.Windows.Forms.DataGridViewButtonColumn btn_RegisterEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoqRegisterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoqResisterIndirectCostId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoqResisterProjectCodeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoqResisterIndirectCostDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoqResisterProjectCodeDescription;
    }
}