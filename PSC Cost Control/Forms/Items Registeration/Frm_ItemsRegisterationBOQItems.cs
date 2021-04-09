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
    public partial class Frm_ItemsRegisterationBOQItems : DevExpress.XtraEditors.XtraForm
    {
        ItemsRegisterationService _itemsRegisterationService;

        public Frm_ItemsRegisterationBOQItems()
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

        }
        void GetData(string _State, int Project,int Fild)
        {

        }
        bool ValidationData(string _State)
        {
            bool Resualt = false;

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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}