using DevExpress.XtraBars.Docking2010;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.ServicesBuilders;

namespace PSC_Cost_Control.Forms.Items_Registeration
{
    public partial class Frm_EditRegistertionBOQItem : DevExpress.XtraEditors.XtraForm
    {
        
        public Frm_EditRegistertionBOQItem()
        {
            InitializeComponent();
        }

        #region My Method for my From
        void AddData(string _Neme)
        {

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
    }
}