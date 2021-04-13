using System;
using System.Windows.Forms;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices;
using PSC_Cost_Control.Services.DependencyApis;
using System.Linq;

namespace PSC_Cost_Control.Forms.Items_Registeration
{
    public partial class Frm_EditRegistertionIndirectCostItem : DevExpress.XtraEditors.XtraForm
    {
        public IProjectCodeService _IProjectCodeService;
        public IRegisterationService _RegisterationService;
        public ExternalAPIs _externalAPIs;
        public string _IndirectCostItemDescriptoin, _ProjectCodeDesscription;
        public int _IndirectCostItemId = 0, _ProjectCodeId = 0;
        public Frm_EditRegistertionIndirectCostItem()
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
                var ResaultIndirectCostItem = _externalAPIs.GetIndirectItems(BOQs).Result;
                var CustomResaultIndirectCostItem = from boq in ResaultIndirectCostItem
                                           select new
                                           {
                                               IndirectCostItemId = boq.Id,
                                               IndirectCostItemDescription = boq.Description
                                           };
                DGV_IndirectCostItem.DataSource = CustomResaultIndirectCostItem;
                var ResaultBOQRegisteration = _RegisterationService.GetIndirectItemRegisteration(Project).Result;
                var ResaultProjectCode = _IProjectCodeService.GetProjectCodes(Project).Result;
            }
        }

        void Registretion()
        {

            _IndirectCostItemDescriptoin = _ProjectCodeDesscription = "";

            for (int i = 0; i < DGV_IndirectCostItem.Rows.Count; i++)
            {
                if (DGV_IndirectCostItem.Rows.Count > 0)
                {
                    bool isSelected = Convert.ToBoolean(DGV_IndirectCostItem.Rows[i].Cells["ch_RegisterIndirectCostItem"].Value);
                    if (isSelected)
                    {
                        _IndirectCostItemId = Convert.ToInt32(DGV_IndirectCostItem.Rows[i].Cells["IndirectCostItemId"].Value.ToString());
                        _IndirectCostItemDescriptoin = DGV_IndirectCostItem.Rows[i].Cells["IndirectCostItemDescription"].Value.ToString();
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
                        _ProjectCodeId = Convert.ToInt32(DGV_ProjectCode.Rows[i].Cells["ProjectCode_Id"].Value.ToString());
                        _ProjectCodeDesscription = DGV_ProjectCode.Rows[i].Cells["ProjectCode_Description"].Value.ToString();
                        break;
                    }

                }

            }

            if (!string.IsNullOrEmpty(_IndirectCostItemDescriptoin) && !string.IsNullOrEmpty(_ProjectCodeDesscription))
            {
                this.Close();
            }

        }
        #endregion My Method for my Form

        private void DGV_BOQItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_IndirectCostItem.Columns[e.ColumnIndex].Name == "ch_RegisterIndirectCostItem")
            {
                for (int i = 0; i < DGV_IndirectCostItem.RowCount; i++)
                {
                    if (i != e.RowIndex)
                    {
                        DGV_IndirectCostItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
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