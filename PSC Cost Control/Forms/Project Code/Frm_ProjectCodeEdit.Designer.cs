
namespace PSC_Cost_Control.Forms.Project_Code
{
    partial class Frm_ProjectCodeEdit
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cm_UnifiedCode = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cm_Categories = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_DescriptionOld = new System.Windows.Forms.TextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txt_UnifiedCodeOld = new System.Windows.Forms.TextBox();
            this.txt_CategoriesOld = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Controls.Add(this.groupControl2);
            this.panel1.Controls.Add(this.windowsUIButtonPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 362);
            this.panel1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl2.Controls.Add(this.cm_UnifiedCode);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.txt_Description);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.cm_Categories);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Location = new System.Drawing.Point(30, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(363, 190);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "New Data Node";
            // 
            // cm_UnifiedCode
            // 
            this.cm_UnifiedCode.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cm_UnifiedCode.FormattingEnabled = true;
            this.cm_UnifiedCode.Location = new System.Drawing.Point(106, 80);
            this.cm_UnifiedCode.Name = "cm_UnifiedCode";
            this.cm_UnifiedCode.Size = new System.Drawing.Size(249, 27);
            this.cm_UnifiedCode.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 83);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 19);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Unified Code :";
            // 
            // txt_Description
            // 
            this.txt_Description.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_Description.Location = new System.Drawing.Point(106, 131);
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(249, 26);
            this.txt_Description.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(28, 133);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 19);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Description :";
            // 
            // cm_Categories
            // 
            this.cm_Categories.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cm_Categories.FormattingEnabled = true;
            this.cm_Categories.Location = new System.Drawing.Point(106, 40);
            this.cm_Categories.Name = "cm_Categories";
            this.cm_Categories.Size = new System.Drawing.Size(249, 27);
            this.cm_Categories.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(28, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 19);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Categories :";
            // 
            // windowsUIButtonPanel1
            // 
            this.windowsUIButtonPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            windowsUIButtonImageOptions2.ImageUri.Uri = "Save;Size32x32;GrayScaled";
            this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save New Data", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanel1.Location = new System.Drawing.Point(30, 208);
            this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.Size = new System.Drawing.Size(363, 113);
            this.windowsUIButtonPanel1.TabIndex = 9;
            this.windowsUIButtonPanel1.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButtonPanel1_ButtonClick);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl1.Controls.Add(this.txt_CategoriesOld);
            this.groupControl1.Controls.Add(this.txt_UnifiedCodeOld);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txt_DescriptionOld);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Location = new System.Drawing.Point(448, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(363, 190);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "Old Data Node";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 83);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(88, 19);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Unified Code :";
            // 
            // txt_DescriptionOld
            // 
            this.txt_DescriptionOld.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_DescriptionOld.Location = new System.Drawing.Point(106, 131);
            this.txt_DescriptionOld.Name = "txt_DescriptionOld";
            this.txt_DescriptionOld.Size = new System.Drawing.Size(249, 26);
            this.txt_DescriptionOld.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(28, 133);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 19);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Description :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(28, 43);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(72, 19);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Categories :";
            // 
            // txt_UnifiedCodeOld
            // 
            this.txt_UnifiedCodeOld.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_UnifiedCodeOld.Location = new System.Drawing.Point(106, 80);
            this.txt_UnifiedCodeOld.Name = "txt_UnifiedCodeOld";
            this.txt_UnifiedCodeOld.Size = new System.Drawing.Size(249, 26);
            this.txt_UnifiedCodeOld.TabIndex = 8;
            // 
            // txt_CategoriesOld
            // 
            this.txt_CategoriesOld.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_CategoriesOld.Location = new System.Drawing.Point(106, 41);
            this.txt_CategoriesOld.Name = "txt_CategoriesOld";
            this.txt_CategoriesOld.Size = new System.Drawing.Size(249, 26);
            this.txt_CategoriesOld.TabIndex = 9;
            // 
            // Frm_ProjectCodeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 362);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_ProjectCodeEdit";
            this.Text = "Form Project Code Clone";
            this.Load += new System.EventHandler(this.Frm_Categories_ProjectCode_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.ComboBox cm_UnifiedCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txt_Description;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox cm_Categories;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TextBox txt_CategoriesOld;
        private System.Windows.Forms.TextBox txt_UnifiedCodeOld;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox txt_DescriptionOld;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}