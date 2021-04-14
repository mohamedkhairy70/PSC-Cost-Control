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
    public partial class Frm_ItemsRegisterationIndirectCostItem : DevExpress.XtraEditors.XtraForm
    {
        IProjectCodeService _IProjectCodeService;
        IRegisterationService _RegisterationService;
        ExternalAPIs _externalAPIs;
        int ProjectId;
        public Frm_ItemsRegisterationIndirectCostItem()
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
                var ResaultIndirectCostItem = _externalAPIs.GetIndirectItems(BOQs).Result;
                var CustomResaultIndirectCostItem = from boq in ResaultIndirectCostItem
                                                    select new
                                                    {
                                                        IndirectCostItemId = boq.Id,
                                                        IndirectCostItemDescription = boq.Description 
                                                    };
                DGV_IndirectCostItem.DataSource = CustomResaultIndirectCostItem;
                var ResaultBOQRegisteration = _RegisterationService.GetBOQRegisteration(Project).Result;
                var ResaultProjectCode = _IProjectCodeService.GetProjectCodes(Project).Result;
                var CustomResaultBOQRegisteration = from boq in ResaultBOQRegisteration
                                                    join IndirectCostItem in CustomResaultIndirectCostItem on boq.Boq_Item_Id equals IndirectCostItem.IndirectCostItemId
                                                    join proCode in ResaultProjectCode on boq.Project_Code_Id equals proCode.Id
                                                    select new
                                                      {
                                                            BoqRegisterId =  boq.Id ,
                                                            BoqResisterIndirectCostItemId = boq.Boq_Item_Id,
                                                            BoqResisterProjectCodeId = boq.Project_Code_Id,
                                                            BoqResisterIndirectCostItemDescription = IndirectCostItem.IndirectCostItemDescription,
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
            int IndirectCostItemRow, IndirectCostItemId = 0, ProjectCodeRow, ProjectCodeId = 0;
            string IndirectCostItemDescriptoin, ProjectCodeDesscription;
            IndirectCostItemDescriptoin = ProjectCodeDesscription = "";

            for (int i = 0; i < DGV_IndirectCostItem.Rows.Count; i++)
            {
                if (DGV_IndirectCostItem.Rows.Count > 0)
                {
                    bool isSelected = Convert.ToBoolean(DGV_IndirectCostItem.Rows[i].Cells["ch_RegisterIndirectCostItem"].Value);
                    if (isSelected)
                    {
                        IndirectCostItemId = Convert.ToInt32(DGV_IndirectCostItem.Rows[i].Cells["BoqResisterIndirectCostItemId"].Value.ToString());
                        IndirectCostItemRow = i;
                        IndirectCostItemDescriptoin = DGV_IndirectCostItem.Rows[i].Cells["BoqResisterIndirectCostItemDescription"].Value.ToString();
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

            if (!string.IsNullOrEmpty(IndirectCostItemDescriptoin) && !string.IsNullOrEmpty(ProjectCodeDesscription))
            {
                DGV_RegistBOQItem.Rows.Add(1);
                int rowindex = DGV_RegistBOQItem.Rows.Count - 1;
                DGV_RegistBOQItem.Rows[rowindex].Cells["BoqResisterProjectCodeId"].Value = 0;
                DGV_RegistBOQItem.Rows[rowindex].Cells["BoqRegisterIndirectCostItemDescription"].Value = IndirectCostItemDescriptoin;
                DGV_RegistBOQItem.Rows[rowindex].Cells["BoqRegisterProjectCodeDescription"].Value = ProjectCodeDesscription;
                DGV_RegistBOQItem.Rows[rowindex].Cells["BoqResisterIndirectCostItemeId"].Value = IndirectCostItemId;
                DGV_RegistBOQItem.Rows[rowindex].Cells["BoqRegisterProjectCodeDescription"].Value = ProjectCodeId;
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
                    int IndirectCostItemId = 0, ProjectCodeId = 0, RegisterId = 0;
                    List<Models.C_Cost_Indirect_Project_Code_Summerizing> RegisterItem = new List<Models.C_Cost_Indirect_Project_Code_Summerizing>();
                    for (int i = 0; i < DGV_RegistBOQItem.RowCount; i++)
                    {
                        RegisterId = Convert.ToInt32(DGV_RegistBOQItem.Rows[i].Cells["BoqResisterProjectCodeId"].Value.ToString());
                        IndirectCostItemId = Convert.ToInt32(DGV_RegistBOQItem.Rows[i].Cells["BoqResisterIndirectCostItemeId"].Value.ToString());
                        ProjectCodeId = Convert.ToInt32(DGV_RegistBOQItem.Rows[i].Cells["BoqRegisterProjectCodeId"].Value.ToString());
                        RegisterItem.Add(new Models.C_Cost_Indirect_Project_Code_Summerizing { Id = RegisterId,Indirect_Cost_Item_Id = IndirectCostItemId,Projcet_Code_Id=ProjectCodeId });
                    }
                    if (_RegisterationService.GetIndirectItemRegisteration(ProjectId).Result.Any())
                    {
                        _RegisterationService.UpdateInDirectItems(ProjectId, RegisterItem);
                    }
                    else
                    {
                        _RegisterationService.RegisterInDirectItems(RegisterItem);
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
                    Frm_EditRegistertionIndirectCostItem frm_Edit = new Frm_EditRegistertionIndirectCostItem();
                    frm_Edit.DGV_IndirectCostItem.DataSource = DGV_IndirectCostItem.DataSource;
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

                    frm_Edit.txt_BOQItemOld.Text = DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqRegisterIndirectCostItemDescription"].Value.ToString();
                    frm_Edit.txt_ProjectCodeItemOld.Text = DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqResisterProjectCodeDescription"].Value.ToString();
                    
                    frm_Edit.ShowDialog();

                    string _IndirectCostItemDescriptoin, _ProjectCodeDesscription;
                    int _IndirectCostItemId, _ProjectCodeId;

                    _IndirectCostItemDescriptoin = frm_Edit._IndirectCostItemDescriptoin;
                    _ProjectCodeDesscription = frm_Edit._ProjectCodeDesscription;
                    
                    _IndirectCostItemId = frm_Edit._IndirectCostItemId;
                    _ProjectCodeId = frm_Edit._ProjectCodeId;

                    if(!string.IsNullOrEmpty(_IndirectCostItemDescriptoin) && !string.IsNullOrEmpty(_ProjectCodeDesscription))
                    {
                        DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqRegisterIndirectCostItemDescription"].Value = _IndirectCostItemDescriptoin;
                        DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqRegisterProjectCodeDescription"].Value = _ProjectCodeDesscription;
                        DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqResisterIndirectCostItemeId"].Value = _IndirectCostItemId;
                        DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqRegisterProjectCodeId"].Value = _ProjectCodeId;
                    }
                }
                catch { }
            }
        }
    }
}