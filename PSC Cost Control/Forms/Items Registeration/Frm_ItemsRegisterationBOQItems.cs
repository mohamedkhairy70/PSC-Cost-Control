using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices;
using PSC_Cost_Control.Services.ServicesBuilders;
using PSC_Cost_Control.Services.DependencyApis;

namespace PSC_Cost_Control.Forms.Items_Registeration
{
    public partial class Frm_ItemsRegisterationBOQItems : DevExpress.XtraEditors.XtraForm
    {
        IProjectCodeService _IProjectCodeService;
        IRegisterationService _RegisterationService;
        ExternalAPIs _externalAPIs;
        int ProjectId;
        public Frm_ItemsRegisterationBOQItems()
        {
            InitializeComponent();
            _IProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();
            _externalAPIs = new ExternalAPIs(new Models.ApplicationContext());
        }

        #region My Method for my From
        void GetData(string ProjectName)
        {
            //check if ValidationData is not False
            if (!string.IsNullOrWhiteSpace(ProjectName))
            {
                var ResaultProjects = _externalAPIs.SearchProjectsBYName(ProjectName).Result;
                ProjectId = Convert.ToInt32(ResaultProjects.SingleOrDefault().ContractId.ToString());

                var ResaultBOQs = _externalAPIs.GetBOQsAsync(ProjectId).Result;
                var CustomResaultBOQs = from boq in ResaultBOQs
                            join pro in ResaultProjects on boq.ContractId equals pro.ContractId
                            select new  { ProjectName = boq.Id, ProjectId = boq.Id};

                cm_BOQItem.DataSource = CustomResaultBOQs.ToList();
                cm_BOQItem.ValueMember = "ProjectId";
                cm_BOQItem.DisplayMember = "ProjectName";

                

                
                var ResaultProjectCode = _IProjectCodeService.GetProjectCodes(ProjectId).Result;
                var CustomResaultProjectCode = from ProCode in ResaultProjectCode
                                              select new { ProjectCode_Id = ProCode.Id, ProjectCode_Description = ProCode.Description };
                
                
                DGV_ProjectCode.DataSource = CustomResaultProjectCode;
            }
        }
        void GetDataByBOQs(int Project, int BOQs)
        {
            if(Project > 0)
            {
                DGV_BOQItem.DataSource = _externalAPIs.GetBOQ_ItemsAsync(BOQs).Result; 
                var ResaultBOQRegisteration = _RegisterationService.GetBOQRegisteration(ProjectId).Result;
                var CustomResaultBOQRegisteration = from boq in ResaultBOQRegisteration
                                                    from Procode in Models.ApplicationContext.C_Cost_Project_Codes
                                          {

                };
                DGV_RegistBOQItem.DataSource = ResaultBOQRegisteration;
            }
        }
        void ClreaData()
        {
            txt_Projects.Clear();
            txt_SearchByBOQItem.Clear();
            txt_SearchByProjectCode.Clear();
            txt_SearchByRegistBOQItem.Clear();
            cm_BOQItem.SelectedIndex = -1;
            ProjectId = 0;
        }
        void Registretion()
        {
            int BOQItemRow;
            string NameBOQ;
            for (int i = 0; i < DGV_BOQItem.Rows.Count; i++)
            {
                if (DGV_BOQItem.Rows.Count > 0)
                {
                    bool isSelected = Convert.ToBoolean(DGV_BOQItem.Rows[i].Cells["ch_RegisterBOQItem"].Value);
                    if (isSelected)
                    {

                        BOQItemRow = i;
                        NameBOQ = DGV_BOQItem.Rows[i].Cells["ProjectName"].Value.ToString();

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

                        BOQItemRow = i;
                        NameBOQ = DGV_ProjectCode.Rows[i].Cells["ProjectCode_Description"].Value.ToString();

                    }

                }

            }

        }
        bool ValidationDataProjec(string _State)
        {
            bool Resualt = false;

            return Resualt;
        }
        #endregion My Method for my Form

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_Projects_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                GetData(txt_Projects.Text);
            }
        }

        private void cm_BOQItem_DropDown(object sender, EventArgs e)
        {
            if(cm_BOQItem.SelectedIndex > 0)
            {
                GetDataByBOQs(ProjectId, Convert.ToInt32(cm_BOQItem.SelectedValue));

            }
        }

        private void Frm_ItemsRegisterationBOQItems_Load(object sender, EventArgs e)
        {
            ClreaData();
        }
    }
}