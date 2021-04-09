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
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Repositories.PersistantReposotories.ItemsRegisterationRepositories;
using PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices;

namespace PSC_Cost_Control.Forms.Items_Registeration
{
    public partial class Frm_ItemsRegisteration : DevExpress.XtraEditors.XtraForm
    {
        ItemsRegisterationService _itemsRegisterationService;

        public Frm_ItemsRegisteration()
        {
            InitializeComponent();
            _itemsRegisterationService = new ItemsRegisterationService
                (new DirectItemRegisterationRepo(new Models.ApplicationContext())
                    , new IndirectCostItemRegisterationRepo(new Models.ApplicationContext()));
        }

        #region My Method for my From
        void GetData(string _State,int Project)
        {
            //check if ValidationData is not False
            if (ValidationData(_State))
            {
                if (_State == cm_BOQItems.Name)
                {
                    dataGridView1.DataSource =  _itemsRegisterationService.GetBOQRegisteration(Project).Result;
                }
                else if (_State == cm_IndirectCostItems.Name)
                {
                    dataGridView1.DataSource = _itemsRegisterationService.GetIndirectItemRegisteration(Project).Result;
                }
            }
        }
        void GetData(string _State, int Project,int Fild)
        {
            //check if ValidationData is not False
            if (ValidationData(_State))
            {
                if (_State == cm_BOQItems.Name)
                {
                    dataGridView1.DataSource = _itemsRegisterationService.GetBOQRegisteration(Project).Result;
                }
                else if (_State == cm_IndirectCostItems.Name)
                {
                    dataGridView1.DataSource = _itemsRegisterationService.GetIndirectItemRegisteration(Project).Result;
                }
            }
        }
        bool ValidationData(string _State)
        {
            bool Resualt = false;
            if (Convert.ToInt32(cm_Project.SelectedValue) > 0)
            {
                Resualt = true;
            }
            else
            {
                return false;
            }
            if(_State == cm_BOQItems.Name)
            {
                if (Convert.ToInt32(cm_BOQItems.SelectedValue) > 0)
                {
                    Resualt = true;
                }
                else
                {
                    return false;
                }
            }
            else if (_State == cm_IndirectCostItems.Name)
            {
                if (Convert.ToInt32(cm_IndirectCostItems.SelectedValue) > 0)
                {
                    Resualt = true;
                }
                else
                {
                    return false;
                }
            }
            return Resualt;
        }
        #endregion My Method for my Form

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            if (btn.Caption == "Show")
            {

            }
        }
    }
}