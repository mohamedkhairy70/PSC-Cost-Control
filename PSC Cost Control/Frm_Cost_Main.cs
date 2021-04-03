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
    }
}