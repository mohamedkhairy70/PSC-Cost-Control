﻿
namespace PSC_Cost_Control.Forms.Project_Code
{
    partial class Frm_ProjectCode_Show
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions4 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions5 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions6 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions7 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cm_Categories = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cm_Projects = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tree_ProjectCode = new DevExpress.XtraTreeList.TreeList();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.dragDropEvents1 = new DevExpress.Utils.DragDrop.DragDropEvents(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tree_ProjectCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(894, 349);
            this.panelControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupControl2);
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Controls.Add(this.windowsUIButtonPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(890, 345);
            this.panel1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl2.Controls.Add(this.txt_Description);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.cm_Categories);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Location = new System.Drawing.Point(10, 90);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(870, 128);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Project Code";
            // 
            // txt_Description
            // 
            this.txt_Description.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_Description.Location = new System.Drawing.Point(605, 66);
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(249, 26);
            this.txt_Description.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(527, 68);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 19);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Description :";
            // 
            // cm_Categories
            // 
            this.cm_Categories.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cm_Categories.FormattingEnabled = true;
            this.cm_Categories.Items.AddRange(new object[] {
            "Structure",
            "indirect"});
            this.cm_Categories.Location = new System.Drawing.Point(111, 65);
            this.cm_Categories.Name = "cm_Categories";
            this.cm_Categories.Size = new System.Drawing.Size(209, 27);
            this.cm_Categories.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(30, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 19);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Categories :";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl1.Controls.Add(this.cm_Projects);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(167, 11);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(605, 73);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Projects";
            // 
            // cm_Projects
            // 
            this.cm_Projects.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cm_Projects.FormattingEnabled = true;
            this.cm_Projects.Items.AddRange(new object[] {
            "Concrete 300",
            "Concrete 350",
            "Concrete 400"});
            this.cm_Projects.Location = new System.Drawing.Point(99, 29);
            this.cm_Projects.Name = "cm_Projects";
            this.cm_Projects.Size = new System.Drawing.Size(420, 27);
            this.cm_Projects.TabIndex = 1;
            this.cm_Projects.DropDownClosed += new System.EventHandler(this.cm_Projects_DropDownClosed);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(36, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Projects :";
            // 
            // windowsUIButtonPanel1
            // 
            this.windowsUIButtonPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            windowsUIButtonImageOptions1.ImageUri.Uri = "Print;Size32x32;GrayScaled";
            windowsUIButtonImageOptions2.ImageUri.Uri = "Zoom;Size32x32;GrayScaled";
            windowsUIButtonImageOptions3.ImageUri.Uri = "SaveAll;Size32x32;GrayScaled";
            windowsUIButtonImageOptions4.ImageUri.Uri = "AddNewDataSource;Size32x32;GrayScaled";
            windowsUIButtonImageOptions5.ImageUri.Uri = "Add;Size32x32;GrayScaled";
            windowsUIButtonImageOptions6.ImageIndex = 0;
            windowsUIButtonImageOptions6.ImageUri.Uri = "New;Size32x32;GrayScaled";
            windowsUIButtonImageOptions7.ImageUri.Uri = "Copy;Size32x32;GrayScaled";
            this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Print Project", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Search Project", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save Project", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("New Project", true, windowsUIButtonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Add Project Code", true, windowsUIButtonImageOptions5, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("New Project Code", true, windowsUIButtonImageOptions6, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("copy from another Project", true, windowsUIButtonImageOptions7, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanel1.Location = new System.Drawing.Point(10, 239);
            this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.Size = new System.Drawing.Size(870, 92);
            this.windowsUIButtonPanel1.TabIndex = 0;
            this.windowsUIButtonPanel1.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButtonPanel1_ButtonClick);
            this.windowsUIButtonPanel1.Click += new System.EventHandler(this.windowsUIButtonPanel1_Click_1);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.panel2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 349);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(894, 314);
            this.panelControl3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tree_ProjectCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(890, 310);
            this.panel2.TabIndex = 1;
            // 
            // tree_ProjectCode
            // 
            this.behaviorManager1.SetBehaviors(this.tree_ProjectCode, new DevExpress.Utils.Behaviors.Behavior[] {
            ((DevExpress.Utils.Behaviors.Behavior)(DevExpress.Utils.DragDrop.DragDropBehavior.Create(typeof(DevExpress.XtraTreeList.TreeListDragDropSource), true, true, true, true, this.dragDropEvents1)))});
            this.tree_ProjectCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.tree_ProjectCode.CustomizationFormBounds = new System.Drawing.Rectangle(684, 564, 260, 232);
            this.tree_ProjectCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_ProjectCode.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.tree_ProjectCode.KeyFieldName = "Id";
            this.tree_ProjectCode.Location = new System.Drawing.Point(0, 0);
            this.tree_ProjectCode.Name = "tree_ProjectCode";
            this.tree_ProjectCode.OptionsBehavior.Editable = false;
            this.tree_ProjectCode.OptionsNavigation.AutoFocusNewNode = true;
            this.tree_ProjectCode.OptionsSelection.MultiSelect = true;
            this.tree_ProjectCode.OptionsView.AllowBandColumnsMultiRow = true;
            this.tree_ProjectCode.ParentFieldName = "GetLevelNode";
            this.tree_ProjectCode.Size = new System.Drawing.Size(890, 310);
            this.tree_ProjectCode.TabIndex = 0;
            // 
            // Frm_ProjectCode_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 663);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_ProjectCode_Show";
            this.Text = "Project Code Show";
            this.Load += new System.EventHandler(this.Frm_ProjectCode_Show_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tree_ProjectCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraTreeList.TreeList tree_ProjectCode;
        public DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.Utils.DragDrop.DragDropEvents dragDropEvents1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TextBox txt_Description;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox cm_Categories;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ComboBox cm_Projects;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}