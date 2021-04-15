using DevExpress.XtraBars.Docking2010;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.ServicesBuilders;
using System.Linq;

namespace PSC_Cost_Control.Forms.Project_Code
{
    public partial class Frm_Categories_ProjectCode : DevExpress.XtraEditors.XtraForm
    {
        IProjectCodeCategoryService _categoryService;

        public Frm_Categories_ProjectCode()
        {
            InitializeComponent();
            _categoryService = ServiceBuilder.Build<IProjectCodeCategoryService>();
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
            var ResualtCategories = await _categoryService.GetCategories();
            var CustomCategories = from cat in ResualtCategories
                                   select new
                                   {
                                       Id = cat.Id,
                                       Name = cat.Name
                                   };
            dataGridView1.DataSource = CustomCategories.ToList();
        }
        void AddData(string _Neme)
        {
            //check if name is not null
            if (ValidationData())
            {
                _categoryService.Add(_Neme);
            }
        }
        bool ValidationData()
        {
            if (string.IsNullOrWhiteSpace(txt_Name.Text))
            {
                MessageBox.Show("Plase Enter Category Name .");
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
            else if (btn.Caption == "Save")
            {
                //Add Cateogry
                AddData(txt_Name.Text);
            }
        }

        private void Frm_Categories_ProjectCode_Load(object sender, EventArgs e)
        {

            ClearAllData();
        }
    }
}