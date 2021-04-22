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

namespace PSC_Cost_Control.Forms.Project_Code
{
    public partial class Frm_ProjectCodeEdit : DevExpress.XtraEditors.XtraForm
    {
        ExternalAPIs _externalAPIs;
        
        public string Discription = "",Title = "",Category = "";
        public int UnifiedId = 0, CategoryId = 0;
        public Frm_ProjectCodeEdit()
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
            if (Convert.ToInt32(cm_UnifiedCode.SelectedValue) > 0)
            {
                Resualt = true;
            }
            else
            {

                MessageBox.Show("Plase choose Unified Code From .");
                return false;
            }
            if (!string.IsNullOrEmpty(txt_Description.Text))
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
            IUnifiedCodeService _unifiedCodeService = ServiceBuilder.Build<IUnifiedCodeService>();

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

            var UnifiedCodeList = await _unifiedCodeService.GetUnifiedCodes();

            cm_UnifiedCode.DataSource = UnifiedCodeList;
            cm_UnifiedCode.DisplayMember = "Title";
            cm_UnifiedCode.ValueMember = "Id";
            cm_UnifiedCode.SelectedIndex = -1;
        }
        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            if (btn.Caption == "Save New Data")
            {
                if (ValidationData())
                {
                    UnifiedId = Convert.ToInt32(cm_UnifiedCode.SelectedValue);
                    CategoryId = Convert.ToInt32(cm_Categories.SelectedValue);
                    Discription = txt_Description.Text;
                    Title = cm_UnifiedCode.Text;
                    Category = cm_Categories.Text;
                    Close();
                }
            }
        }
        private void Frm_Categories_ProjectCode_Load(object sender, EventArgs e)
        {
            ClearAllDataProject();
            txt_CategoriesOld.Text = Category;
            txt_UnifiedCodeOld.Text = Title;
            txt_DescriptionOld.Text = Discription;
            
        }

    }
}
