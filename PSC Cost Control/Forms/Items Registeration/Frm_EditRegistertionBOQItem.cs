using System;
using System.Windows.Forms;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices;
using PSC_Cost_Control.Services.DependencyApis;
using System.Linq;

namespace PSC_Cost_Control.Forms.Items_Registeration
{
    public partial class Frm_EditRegistertionBOQItem : DevExpress.XtraEditors.XtraForm
    {
        public IProjectCodeService _IProjectCodeService;
        public string ProjectCodeDesscription;
        public int ProjectCodeId = 0;
        public Frm_EditRegistertionBOQItem()
        {
            InitializeComponent();
        }

        #region My Method for my From


        void Registretion()
        {
            
             ProjectCodeDesscription = "";


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

            if ( !string.IsNullOrEmpty(ProjectCodeDesscription))
            {
                this.Close();
            }

        }
        #endregion My Method for my Form

        private void DGV_BOQItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            ProjectCodeDesscription = "";

            for (int i = 0; i < DGV_ProjectCode.Rows.Count; i++)
            {
                bool isSelected = Convert.ToBoolean(DGV_ProjectCode.Rows[i].Cells["ch_RegisterProjectCode"].Value);
                if (isSelected)
                {
                    ProjectCodeId = Convert.ToInt32(DGV_ProjectCode.Rows[i].Cells["ProjectCode_Id"].Value.ToString());
                    ProjectCodeDesscription = DGV_ProjectCode.Rows[i].Cells["ProjectCode_Description"].Value.ToString();
                    break;
                    
                }
            }
            Close();
        }
    }
}