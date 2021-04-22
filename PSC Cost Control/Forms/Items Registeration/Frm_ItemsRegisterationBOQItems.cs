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
using System.Reflection;

namespace PSC_Cost_Control.Forms.Items_Registeration
{
    public partial class Frm_ItemsRegisterationBOQItems : DevExpress.XtraEditors.XtraForm
    {

        ExternalAPIs _externalAPIs;
        int ProjectId;

        public Frm_ItemsRegisterationBOQItems()
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
                    var OneResualt = ResaultProjects.First();
                    ProjectId = OneResualt.ContractId;
                    txt_Projects.Text = OneResualt.Name;
                    var ResaultBOQs = await _externalAPIs.GetBOQsAsync(ProjectId);
                    var CustomResaultBOQs = from boq in ResaultBOQs
                                            join pro in ResaultProjects on boq.ContractId equals pro.ContractId
                                            select new { projectId = boq.Id, projectName = (boq.ContractId.ToString() + " " + boq.RevDate.ToString("MM/dd/yyyy") ) };
                    if (ResaultBOQs.Any())
                    {
                        cm_BOQItem.DataSource = CustomResaultBOQs.ToList();
                        cm_BOQItem.ValueMember = "projectId";
                        cm_BOQItem.DisplayMember = "projectName";
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
        async void SearchDataBOQsItem(string BOQsIteme,int BOQs)
        {
            IRegisterationService _RegisterationService = ServiceBuilder.Build<IRegisterationService>();
            if (BOQs > 0)
            {
                if (!string.IsNullOrEmpty(BOQsIteme))
                {
                    var ResaultBOQItem = await _externalAPIs.GetBOQ_ItemsAsync(BOQs);
                    var CustomResaultBOQItem = from boq in ResaultBOQItem
                                               select new
                                               {
                                                   BoqItemId = boq.Id,
                                                   BOQItemDescription = boq.Description
                                               };
                    if (CustomResaultBOQItem.Any())
                    {
                        var ResaultBOQItemList = CustomResaultBOQItem.Where(x => x.BOQItemDescription == BOQsIteme).ToList();
                        DGV_BOQItem.DataSource = ResaultBOQItemList;
                    }
                }
                else
                {
                    var ResaultBOQItem = await _externalAPIs.GetBOQ_ItemsAsync(BOQs);
                    var CustomResaultBOQItem = from boq in ResaultBOQItem
                                               select new
                                               {
                                                   BoqItemId = boq.Id,
                                                   BOQItemDescription = boq.Description
                                               };
                    if (CustomResaultBOQItem.Any())
                    {
                        var ResaultBOQItemList = CustomResaultBOQItem.ToList();
                        DGV_BOQItem.DataSource = ResaultBOQItemList;
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
                    var ResaultBOQItem = await _externalAPIs.GetBOQ_ItemsAsync(BOQs);
                    var CustomResaultBOQItem = from boq in ResaultBOQItem
                                               select new
                                               {
                                                   BoqItemId = boq.Id,
                                                   BOQItemDescription = boq.Description
                                               };
                    if (CustomResaultBOQItem.Any())
                    {
                        var ResaultBOQRegisteration = await _RegisterationService.GetBOQRegisteration(Project);
                        var ResaultProjectCode = await _IProjectCodeService.GetProjectCodes(Project);
                        var CustomResaultBOQRegisteration = from boq in ResaultBOQRegisteration
                                                            join BoqItem in ResaultBOQItem on boq.Boq_Item_Id equals BoqItem.BOQId
                                                            join proCode in ResaultProjectCode on boq.Project_Code_Id equals proCode.Id
                                                            select new
                                                            {
                                                                BoqRegisterId = boq.Id,
                                                                BoqResisterBoqItemeId = boq.Boq_Item_Id,
                                                                BoqResisterProjectCodeId = boq.Project_Code_Id,
                                                                BoqResisterBoqItemeDescription = BoqItem.Description,
                                                                BoqResisterProjectCodeDescription = proCode.Description
                                                            };
                        var BOQRegisterationList = CustomResaultBOQRegisteration.Where(x => x.BoqResisterBoqItemeDescription == ItemDescription || x.BoqResisterProjectCodeDescription == ItemDescription).ToList();
                        if (BOQRegisterationList.Any())
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
        async void GetDataByBOQs(int Project, int BOQs)
        {
            if (Project > 0)
            {
                IProjectCodeService _IProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();
                IRegisterationService _RegisterationService = ServiceBuilder.Build<IRegisterationService>();
                var ResaultBOQItem = await _externalAPIs.GetBOQ_ItemsAsync(BOQs);
                var CustomResaultBOQItem = from boq in ResaultBOQItem
                                           select new
                                            {
                                               BoqItemId = boq.Id,
                                               BOQItemDescription = boq.Description 
                                            };
                if (CustomResaultBOQItem.Any())
                {
                    var ResaultBOQItemList = CustomResaultBOQItem.ToList();
                    DGV_BOQItem.DataSource = ResaultBOQItemList;
                    var ResaultBOQRegisteration = await _RegisterationService.GetBOQRegisteration(Project);
                    var ResaultProjectCode = await _IProjectCodeService.GetProjectCodes(Project);
                    var CustomResaultBOQRegisteration = from boq in ResaultBOQRegisteration
                                                        join BoqItem in ResaultBOQItem on boq.Boq_Item_Id equals BoqItem.Id
                                                        join proCode in ResaultProjectCode on boq.Project_Code_Id equals proCode.Id
                                                        select new
                                                        {
                                                            BoqRegisterId = boq.Id,
                                                            BoqResisterBoqItemeId = boq.Boq_Item_Id,
                                                            BoqResisterProjectCodeId = boq.Project_Code_Id,
                                                            BoqResisterBoqItemeDescription = BoqItem.Description,
                                                            BoqResisterProjectCodeDescription = proCode.Description
                                                        };

                    DataTable dt = LINQResultToDataTable(CustomResaultBOQRegisteration);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow DR = dtGridView.NewRow();
                        DR[0] = dt.Rows[i][0];
                        DR[1] = dt.Rows[i][1];
                        DR[2] = dt.Rows[i][2];
                        DR[3] = dt.Rows[i][3];
                        DR[4] = dt.Rows[i][4];
                        dtGridView.Rows.Add(DR);
                        DGV_RegistBOQItem.DataSource = dtGridView;
                    }
                }
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

        private DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] columns = null;

            if (Linqlist == null) return dt;
            foreach (T Record in Linqlist)
            {

                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }

                DataRow dr = dt.NewRow();

                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }

                dt.Rows.Add(dr);
            }
            return dt;
        }
        DataTable dtGridView = new DataTable();
        void CreateDataTable()
        {
            //لكي الضف حقول في الداتات جريد فيو 
            dtGridView.Columns.Clear();
            dtGridView.Columns.Add(new DataColumn { ColumnName = "BoqRegisterId" });
            dtGridView.Columns.Add(new DataColumn { ColumnName = "BoqResisterBoqItemeId" });
            dtGridView.Columns.Add(new DataColumn { ColumnName = "BoqResisterProjectCodeId" });
            dtGridView.Columns.Add(new DataColumn { ColumnName = "BoqResisterBoqItemeDescription" });
            dtGridView.Columns.Add(new DataColumn { ColumnName = "BoqResisterProjectCodeDescription" });



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

            if (!string.IsNullOrEmpty(BOQItemDescriptoin) && !string.IsNullOrEmpty(ProjectCodeDesscription))
            {
                DataRow DR = dtGridView.NewRow();
                DR[0] = 0;
                DR[1] = BOQItemId;
                DR[2] = ProjectCodeId;
                DR[3] = BOQItemDescriptoin;
                DR[4] = ProjectCodeDesscription;
                dtGridView.Rows.Add(DR);
                DGV_RegistBOQItem.DataSource = dtGridView;
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
            if(cm_BOQItem.SelectedIndex > 0)
            {
                GetDataByBOQs(ProjectId, Convert.ToInt32(cm_BOQItem.SelectedValue));

            }
        }

        private void Frm_ItemsRegisterationBOQItems_Load(object sender, EventArgs e)
        {
            ClreaData();
            CreateDataTable();
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
                    int BOQItemId = 0, ProjectCodeId = 0, RegisterId = 0;
                    List<Models.C_Cost_Project_Codes_Items> RegisterItem = new List<Models.C_Cost_Project_Codes_Items>();
                    for (int i = 0; i < DGV_RegistBOQItem.RowCount; i++)
                    {
                        RegisterId = Convert.ToInt32(DGV_RegistBOQItem.Rows[i].Cells["BoqRegisterId"].Value.ToString());
                        BOQItemId = Convert.ToInt32(DGV_RegistBOQItem.Rows[i].Cells["BoqResisterBoqItemeId"].Value.ToString());
                        ProjectCodeId = Convert.ToInt32(DGV_RegistBOQItem.Rows[i].Cells["BoqResisterProjectCodeId"].Value.ToString());
                        RegisterItem.Add(new Models.C_Cost_Project_Codes_Items 
                        { Id = RegisterId,BOQ_Items = new Models.BOQ_Items { Id = BOQItemId },C_Cost_Project_Codes = new Models.C_Cost_Project_Codes { Id = ProjectCodeId } });
                    }

                    var ResualtBOQRegisteration = await _RegisterationService.GetBOQRegisteration(ProjectId);
                    if (ResualtBOQRegisteration.Any())
                    {
                        _RegisterationService.UpdateBOQItems(ProjectId, RegisterItem);
                    }
                    else
                    {
                        _RegisterationService.RegisterBOQItems(RegisterItem);
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
                    Frm_EditRegistertionBOQItem frm_Edit = new Frm_EditRegistertionBOQItem();
                    IProjectCodeService _IProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();
                    IRegisterationService _RegisterationService = ServiceBuilder.Build<IRegisterationService>();
                    frm_Edit.DGV_ProjectCode.DataSource = DGV_ProjectCode.DataSource;

                    var ResaultProjects = await _externalAPIs.SearchProjectsBYName(txt_Projects.Text);
                    ProjectId = Convert.ToInt32(ResaultProjects.SingleOrDefault().ContractId.ToString());
                    var ResaultBOQs = await _externalAPIs.GetBOQsAsync(ProjectId);
                    var CustomResaultBOQs = from boq in ResaultBOQs
                                            join pro in ResaultProjects on boq.ContractId equals pro.ContractId
                                            select new { ProjectName = boq.Id, ProjectId = boq.Id };

                    frm_Edit._IProjectCodeService = _IProjectCodeService;

                    frm_Edit.txt_NameProjectOld.Text = txt_Projects.Text;

                    frm_Edit.txt_IdProject.Text = ProjectId.ToString();

                    frm_Edit.txt_BOQItemOld.Text = DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqResisterBoqItemeDescription"].Value.ToString();
                    frm_Edit.txt_ProjectCodeItemOld.Text = DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqResisterProjectCodeDescription"].Value.ToString();
                    
                    frm_Edit.ShowDialog();

                    string  _ProjectCodeDesscription;
                    _ProjectCodeDesscription = frm_Edit.ProjectCodeDesscription;
                    int  _ProjectCodeId;
                    _ProjectCodeId = frm_Edit.ProjectCodeId;

                    if(!string.IsNullOrEmpty(_ProjectCodeDesscription))
                    {
                        DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqResisterProjectCodeDescription"].Value = _ProjectCodeDesscription;
                        DGV_RegistBOQItem.Rows[e.RowIndex].Cells["BoqResisterProjectCodeId"].Value = _ProjectCodeId;
                    }
                }
                catch { }
            }
        }

        private void txt_SearchByBOQItem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                var ValueSaerch = txt_SearchByBOQItem.Text;
                if (!string.IsNullOrEmpty(ValueSaerch))
                {
                    SearchDataBOQsItem(ValueSaerch, Convert.ToInt32(cm_BOQItem.SelectedValue));
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
                var ValueSaerch = txt_SearchByProjectCode.Text;
                if (!string.IsNullOrEmpty(ValueSaerch))
                {
                    SearchDataRegistraion(ProjectId, Convert.ToInt32(cm_BOQItem.SelectedValue), ValueSaerch);
                }
            }
        }
    }
}