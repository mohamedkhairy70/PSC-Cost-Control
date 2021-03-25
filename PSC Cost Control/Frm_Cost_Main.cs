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
using PSC_Cost_Control.Model;
using PSC_Cost_Control.Helper;
using PSC_Cost_Control.Forms;


namespace PSC_Cost_Control
{
    public partial class Frm_Cost_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly PSC_COST2Entities context = new PSC_COST2Entities();
        readonly Static st = new Static();

        // FIll Employee Lists
        public List<C_Cost_Project_Codes> _Cost_Project_Codes = new List<C_Cost_Project_Codes>();
        public List<C_Cost_Project_Code_Categories> _Categories = new List<C_Cost_Project_Code_Categories>();
        public List<Project> _Projects = new List<Project>();
        public List<View_Cost_Project_Codes> _View_Cost_Project_Codes = new List<View_Cost_Project_Codes>();
        
        public Frm_Cost_Main()
        {
            InitializeComponent();
            FillLists();
        }
        void FillLists()
        {
            using (PSC_COST2Entities context2 = new PSC_COST2Entities())
            {
                _Cost_Project_Codes = context2.C_Cost_Project_Codes.ToList();
                _Categories = context2.C_Cost_Project_Code_Categories.ToList();
                _Projects = context2.Projects.ToList();
                _View_Cost_Project_Codes = context2.View_Cost_Project_Codes.ToList();
            }
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Project_Code 
        }
    }
}