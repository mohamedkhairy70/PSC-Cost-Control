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
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;

namespace PSC_Cost_Control.Forms.Project_Code
{
    public partial class Frm_Categories_ProjectCode : DevExpress.XtraEditors.XtraForm
    {
        ProjectCodeCategoryService _categoryService;

        public Frm_Categories_ProjectCode()
        {
            InitializeComponent();
            
        }
        public Frm_Categories_ProjectCode(ProjectCodesCategoriesRepo categoryService) : this()
        {
            _categoryService = new ProjectCodeCategoryService(categoryService);
        }


        #region My Method for my From
        void ClearAllData()
        {
            txt_Id.Clear();
            txt_Name.Clear();
            GetAllData().GetAwaiter();
        }
        async Task GetAllData()
        {
           // var Resualt = await _categoryService.GetCategoriesAsync();
           // dataGridView1.DataSource = Resualt;
        }
        //void AddData(string _Neme)
        //{

        //    categoryService.Add(_Neme);

        //}
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
                    //AddData(txt_Name.Text);
                }
            }
        }

        private void Frm_Categories_ProjectCode_Load(object sender, EventArgs e)
        {

            ClearAllData();
        }
    }
}