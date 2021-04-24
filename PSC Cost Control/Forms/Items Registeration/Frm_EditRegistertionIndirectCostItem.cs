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
        public ExternalAPIs _externalAPIs;
        public string _ProjectCodeDesscription;
        public int _ProjectCodeId = 0;
        public Frm_EditRegistertionIndirectCostItem()
        {
            InitializeComponent();
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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            _ProjectCodeDesscription = "";


            for (int i = 0; i < DGV_ProjectCode.Rows.Count; i++)
            {
                bool isSelected = Convert.ToBoolean(DGV_ProjectCode.Rows[i].Cells["ch_RegisterProjectCode"].Value);
                if (isSelected)
                {
                    _ProjectCodeId = Convert.ToInt32(DGV_ProjectCode.Rows[i].Cells["ProjectCode_Id"].Value.ToString());
                    _ProjectCodeDesscription = DGV_ProjectCode.Rows[i].Cells["ProjectCode_Description"].Value.ToString();
                    break;
                       
                }
            }
             Close();
        }
    }
}