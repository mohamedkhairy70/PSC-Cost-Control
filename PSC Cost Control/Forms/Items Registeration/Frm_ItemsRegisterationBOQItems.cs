using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices;
using PSC_Cost_Control.Services.ServicesBuilders;
using PSC_Cost_Control.Services.DependencyApis;
using System.Collections.Generic;

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
            _RegisterationService = ServiceBuilder.Build<IRegisterationService>();
            _externalAPIs = ServiceBuilder.Build<ExternalAPIs>();
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
                var CustomResaultBOQRegisteration = from boq in ResaultBOQRegisteration
                                                    join BoqItem in ResaultBOQItem on boq.Boq_Item_Id equals BoqItem.BOQId
                                                    join proCode in ResaultProjectCode on boq.Project_Code_Id equals proCode.Id
                                                    select new
                                                      {
                                                            BoqRegisterId =  boq.Id ,
                                                            BoqResisterBoqItemeId = boq.Boq_Item_Id,
                                                            BoqResisterProjectCodeId = boq.Project_Code_Id,
                                                            BoqResisterBoqItemeDescription = BoqItem.Description,
                                                            BoqResisterProjectCodeDescription =  proCode.Description
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
            int BOQItemRow, BOQItemId = 0, ProjectCodeRow, ProjectCodeId = 0;
            string BOQItemDescriptoin, ProjectCodeDesscription;
            BOQItemDescriptoin = ProjectCodeDesscription = "";

            for (int i = 0; i < DGV_BOQItem.Rows.Count; i++)
            {
                if (DGV_BOQItem.Rows.Count > 0)
                {
                    bool isSelected = Convert.ToBoolean(DGV_BOQItem.Rows[i].Cells["ch_RegisterBOQItem"].Value);
                    if (isSelected)
                    {
                        BOQItemId = Convert.ToInt32(DGV_BOQItem.Rows[i].Cells["BoqItemId"].Value.ToString());
                        BOQItemRow = i;
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
                        ProjectCodeRow = i;
                        ProjectCodeDesscription = DGV_ProjectCode.Rows[i].Cells["ProjectCode_Description"].Value.ToString();
                        break;
                    }

                }

            }

            if (!string.IsNullOrEmpty(BOQItemDescriptoin) && !string.IsNullOrEmpty(ProjectCodeDesscription))
            {
                DGV_RegistBOQItem.Rows.Add(1);
                int rowindex = DGV_RegistBOQItem.Rows.Count - 1;
                DGV_RegistBOQItem.Rows[rowindex].Cells[0].Value = 0;
                DGV_RegistBOQItem.Rows[rowindex].Cells[1].Value = BOQItemDescriptoin;
                DGV_RegistBOQItem.Rows[rowindex].Cells[2].Value = ProjectCodeDesscription;
                DGV_RegistBOQItem.Rows[rowindex].Cells[3].Value = BOQItemId;
                DGV_RegistBOQItem.Rows[rowindex].Cells[4].Value = ProjectCodeId;
            }

        }
        bool ValidationDataProjec()
        {
            bool Resualt = false;
            if (string.IsNullOrEmpty(txt_Projects.Text))
            {
                MessageBox.Show("Can't Find Name Project");                
                Resualt = false;
            }
            else
            {
                return false;
            }
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

        private void btn_Regiter_Click(object sender, EventArgs e)
        {
            Registretion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidationDataProjec())
            {
                if (DGV_RegistBOQItem.Rows.Count > 0)
                {
                    int BOQItemId = 0, ProjectCodeId = 0, RegisterId = 0;
                    List<Models.C_Cost_Project_Codes_Items> RegisterItem = new List<Models.C_Cost_Project_Codes_Items>();
                    for (int i = 0; i < DGV_RegistBOQItem.RowCount; i++)
                    {
                        RegisterId = Convert.ToInt32(DGV_RegistBOQItem.Rows[i].Cells[0].Value.ToString());
                        BOQItemId = Convert.ToInt32(DGV_RegistBOQItem.Rows[i].Cells[3].Value.ToString());
                        ProjectCodeId = Convert.ToInt32(DGV_RegistBOQItem.Rows[i].Cells[4].Value.ToString());
                        RegisterItem.Add(new Models.C_Cost_Project_Codes_Items { Id = RegisterId, Boq_Item_Id = BOQItemId, Project_Code_Id = ProjectCodeId });
                    }
                    if (_RegisterationService.GetBOQRegisteration(ProjectId).Result.Any())
                    {
                        _RegisterationService.UpdateBOQItems(ProjectId, RegisterItem);
                    }
                    else
                    {
                        _RegisterationService.RegisterBOQItems(RegisterItem);
                    }
                    
                    
                }
            }
        }

        private void DGV_RegistBOQItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(DGV_RegistBOQItem.Columns[e.ColumnIndex].Name == "btn_RegisterEdit")
            {
                try
                {
                    Frm_EditRegistertionBOQItem frm_Edit = new Frm_EditRegistertionBOQItem();
                    frm_Edit.DGV_BOQItem.DataSource = DGV_BOQItem.DataSource;
                    frm_Edit.DGV_ProjectCode.DataSource = DGV_ProjectCode.DataSource;

                    var ResaultProjects = _externalAPIs.SearchProjectsBYName(txt_Projects.Text).Result;
                    ProjectId = Convert.ToInt32(ResaultProjects.SingleOrDefault().ContractId.ToString());
                    var ResaultBOQs = _externalAPIs.GetBOQsAsync(ProjectId).Result;
                    var CustomResaultBOQs = from boq in ResaultBOQs
                                            join pro in ResaultProjects on boq.ContractId equals pro.ContractId
                                            select new { ProjectName = boq.Id, ProjectId = boq.Id };

                    frm_Edit.cm_BOQItemOld.DataSource = CustomResaultBOQs.ToList();
                    frm_Edit.cm_BOQItemOld.ValueMember = "ProjectId";
                    frm_Edit.cm_BOQItemOld.DisplayMember = "ProjectName";

                    frm_Edit._IProjectCodeService = _IProjectCodeService;
                    frm_Edit._RegisterationService = _RegisterationService;
                    frm_Edit._externalAPIs = _externalAPIs;

                    frm_Edit.txt_NameProjectOld.Text = txt_Projects.Text;

                    frm_Edit.txt_IdProject.Text = ProjectId.ToString();

                    frm_Edit.txt_BOQItemOld.Text = DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqResisterBoqItemeDescription"].Value.ToString();
                    frm_Edit.txt_ProjectCodeItemOld.Text = DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqResisterProjectCodeDescription"].Value.ToString();
                    
                    frm_Edit.ShowDialog();

                    string _BOQItemDescriptoin, _ProjectCodeDesscription;
                    _BOQItemDescriptoin = frm_Edit.BOQItemDescriptoin;
                    _ProjectCodeDesscription = frm_Edit.ProjectCodeDesscription;
                    int _BOQItemId, _ProjectCodeId;
                    _BOQItemId = frm_Edit.BOQItemId;
                    _ProjectCodeId = frm_Edit.ProjectCodeId;

                    if(!string.IsNullOrEmpty(_BOQItemDescriptoin) && !string.IsNullOrEmpty(_ProjectCodeDesscription))
                    {
                        DGV_RegistBOQItem.Rows[e.RowIndex].Cells[1].Value = _BOQItemDescriptoin;
                        DGV_RegistBOQItem.Rows[e.RowIndex].Cells[2].Value = _ProjectCodeDesscription;
                        DGV_RegistBOQItem.Rows[e.RowIndex].Cells[3].Value = _BOQItemId;
                        DGV_RegistBOQItem.Rows[e.RowIndex].Cells[4].Value = _ProjectCodeId;
                    }
                }
                catch { }
            }
        }
    }
}