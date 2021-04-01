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

namespace PSC_Cost_Control.Forms.Project_Code
{
    public partial class Frm_Categories_ProjectCode : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Categories_ProjectCode()
        {
            InitializeComponent();
        }



        #region My Method for my From
        void ClearAllData()
        {
            txt_Id.Clear();
            txt_Name.Clear();
        }
        void GetDatabyId(int Id)
        {

        }
        void GetAllData()
        {

        }
        void AddData(string Neme)
        {

        }
        void EditData(int Id ,string Name)
        {

        }
        void DeleteData(int Id)
        {

        }
        bool ValidationData()
        {
            if (string.IsNullOrWhiteSpace(txt_Name.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion My Method for my Form

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}