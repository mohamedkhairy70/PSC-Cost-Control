using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;
using PSC_Cost_Control.Models;

namespace PSC_Cost_Control.Forms.Project_Code
{
    public partial class Frm_Categories_ProjectCode : DevExpress.XtraEditors.XtraForm
    {
        ProjectCodesCategoriesRepo categoriesRepo;
        
        PSC_COST3Entities context = new PSC_COST3Entities();
        public Frm_Categories_ProjectCode()
        {
            InitializeComponent();
            categoriesRepo = new ProjectCodesCategoriesRepo(context);
        }



        #region My Method for my From
        void ClearAllData()
        {
            txt_Id.Clear();
            txt_Name.Clear();
            GetAllData();
        }
        void GetAllData()
        {
            using (PSC_COST3Entities entities = new PSC_COST3Entities())
            {
                dataGridView1.DataSource = entities.C_Cost_Project_Code_Categories.ToList();
            };
             
        }
        void AddData(string _Neme)
        {
            bool testAdd = context.C_Cost_Project_Code_Categories.Any(x => x.Name == _Neme);
            if (testAdd)
            {
                MessageBox.Show("This is Exists");
                return;
            }
            else
            {
                using (PSC_COST3Entities forCheck = new PSC_COST3Entities())
                {
                    bool testAddForCheck = forCheck.C_Cost_Project_Code_Categories.Any(x => x.Name == _Neme);
                    if (testAdd)
                    {
                        MessageBox.Show("This is Exists");
                        return;
                    }
                    
                }
                C_Cost_Project_Code_Categories project_Code_Categories = new C_Cost_Project_Code_Categories()
                {
                    Name = _Neme
                };
                categoriesRepo.AddUnifiedCodeCategory(project_Code_Categories);
                ClearAllData();
            }
            
        }
        bool ValidationData()
        {
            if (string.IsNullOrWhiteSpace(txt_Name.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion My Method for my Form

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            if (btn.Caption == "New")
            {
                //Clear all Data 
                ClearAllData();
            }
            else
            {
                //check if name is not null
                if (ValidationData())
                {
                    //Add Cateogry
                    AddData(txt_Name.Text);
                }
            }
        }

        private void Frm_Categories_ProjectCode_Load(object sender, EventArgs e)
        {
            
           
        }
    }
}