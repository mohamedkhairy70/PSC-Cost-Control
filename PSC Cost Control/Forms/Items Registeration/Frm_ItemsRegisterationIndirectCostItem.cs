using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices;
using PSC_Cost_Control.Services.ServicesBuilders;
using PSC_Cost_Control.Services.DependencyApis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Forms.Items_Registeration
{
    public partial class Frm_ItemsRegisterationIndirectCostItem : DevExpress.XtraEditors.XtraForm
    {

        ExternalAPIs _externalAPIs;
        int ProjectId;

        public Frm_ItemsRegisterationIndirectCostItem()
        {
            InitializeComponent();
            
            _externalAPIs = new ExternalAPIs();
        }

        #region My Method for my From
        async void GetData(string ProjectName)
        {
            //check if ValidationData is not False
            if (!string.IsNullOrWhiteSpace(ProjectName))
            {
                var ResaultProjects = await _externalAPIs.SearchProjectsBYName(ProjectName);
                if (ResaultProjects.Any())
                {
                    ProjectId = Convert.ToInt32(ResaultProjects.FirstOrDefault().ContractId.ToString());
                    txt_Projects.Text = ResaultProjects.FirstOrDefault().Name;
                    var ResaultBOQs = await _externalAPIs.GetBOQsAsync(ProjectId);
                    var CustomResaultBOQs = from boq in ResaultBOQs
                                            join pro in ResaultProjects on boq.ContractId equals pro.ContractId
                                            select new { projectId = boq.Id, projectName = (boq.ContractId.ToString() + " " + boq.RevDate.ToString("MM/dd/yyyy")).ToString() };
                    if (ResaultBOQs.Any())
                    {
                        cm_SearchByIndirectCost.DataSource = CustomResaultBOQs.ToList();
                        cm_SearchByIndirectCost.ValueMember = "projectId";
                        cm_SearchByIndirectCost.DisplayMember = "projectName";
                    }

                    IProjectCodeService _IProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();

                    var ResaultProjectCode = await _IProjectCodeService.GetProjectCodes(ProjectId);
                    if (ResaultProjectCode.Any())
                    {
                        var CustomResaultProjectCode = from ProCode in ResaultProjectCode
                                                       select new { ProjectCode_Id = ProCode.Id, ProjectCode_Description = ProCode.Description };
                        var ResaultProjectCodeList = CustomResaultProjectCode.ToList();

                        DGV_ProjectCode.DataSource = ResaultProjectCodeList;
                    }
                }
            }
        }

        async void GetDataByBOQs(int Project, int BOQs)
        {
            if (Project > 0)
            {
                IProjectCodeService _IProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();
                IRegisterationService _RegisterationService = ServiceBuilder.Build<IRegisterationService>();
                var ResaultIndirectCostId = await _externalAPIs.GetIndirectItems(BOQs);
                var CustomResaultBOQItem = from boq in ResaultIndirectCostId
                                           select new
                                            {
                                               IndirectCostId = boq.Id,
                                               IndirectCostDescription = boq.Description 
                                            };
                var ResaultBOQItemList = CustomResaultBOQItem.ToList();
                DGV_IndirectCost.DataSource = ResaultBOQItemList;
                var ResaultIndirectCostRegisteration = await _RegisterationService.GetIndirectItemRegisteration(Project);
                var ResaultProjectCode = await _IProjectCodeService.GetProjectCodes(Project);
                var CustomResaultIndirectCosRegisteration = from boq in ResaultIndirectCostRegisteration
                                                            join IndirectCostId in ResaultIndirectCostId on boq.Indirect_Cost_Item_Id equals IndirectCostId.Id
                                                    join proCode in ResaultProjectCode on boq.Projcet_Code_Id equals proCode.Id
                                                    select new
                                                      {
                                                            BoqRegisterId =  boq.Id ,
                                                            BoqResisterIndirectCostId = boq.Indirect_Cost_Item_Id,
                                                            BoqResisterProjectCodeId = boq.Projcet_Code_Id,
                                                            BoqResisterIndirectCostDescription = IndirectCostId.Description,
                                                            BoqResisterProjectCodeDescription =  proCode.Description
                                                      };

                var IndirectCostRegisterationList = ResaultIndirectCostRegisteration.ToList();
                if (IndirectCostRegisterationList.Count > 0)
                {
                    DGV_RegistBOQItem.DataSource = IndirectCostRegisterationList;
                }
            }
        }

        async void SearchDataProjectCode(int Project, string ProDescription)
        {
            IProjectCodeService _IProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();
            if (!string.IsNullOrEmpty(ProDescription))
            {


                var ResaultProjectCode = await _IProjectCodeService.GetProjectCodes(Project);
                if (ResaultProjectCode.Any())
                {
                    var SearchProjectCode = ResaultProjectCode.Where(x => x.Description == ProDescription).ToList();
                    var CustomResaultProjectCode = from ProCode in ResaultProjectCode
                                                   select new { ProjectCode_Id = ProCode.Id, ProjectCode_Description = ProCode.Description };
                    var ResaultProjectCodeList = CustomResaultProjectCode.ToList();

                    DGV_ProjectCode.DataSource = ResaultProjectCodeList;
                }
            }
            else
            {
                var ResaultProjectCode = await _IProjectCodeService.GetProjectCodes(Project);
                if (ResaultProjectCode.Any())
                {
                    var CustomResaultProjectCode = from ProCode in ResaultProjectCode
                                                   select new { ProjectCode_Id = ProCode.Id, ProjectCode_Description = ProCode.Description };
                    var ResaultProjectCodeList = CustomResaultProjectCode.ToList();

                    DGV_ProjectCode.DataSource = ResaultProjectCodeList;
                }
            }
        }

        async void SearchDataIndirectCost(string BOQsIteme, int BOQs)
        {
            IRegisterationService _RegisterationService = ServiceBuilder.Build<IRegisterationService>();
            if (BOQs > 0)
            {
                if (!string.IsNullOrEmpty(BOQsIteme))
                {
                    var ResaultIndirectCostId = await _externalAPIs.GetIndirectItems(BOQs);
                    var CustomResaultBOQItem = from boq in ResaultIndirectCostId
                                               select new
                                               {
                                                   IndirectCostId = boq.Id,
                                                   IndirectCostDescription = boq.Description
                                               };
                    var ResaultBOQItemList = CustomResaultBOQItem.Where(x => x.IndirectCostDescription == BOQsIteme).ToList();
                    if (CustomResaultBOQItem.Any())
                    {
                        DGV_IndirectCost.DataSource = ResaultBOQItemList;
                    }
                    else
                    {
                        MessageBox.Show("Can not Find");
                    }
                }
                else
                {
                    var ResaultIndirectCostId = await _externalAPIs.GetIndirectItems(BOQs);
                    var CustomResaultBOQItem = from boq in ResaultIndirectCostId
                                               select new
                                               {
                                                   IndirectCostId = boq.Id,
                                                   IndirectCostDescription = boq.Description
                                               };
                    if (CustomResaultBOQItem.Any())
                    {
                        var ResaultBOQItemList = CustomResaultBOQItem.ToList();
                        DGV_IndirectCost.DataSource = ResaultBOQItemList;
                    }
                    else
                    {
                        MessageBox.Show("Can not Find");
                    }
                }
            }
        }

        async void SearchDataRegistraion(int Project, int BOQs, string ItemDescription)
        {
            if (Project > 0)
            {
                if (!string.IsNullOrEmpty(ItemDescription))
                {
                    IProjectCodeService _IProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();
                    IRegisterationService _RegisterationService = ServiceBuilder.Build<IRegisterationService>();
                    var ResaultIndirectCostId = await _externalAPIs.GetIndirectItems(BOQs);
                    var CustomResaultBOQItem = from boq in ResaultIndirectCostId
                                               select new
                                               {
                                                   IndirectCostId = boq.Id,
                                                   IndirectCostDescription = boq.Description
                                               };
                    if (ResaultIndirectCostId.Any())
                    {
                        var ResaultIndirectCostRegisteration = await _RegisterationService.GetIndirectItemRegisteration(Project);
                        var ResaultProjectCode = await _IProjectCodeService.GetProjectCodes(Project);
                        var CustomResaultIndirectCosRegisteration = from boq in ResaultIndirectCostRegisteration
                                                                    join IndirectCostId in ResaultIndirectCostId on boq.Indirect_Cost_Item_Id equals IndirectCostId.Id
                                                                    join proCode in ResaultProjectCode on boq.Projcet_Code_Id equals proCode.Id
                                                                    select new
                                                                    {
                                                                        BoqRegisterId = boq.Id,
                                                                        BoqResisterIndirectCostId = boq.Indirect_Cost_Item_Id,
                                                                        BoqResisterProjectCodeId = boq.Projcet_Code_Id,
                                                                        BoqResisterIndirectCostDescription = IndirectCostId.Description,
                                                                        BoqResisterProjectCodeDescription = proCode.Description
                                                                    };
                        var BOQRegisterationList = CustomResaultIndirectCosRegisteration.Where(x => x.BoqResisterIndirectCostDescription == ItemDescription || x.BoqResisterProjectCodeDescription == ItemDescription).ToList();
                        if (BOQRegisterationList.Where(x => x.BoqResisterIndirectCostDescription == ItemDescription).Any())
                        {
                            DGV_RegistBOQItem.DataSource = BOQRegisterationList;
                            
                        }
                    }
                }
                else
                {
                    GetDataByBOQs(Project, BOQs);
                }
            }
        }

        void ClreaData()
        {
            txt_Projects.Clear();
            txt_SearchByIndirectCost.Clear();
            txt_SearchByProjectCode.Clear();
            txt_SearchByRegistBOQItem.Clear();
            cm_SearchByIndirectCost.SelectedIndex = -1;
            ProjectId = 0;
        }

        void Registretion()
        {
            int IndirectCostRow, IndirectCostId = 0, ProjectCodeRow, ProjectCodeId = 0;
            string IndirectCostDescriptoin, ProjectCodeDesscription;
            IndirectCostDescriptoin = ProjectCodeDesscription = "";

            for (int i = 0; i < DGV_IndirectCost.Rows.Count; i++)
            {
                if (DGV_IndirectCost.Rows.Count > 0)
                {
                    bool isSelected = Convert.ToBoolean(DGV_IndirectCost.Rows[i].Cells["ch_RegisterIndirectCostItem"].Value);
                    if (isSelected)
                    {
                        IndirectCostId = Convert.ToInt32(DGV_IndirectCost.Rows[i].Cells["IndirectCostId"].Value.ToString());
                        IndirectCostRow = i;
                        IndirectCostDescriptoin = DGV_IndirectCost.Rows[i].Cells["IndirectCostDescription"].Value.ToString();
                        break;
                    }

                }

            }

            for (int i = 0; i < DGV_ProjectCode.Rows.Count; i++)
            {
                if (DGV_ProjectCode.Rows.Count > 0)
                {
                    bool isSelected = Convert.ToBoolean(DGV_ProjectCode.Rows[i].Cells["ch_RegisterProjectCode"].Value);
                    if (isSelected)
                    {
                        ProjectCodeId = Convert.ToInt32(DGV_ProjectCode.Rows[i].Cells["ProjectCode_Id"].Value.ToString());
                        ProjectCodeRow = i;
                        ProjectCodeDesscription = DGV_ProjectCode.Rows[i].Cells["ProjectCode_Description"].Value.ToString();
                        break;
                    }

                }

            }

            if (!string.IsNullOrEmpty(IndirectCostDescriptoin) && !string.IsNullOrEmpty(ProjectCodeDesscription))
            {
                DGV_RegistBOQItem.Rows.Add(1);
                int rowindex = DGV_RegistBOQItem.Rows.Count - 1;

                DGV_RegistBOQItem.Rows[rowindex].Cells["BoqRegisterId"].Value = 0;
                DGV_RegistBOQItem.Rows[rowindex].Cells["BoqResisterIndirectCostId"].Value = IndirectCostId;
                DGV_RegistBOQItem.Rows[rowindex].Cells["BoqResisterProjectCodeId"].Value = ProjectCodeId;
                DGV_RegistBOQItem.Rows[rowindex].Cells["BoqResisterIndirectCostDescription"].Value = IndirectCostDescriptoin;
                DGV_RegistBOQItem.Rows[rowindex].Cells["BoqResisterProjectCodeDescription"].Value = ProjectCodeDesscription;
            }

        }

        bool ValidationDataProjec()
        {
            bool Resualt = false;
            if (!string.IsNullOrEmpty(txt_Projects.Text))
            {
                Resualt = true;
            }
            else
            {
                MessageBox.Show("Can't Find Name Project");
               
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
            if(cm_SearchByIndirectCost.SelectedIndex > 0)
            {
                GetDataByBOQs(ProjectId, Convert.ToInt32(cm_SearchByIndirectCost.SelectedValue));

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
            Save();
        }
        async void Save()
        {
            if (ValidationDataProjec())
            {
                if (DGV_RegistBOQItem.Rows.Count > 0)
                {
                    IRegisterationService _RegisterationService = ServiceBuilder.Build<IRegisterationService>();
                    int IndirectCostId = 0, ProjectCodeId = 0, RegisterId = 0;
                    List<Models.C_Cost_Indirect_Project_Code_Summerizing> RegisterItem = new List<Models.C_Cost_Indirect_Project_Code_Summerizing>();
                    for (int i = 0; i < DGV_RegistBOQItem.RowCount; i++)
                    {
                        RegisterId = Convert.ToInt32(DGV_RegistBOQItem.Rows[i].Cells["BoqRegisterId"].Value.ToString());
                        IndirectCostId = Convert.ToInt32(DGV_RegistBOQItem.Rows[i].Cells["BoqResisterIndirectCostId"].Value.ToString());
                        ProjectCodeId = Convert.ToInt32(DGV_RegistBOQItem.Rows[i].Cells["BoqResisterProjectCodeId"].Value.ToString());
                        RegisterItem.Add(new Models.C_Cost_Indirect_Project_Code_Summerizing 
                        { Id = RegisterId, C_Cost_Project_Codes = new Models.C_Cost_Project_Codes {Id = ProjectCodeId },IndirectCostItems = new Models.IndirectCostItems { Id = IndirectCostId } });
                    }

                    var ResualtBOQRegisteration = await _RegisterationService.GetIndirectItemRegisteration(ProjectId);
                    if (ResualtBOQRegisteration.Any())
                    {
                        _RegisterationService.UpdateInDirectItems(ProjectId, RegisterItem);
                    }
                    else
                    {
                        _RegisterationService.RegisterInDirectItems(RegisterItem);
                    }

                    MessageBox.Show("The data has been saved successfully. ");
                    ClreaData();
                }
            }
        }
        private async void DGV_RegistBOQItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(DGV_RegistBOQItem.Columns[e.ColumnIndex].Name == "btn_RegisterEdit")
            {
                try
                {
                    Frm_EditRegistertionIndirectCostItem frm_Edit = new Frm_EditRegistertionIndirectCostItem();
                    IProjectCodeService _IProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();
                    IRegisterationService _RegisterationService = ServiceBuilder.Build<IRegisterationService>();
                    frm_Edit.DGV_ProjectCode.DataSource = DGV_ProjectCode.DataSource;

                    var ResaultProjects = await _externalAPIs.SearchProjectsBYName(txt_Projects.Text);
                    ProjectId = Convert.ToInt32(ResaultProjects.SingleOrDefault().ContractId.ToString());

                    frm_Edit._IProjectCodeService = _IProjectCodeService;
                    frm_Edit._externalAPIs = _externalAPIs;

                    frm_Edit.txt_NameProjectOld.Text = txt_Projects.Text;

                    frm_Edit.txt_IdProject.Text = ProjectId.ToString();

                    frm_Edit.txt_BOQItemOld.Text = DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqResisterBoqItemeDescription"].Value.ToString();
                    frm_Edit.txt_ProjectCodeItemOld.Text = DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqResisterProjectCodeDescription"].Value.ToString();
                    
                    frm_Edit.ShowDialog();

                    string _ProjectCodeDesscription;
                    _ProjectCodeDesscription = frm_Edit._ProjectCodeDesscription;
                    int _ProjectCodeId;
                    _ProjectCodeId = frm_Edit._ProjectCodeId;

                    if(!string.IsNullOrEmpty(_ProjectCodeDesscription))
                    {
                        DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqResisterProjectCodeDescription"].Value = _ProjectCodeDesscription;
                        DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqResisterProjectCodeId"].Value = _ProjectCodeId;
                    }
                }
                catch { }
            }
        }

        private void txt_SearchByIndirectCost_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                var ValueSaerch = txt_SearchByIndirectCost.Text;
                if (!string.IsNullOrEmpty(ValueSaerch))
                {
                    SearchDataIndirectCost(ValueSaerch, Convert.ToInt32(cm_SearchByIndirectCost.SelectedValue));
                }
            }
        }

        private void txt_SearchByProjectCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var ValueSaerch = txt_SearchByProjectCode.Text;
                if (!string.IsNullOrEmpty(ValueSaerch))
                {
                    SearchDataProjectCode(ProjectId, ValueSaerch);
                }
            }
        }

        private void txt_SearchByRegistBOQItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var ValueSaerch = txt_SearchByRegistBOQItem.Text;
                if (!string.IsNullOrEmpty(ValueSaerch))
                {
                    SearchDataRegistraion(ProjectId, Convert.ToInt32(cm_SearchByIndirectCost.SelectedValue), ValueSaerch);
                }
            }
        }

        private void DGV_RegistBOQItem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
    }
