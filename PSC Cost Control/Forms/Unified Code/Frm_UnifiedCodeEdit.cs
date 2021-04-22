using DevExpress.XtraBars.Docking2010;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.ServicesBuilders;
using System.Linq;
using System.Data;
using DevExpress.XtraTreeList.Nodes;
using PSC_Cost_Control.Services.UnifiedCodesServices;
using PSC_Cost_Control.Services.DependencyApis;
using DevExpress.XtraTreeList;
using System.Reflection;
using System.Collections.Generic;
using PSC_Cost_Control.Helper.TreeListHandler;
using PSC_Cost_Control.Models;
using DevExpress.XtraTreeList.Columns;

namespace PSC_Cost_Control.Forms.Unified_Code
{
    public partial class Frm_UnifiedCodeEdit : DevExpress.XtraEditors.XtraForm
    {
        ExternalAPIs _externalAPIs;
        
        public string Title = "",Category = "";
        public int  CategoryId = 0;
        public Frm_UnifiedCodeEdit()
        {
            InitializeComponent();
            _externalAPIs = new ExternalAPIs();
        }

        #region My Method for my From

        bool ValidationData()
        {
            bool Resualt = false;
            if (Convert.ToInt32(cm_Categories.SelectedValue)> 0)
            {
                Resualt = true;
            }
            else
            {
                
                MessageBox.Show("Plase choose Category To  .");
                return false;
            }
            if (!string.IsNullOrEmpty(txt_Title.Text))
            {
                Resualt = true;
            }
            else
            {

                MessageBox.Show("Plase Enter Description From .");
                return false;
            }
            return Resualt;
        }
        #endregion My Method for my Form
        async void ClearAllDataProject()
        {
            IProjectCodeCategoryService _categoryService = ServiceBuilder.Build<IProjectCodeCategoryService>();

            var ResualtCategories = await _categoryService.GetCategories();
            var CustomCategories = from cat in ResualtCategories
                                   select new
                                   {
                                       Id = cat.Id,
                                       Name = cat.Name
                                   };
            cm_Categories.DataSource = CustomCategories.ToList();
            cm_Categories.DisplayMember = "Name";
            cm_Categories.ValueMember = "Id";
            cm_Categories.SelectedIndex = -1;

        }
        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            if (btn.Caption == "Save New Data")
            {
                if (ValidationData())
                {
                    CategoryId = Convert.ToInt32(cm_Categories.SelectedValue);
                    Title = txt_Title.Text;
                    Close();
                }
            }
        }
        private void Frm_Categories_ProjectCode_Load(object sender, EventArgs e)
        {
            ClearAllDataProject();
            txt_CategoriesOld.Text = Category;
            txt_TitleOld.Text = Title;
            
        }

    }
}
