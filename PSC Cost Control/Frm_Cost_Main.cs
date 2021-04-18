using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Helper;
using PSC_Cost_Control.Forms;


namespace PSC_Cost_Control
{
    public partial class Frm_Cost_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        readonly Static st = new Static();

        public Frm_Cost_Main()
        {
            InitializeComponent();

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Project_Code.Frm_ProjectCode_Show frm = new Forms.Project_Code.Frm_ProjectCode_Show();
            frm.ShowDialog();

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Project_Code.Frm_Categories_ProjectCode frm = new Forms.Project_Code.Frm_Categories_ProjectCode();
            frm.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Unified_Code.Frm_Categories_UnifiedCode frm = new Forms.Unified_Code.Frm_Categories_UnifiedCode();
            frm.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Unified_Code.Frm_UnifiedCode_Show frm = new Forms.Unified_Code.Frm_UnifiedCode_Show();
            frm.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Items_Registeration.Frm_ItemsRegisterationBOQItems frm = new Forms.Items_Registeration.Frm_ItemsRegisterationBOQItems();
            frm.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Items_Registeration.Frm_ItemsRegisterationIndirectCostItem frm = new Forms.Items_Registeration.Frm_ItemsRegisterationIndirectCostItem();
            frm.ShowDialog();
        }
    }
}