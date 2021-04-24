using DevExpress.XtraBars.Docking2010;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.ServicesBuilders;
using System.Linq;
using System.Data;
using DevExpress.XtraTreeList.Nodes;
using PSC_Cost_Control.Services.UnifiedCodesServices;
using PSC_Cost_Control.Services.DependencyApis;
using DevExpress.XtraTreeList;
using System.Reflection;
using System.Collections.Generic;
using PSC_Cost_Control.Helper.TreeListHandler;
using PSC_Cost_Control.Models;
using DevExpress.XtraTreeList.Columns;

namespace PSC_Cost_Control.Forms.Project_Code
{
    public partial class Frm_ProjectCodeCopy : DevExpress.XtraEditors.XtraForm
    {
        ExternalAPIs _externalAPIs;
        int CountOfList = 0;
        public int ProjectTo_Id = 0;
        public Frm_ProjectCodeCopy()
        {
            InitializeComponent();
            _externalAPIs = new ExternalAPIs();
        }

        #region My Method for my From
        async void ClearAllData()
        {
            var ProjectList = await _externalAPIs.GetProjectsAsync();

            cm_ProjectTo.DataSource = ProjectList;
            cm_ProjectTo.DisplayMember = "Name";
            cm_ProjectTo.ValueMember = "ContractId";
            cm_ProjectTo.SelectedItem = -1;
            var ProjectList2 = await _externalAPIs.GetProjectsAsync();
            cm_ProjectFrom.DataSource = ProjectList2;
            cm_ProjectFrom.DisplayMember = "Name";
            cm_ProjectFrom.ValueMember = "ContractId";
            cm_ProjectFrom.SelectedItem = -1;

            
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
        void AddProjectCodeFromDB(TreeList tree_ProjectCode, IEnumerable<BL.Project_Code_by_Join> _Code_By_Joins, int? _ProjectCodeParent, TreeListNode parentNode, bool chcek, int? _ProjectCodeParentOld)
        {
            if (chcek)
            {
                CountOfList++;
                if (_ProjectCodeParent == null)
                {
                    var linqlist = _Code_By_Joins.Where(x => x.ProjectCode_Parent as int? == _ProjectCodeParent).AsEnumerable();
                    if (linqlist.Any())
                    {
                        DataTable dataRows = LINQResultToDataTable(linqlist);
                        for (int i = CountOfList - 1; i < dataRows.Rows.Count; i++)
                        {
                            int id, CategoryId, UnidiedCodeId, ProjectId;
                            string ProjectCode_Code, ProjectCode_Description, Category_Name, UnidiedCodeTitle;
                            id = Convert.ToInt32(dataRows.Rows[i]["id"].ToString());
                            ProjectCode_Code = dataRows.Rows[i]["ProjectCode_Code"].ToString();
                            ProjectCode_Description = dataRows.Rows[i]["ProjectCode_Description"].ToString();
                            UnidiedCodeTitle = dataRows.Rows[i]["UnifiedCode_Title"].ToString();
                            CategoryId = Convert.ToInt32(dataRows.Rows[i]["CategoryId"].ToString());
                            UnidiedCodeId = Convert.ToInt32(dataRows.Rows[i]["UnifiedCode_Id"].ToString());
                            ProjectId = Convert.ToInt32(dataRows.Rows[i]["ProjectId"].ToString());
                            Category_Name = dataRows.Rows[i]["Category_Name"].ToString();

                            var _Tag = new Models.C_Cost_Project_Codes
                            {
                                Id = id,
                                Code = ProjectCode_Code,
                                Category_Id = CategoryId,
                                Description = ProjectCode_Description,
                                Unified_Code_Id = UnidiedCodeId,
                                Project_Id = ProjectId,
                                Parent = null
                            };

                            TreeListNode parentNodej = tree_ProjectCode.AppendNode(
                                new object[] { id, ProjectCode_Code, ProjectCode_Description, UnidiedCodeTitle, Category_Name, null, "Edit" }
                            , null, tag: _Tag);

                            var linqlistj = _Code_By_Joins.Where(x => x.ProjectCode_Parent == id);
                            AddProjectCodeFromDB(tree_ProjectCode, _Code_By_Joins, id, parentNodej, true, id);
                        }
                    }
                    else
                    {
                        AddProjectCodeFromDB(tree_ProjectCode, _Code_By_Joins, null, null, false, 0);
                        chcek = false;
                    }
                }
                else
                {
                    var linqlist = _Code_By_Joins.Where(x => x.ProjectCode_Parent as int? == _ProjectCodeParent).AsEnumerable();
                    if (linqlist.Any())
                    {
                        DataTable dataRowsj = LINQResultToDataTable(linqlist);
                        for (int j = 0; j < dataRowsj.Rows.Count; j++)
                        {
                            int id, ProjectCode_Parent, CategoryId, UnidiedCodeId, ProjectId;
                            string ProjectCode_Code, ProjectCode_Description, Category_Name, UnidiedCodeTitle;
                            id = Convert.ToInt32(dataRowsj.Rows[j]["id"].ToString());
                            ProjectCode_Code = dataRowsj.Rows[j]["ProjectCode_Code"].ToString();
                            ProjectCode_Description = dataRowsj.Rows[j]["ProjectCode_Description"].ToString();
                            UnidiedCodeTitle = dataRowsj.Rows[j]["UnifiedCode_Title"].ToString();
                            CategoryId = Convert.ToInt32(dataRowsj.Rows[j]["CategoryId"].ToString());
                            UnidiedCodeId = Convert.ToInt32(dataRowsj.Rows[j]["UnifiedCode_Id"].ToString());
                            ProjectId = Convert.ToInt32(dataRowsj.Rows[j]["ProjectId"].ToString());
                            Category_Name = dataRowsj.Rows[j]["Category_Name"].ToString();
                            ProjectCode_Parent = Convert.ToInt32(dataRowsj.Rows[j]["ProjectCode_Parent"].ToString());

                            var _Tagj = new Models.C_Cost_Project_Codes
                            {
                                Id = id,
                                Code = ProjectCode_Code,
                                Category_Id = CategoryId,
                                Description = ProjectCode_Description,
                                Unified_Code_Id = UnidiedCodeId,
                                Project_Id = ProjectId,
                                Parent = ProjectCode_Parent
                            };

                            TreeListNode parentNodej = tree_ProjectCode.AppendNode(
                                new object[] { id, ProjectCode_Code, ProjectCode_Description, UnidiedCodeTitle, Category_Name, ProjectCode_Parent, "Edit" }
                            , parentNode, tag: _Tagj);
                            AddProjectCodeFromDB(tree_ProjectCode, _Code_By_Joins, id, parentNodej, true, ProjectCode_Parent);
                        }
                    }
                    else
                    {
                        IEnumerable<BL.Project_Code_by_Join> _Code_By_Joins1 = _Code_By_Joins.Where(x => x.Id != _ProjectCodeParentOld);
                        AddProjectCodeFromDB(tree_ProjectCode,_Code_By_Joins1, null, null, true, 0);
                    }
                }
            }

        }

        async Task<TreeList> GetProjectCode(int projectId)
        {
            TreeList tree_ProjectCode = new TreeList();
            CreateColumns(tree_ProjectCode);
            IProjectCodeCategoryService _categoryService = ServiceBuilder.Build<IProjectCodeCategoryService>();
            IUnifiedCodeService _unifiedCodeService = ServiceBuilder.Build<IUnifiedCodeService>();
            IProjectCodeService _ProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();
            var ResualtCategory = await _categoryService.GetCategories();
            var ResualtProjectCode = await _ProjectCodeService.GetProjectCodes(projectId);
            var ResualtProject = await _externalAPIs.GetProjectsAsync();
            var ResualtUnifiedCode = await _unifiedCodeService.GetUnifiedCodes();
            var linqlisti = from p in ResualtProjectCode
                            join c in ResualtCategory on p.Category_Id equals c.Id
                            join Pro in ResualtProject on p.Project_Id equals Pro.ContractId
                            join u in ResualtUnifiedCode on p.Unified_Code_Id equals u.Id
                            select new BL.Project_Code_by_Join
                            {
                                Id = p.Id,
                                ProjectCode_Code = p.Code,
                                ProjectCode_Description = p.Description,
                                UnifiedCode_Title = u.Title,
                                Category_Name = c.Name,
                                ProjectName = Pro.Name,
                                ProjectCode_Parent = p.Parent,
                                CategoryId = c.Id,
                                ProjectId = Pro.ContractId,
                                UnifiedCode_Id = p.Unified_Code_Id,
                            };

            if (linqlisti.Any())
            {
                tree_ProjectCode.ClearNodes();
                tree_ProjectCode.Tag = null;
                tree_ProjectCode.DataSource = null;
                AddProjectCodeFromDB(tree_ProjectCode, linqlisti, null, null, true, 0);
                CountOfList = 0;
            }
            else
            {
                tree_ProjectCode.ClearNodes();
                tree_ProjectCode.Tag = null;
                tree_ProjectCode.DataSource = null;
                CountOfList = 0;
            }
            return tree_ProjectCode;
        }


        bool ValidationData()
        {
            bool Resualt = false;
            if (Convert.ToInt32(cm_ProjectTo.SelectedValue)> 0)
            {
                Resualt = true;
            }
            else
            {
                
                MessageBox.Show("Plase choose Project To  .");
                return false;
            }
            if (Convert.ToInt32(cm_ProjectFrom.SelectedValue) > 0)
            {
                Resualt = true;
            }
            else
            {

                MessageBox.Show("Plase choose Project From .");
                return false;
            }
            return Resualt;
        }
        #endregion My Method for my Form

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            if (btn.Caption == "Clone")
            {
                //Add Cateogry
                SaveProectCode(Convert.ToInt32(cm_ProjectFrom.SelectedValue), Convert.ToInt32(cm_ProjectTo.SelectedValue));
                //Clear all Data 
                ClearAllData();
            }
        }

        private void CreateColumns(TreeList tl)
        {
            // Create three columns.
            tl.BeginUpdate();
            TreeListColumn col1 = tl.Columns.Add();
            col1.Caption = "Id";
            col1.Name = "Id";
            col1.VisibleIndex = 0;
            col1.Visible = false;
            TreeListColumn col2 = tl.Columns.Add();
            col2.Caption = "Project Code";
            col2.Name = "ProjectCode_Code";
            col2.VisibleIndex = 1;
            col2.Visible = true;
            TreeListColumn col3 = tl.Columns.Add();
            col3.Caption = "Project Code Description";
            col3.Name = "ProjectCode_Description";
            col3.VisibleIndex = 2;
            col3.Visible = true;
            TreeListColumn col4 = tl.Columns.Add();
            col4.Caption = "Project Code Title";
            col4.Name = "ProjectCode_Title";
            col4.VisibleIndex = 3;
            col4.Visible = true;
            TreeListColumn col5 = tl.Columns.Add();
            col5.Caption = "Category Name";
            col5.Name = "Category_Name";
            col5.VisibleIndex = 4;
            col5.Visible = true;
            TreeListColumn col7 = tl.Columns.Add();
            col7.Caption = "Project Code Parent";
            col7.Name = "ProjectCode_Parent";
            col7.VisibleIndex = 5;
            col7.Visible = false;
            
            tl.EndUpdate();
        }
        async void SaveProectCode(int projectIdOld, int projectIdNew)
        {
            if (ValidationData())
            {
                IProjectCodeService _ProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();

                var ResualtProjectCode = await _ProjectCodeService.GetProjectCodes(projectIdNew);
                var TreeResualt = await GetProjectCode(projectIdOld);
                var Resault = TreeListHandler.ToSequentialList<C_Cost_Project_Codes>(TreeResualt).ToList();
                if (ResualtProjectCode.Any())
                {
                    await _ProjectCodeService.Update(projectIdNew, Resault);
                }
                else
                {
                    await _ProjectCodeService.NewCodesForProject(projectIdNew, Resault);
                }
                MessageBox.Show("The data has been saved successfully. ");
            }
        }

        private void Frm_Categories_ProjectCode_Load(object sender, EventArgs e)
        {

            ClearAllData();
        }

        private async void cm_ProjectFrom_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cm_ProjectFrom.SelectedValue) > 0)
                {
                    IProjectCodeService _ProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();
                    var Resualt = await _ProjectCodeService.GetProjectCodes(Convert.ToInt32(cm_ProjectFrom.SelectedValue));
                    if (!Resualt.Any())
                    {
                        MessageBox.Show("Plase choose Project Not Epmty Project Code  .");
                        cm_ProjectFrom.SelectedIndex = -1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Plase choose Project Not Epmty Project Code  .");
                cm_ProjectFrom.SelectedIndex = -1;
            }
        }

        private async void cm_ProjectTo_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cm_ProjectTo.SelectedValue) > 0)
                {
                    IProjectCodeService _ProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();
                    var Resualt = await _ProjectCodeService.GetProjectCodes(Convert.ToInt32(cm_ProjectTo.SelectedValue));
                   if (Resualt.Any())
                    {
                        MessageBox.Show("Plase choose Project Epmty Project Code  .");
                        cm_ProjectTo.SelectedIndex = -1;
                    }
                    else
                    {
                        ProjectTo_Id = Convert.ToInt32(cm_ProjectTo.SelectedValue);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Plase choose Project Epmty Project Code  .");
                cm_ProjectTo.SelectedIndex = -1;
            }
        }
    }
}