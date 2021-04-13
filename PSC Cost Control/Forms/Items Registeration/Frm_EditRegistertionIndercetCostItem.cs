using System;
using System.Windows.Forms;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices;
using PSC_Cost_Control.Services.DependencyApis;
using System.Linq;

namespace PSC_Cost_Control.Forms.Items_Registeration
{
    public partial class Frm_EditRegistertionIndercetCostItem : DevExpress.XtraEditors.XtraForm
    {
        public IProjectCodeService _IProjectCodeService;
        public IRegisterationService _RegisterationService;
        public ExternalAPIs _externalAPIs;
        public string BOQItemDescriptoin, ProjectCodeDesscription;
        public int BOQItemId = 0, ProjectCodeId = 0;
        public Frm_EditRegistertionIndercetCostItem()
        {
            InitializeComponent();
        }

        #region My Method for my From
        void AddData(string _Neme)
        {

        }
        void GetDataByBOQs(int Project, int BOQs)
        {
            if (Project > 0)
            {
                var ResaultBOQItem = _externalAPIs.GetBOQ_ItemsAsync(BOQs).Result;
                var CustomResaultBOQItem = from boq in ResaultBOQItem
                                           select new
                                           {
                                               BoqItemId = boq.Id,
                                               BOQItemDescription = boq.Description
                                           };
                DGV_BOQItem.DataSource = CustomResaultBOQItem;
                var ResaultBOQRegisteration = _RegisterationService.GetBOQRegisteration(Project).Result;
                var ResaultProjectCode = _IProjectCodeService.GetProjectCodes(Project).Result;
            }
        }

        void Registretion()
        {
            
            BOQItemDescriptoin = ProjectCodeDesscription = "";

            for (int i = 0; i < DGV_BOQItem.Rows.Count; i++)
            {
                if (DGV_BOQItem.Rows.Count > 0)
                {
                    bool isSelected = Convert.ToBoolean(DGV_BOQItem.Rows[i].Cells["ch_RegisterBOQItem"].Value);
                    if (isSelected)
                    {
                        BOQItemId = Convert.ToInt32(DGV_BOQItem.Rows[i].Cells["BoqItemId"].Value.ToString());
                        BOQItemDescriptoin = DGV_BOQItem.Rows[i].Cells["BOQItemDescription"].Value.ToString();
                        break;
                    }

                }

            }

            for (int i = 0; i < DGV_ProjectCode.Rows.Count; i++)
            {
                if (DGV_ProjectCode.Rows.Count > 0)
                {
                    bool isSelected = Convert.ToBoolean(DGV_ProjectCode.Rows[i].Cells["ch_ProjectCode"].Value);
                    if (isSelected)
                    {
                        ProjectCodeId = Convert.ToInt32(DGV_ProjectCode.Rows[i].Cells["ProjectCode_Id"].Value.ToString());
                        ProjectCodeDesscription = DGV_ProjectCode.Rows[i].Cells["ProjectCode_Description"].Value.ToString();
                        break;
                    }

                }

            }

            if (!string.IsNullOrEmpty(BOQItemDescriptoin) && !string.IsNullOrEmpty(ProjectCodeDesscription))
            {
                this.Close();
            }

        }
        #endregion My Method for my Form

        private void DGV_BOQItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_BOQItem.Columns[e.ColumnIndex].Name == "ch_RegisterBOQItem")
            {
                for (int i = 0; i < DGV_BOQItem.RowCount; i++)
                {
                    if (i != e.RowIndex)
                    {
                        DGV_BOQItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    }
                }
            }
        }

        private void DGV_ProjectCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_ProjectCode.Columns[e.ColumnIndex].Name == "ch_RegisterProjectCode")
            {
                for (int i = 0; i < DGV_ProjectCode.RowCount; i++)
                {
                    if (i != e.RowIndex)
                    {
                        DGV_ProjectCode.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    }
                }
            }
        }

        private void cm_BOQItemOld_DropDown(object sender, EventArgs e)
        {
            if (cm_BOQItemOld.SelectedIndex > 0)
            {
                GetDataByBOQs(Convert.ToInt32(txt_IdProject.Text), Convert.ToInt32(cm_BOQItemOld.SelectedValue));

            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Registretion();
        }
    }
}