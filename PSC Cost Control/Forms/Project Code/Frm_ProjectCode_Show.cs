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
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Helper;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils.DragDrop;
using System.Collections;
using PSC_Cost_Control.Helper.TreeListHandler;
using PSC_Cost_Control.Services.DependencyApis;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.ServicesBuilders;
using System.Reflection;
using PSC_Cost_Control.Services.UnifiedCodesServices;

namespace PSC_Cost_Control.Forms.Project_Code
{
    public partial class Frm_ProjectCode_Show : DevExpress.XtraEditors.XtraForm
    {
        public ExternalAPIs _externalAPIs;

        readonly Static st = new Static();
        public Frm_ProjectCode_Show()
        {
            InitializeComponent();
            _externalAPIs = new ExternalAPIs();

        }
        
        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            if (btn.Caption == "New Project Code")
            {
                //Clear all Data from Project Code Combobox Categore and text Description
                ClearAllDataProjectCode();
            }
            else if (btn.Caption == "New Project")
            {
                //Clear all Data from Project Code Combobox Categore and text Description and Project
                ClearAllDataProject();
            }
            else if (btn.Caption == "Add Root")
            {
                //Check if Project is Null
                if (validationProjects())
                {

                    //Check if Category and description is Null
                    if (validationProjectCode())
                    {
                        //Add Root Project Code To Treelist
                        AddRootProjectCode(cm_Categories.Text, txt_Description.Text, cm_UnifiedCode.Text
                            , Convert.ToInt32(cm_Categories.SelectedValue), Convert.ToInt32(cm_UnifiedCode.SelectedValue),
                            Convert.ToInt32(cm_Project.SelectedValue));

                        //Clear Combobox Categore and text Description
                         ClearAllDataProjectCode();
                    }
                }
            }
            else if (btn.Caption == "Add Child")
            {
                //Check if Project is Null
                if (validationProjects())
                {

                    //Check if Category and description is Null
                    if (validationProjectCode())
                    {
                        //Add Child Project Code To Treelist
                        AddChildProjectCode(cm_Categories.Text, txt_Description.Text, cm_UnifiedCode.Text
                            , Convert.ToInt32(cm_Categories.SelectedValue), Convert.ToInt32(cm_UnifiedCode.SelectedValue),
                            Convert.ToInt32(cm_Project.SelectedValue));

                        //Clear Combobox Categore and text Description
                        ClearAllDataProjectCode();
                    }
                }
            }
            else if (btn.Caption == "Delete")
            {
                //Check if Project is Null
                if (validationProjects())
                {
                    //Delete Project Code To Treelist
                    DeleteProjectCode();

                    //Clear Combobox Categore and text Description
                    ClearAllDataProjectCode();
                }
            }
            else if(btn.Caption == "Save Project")
            {
                //Check if Project is Null
                if (validationProjects())
                {
                    //Add Project Code To Treelist
                    if (tree_ProjectCode.AllNodesCount > 0)
                    {
                        SaveProectCode(Convert.ToInt32(cm_Project.SelectedValue));
                    }
                    else
                    {
                        MessageBox.Show("There's no data on the Project Code table. ");
                    }
                    //Clear Combobox Categore and text Description
                    ClearAllDataProject();
                }
                
            }else if(btn.Caption == "copy from another Project")
            {
                Frm_ProjectCodeCopy frm = new Frm_ProjectCodeCopy();
                frm.ShowDialog();
                var ProjectToId = frm.ProjectTo_Id;
                ClearAllDataProject();

                GetProjectCode(ProjectToId);
            }

        }

        private void Frm_ProjectCode_Show_Load(object sender, EventArgs e)
        {
            ClearAllDataProject();
            CreateColumns(tree_ProjectCode);



            DragDropManager.Default.DragOver += OnDragOver;
            DragDropManager.Default.DragDrop += OnDragDrop;

            tree_ProjectCode.ExpandAll();
        }


        #region Method for Create TreeList


        private void OnDragDrop(object sender, DragDropEventArgs e)
        {
            if (object.ReferenceEquals(e.Source, e.Target))
                return;
            e.Handled = true;
            if (e.Action == DragDropActions.None || e.InsertType == InsertType.None)
                return;
            if (e.Target == tree_ProjectCode)
                OnTreeListDrop(e);

            Cursor.Current = Cursors.Default;
        }

        void OnDragOver(object sender, DragOverEventArgs e)
        {
            if (object.ReferenceEquals(e.Source, e.Target))
                return;
            e.Default();
            if (e.InsertType == InsertType.None)
                return;
            e.Action = IsCopy(e.KeyState) ? DragDropActions.Copy : DragDropActions.Move;
            Cursor current = Cursors.No;
            if (e.Action != DragDropActions.None)
                current = Cursors.Default;
            e.Cursor = current;
        }

        bool IsCopy(DragDropKeyState key)
        {
            return (key & DragDropKeyState.Control) != 0;
        }

        void OnTreeListDrop(DragDropEventArgs e)
        {

            var items = e.GetData<IEnumerable<object>>();
            if (items == null)
                return;
            var destNode = GetDestNode(e.Location);
            int index = CalcDestNodeIndex(e, destNode);
            tree_ProjectCode.BeginUpdate();
            tree_ProjectCode.Selection.UnselectAll();
            List<object> _items = new List<object>(items);
            foreach (object _item in _items)
            {
                DataRowView rowView = _item as DataRowView;
                TreeListNode node = tree_ProjectCode.AppendNode(rowView.Row.ItemArray, index == -1000 ? destNode : null);
                if (index > -1)
                {

                    tree_ProjectCode.MoveNode(node, destNode.ParentNode, true, index);
                    index++;
                }
                if (e.Action != DragDropActions.Copy)

                    tree_ProjectCode.SelectNode(node);
                if (node.ParentNode != null)
                    node.ParentNode.Expand();
            }

            tree_ProjectCode.EndUpdate();
        }

        int CalcDestNodeIndex(DragDropEventArgs e, TreeListNode destNode)
        {
            if (destNode == null)
                return -1;
            if (e.InsertType == InsertType.AsChild)
                return -1000;
            var nodes = destNode.ParentNode == null ? tree_ProjectCode.Nodes : destNode.ParentNode.Nodes;
            int index = nodes.IndexOf(destNode);
            if (e.InsertType == InsertType.After)
                return ++index;
            return index;
        }

        TreeListNode GetDestNode(Point hitPoint)
        {
            Point pt = tree_ProjectCode.PointToClient(hitPoint);
            DevExpress.XtraTreeList.TreeListHitInfo ht = tree_ProjectCode.CalcHitInfo(pt);
            TreeListNode destNode = ht.Node;
            if (destNode is TreeListAutoFilterNode)
                return null;
            return destNode;
        }
        #endregion Method for Create TreeList

        #region Methods For my Form
        async void ClearAllDataProject()
        {
            IProjectCodeCategoryService _categoryService = ServiceBuilder.Build<IProjectCodeCategoryService>();
            IUnifiedCodeService _unifiedCodeService = ServiceBuilder.Build<IUnifiedCodeService>();

            var ResualtCategories = await _categoryService.GetCategories();
            var CustomCategories = from cat in ResualtCategories
                                   select new
                                   {
                                       Id = cat.Id,
                                       Name = cat.Name
                                   };
            cm_Categories.DataSource = CustomCategories.ToList();
            cm_Categories.DisplayMember = "Name";
            cm_Categories.ValueMember = "Id";
            cm_Categories.SelectedItem = -1;

            txt_Description.Text = "";

            var ProjectList = await _externalAPIs.GetProjectsAsync();

            cm_Project.DataSource = ProjectList;
            cm_Project.DisplayMember = "Name";
            cm_Project.ValueMember = "ContractId";
            cm_Project.SelectedItem = -1;

            var UnifiedCodeList = await _unifiedCodeService.GetUnifiedCodes();

            cm_UnifiedCode.DataSource = UnifiedCodeList;
            cm_UnifiedCode.DisplayMember = "Title";
            cm_UnifiedCode.ValueMember = "Id";
            cm_UnifiedCode.SelectedItem = -1;

            tree_ProjectCode.DataSource = null;
            txt_Description.Enabled = false;
            cm_Categories.Enabled = false;
        }

        void ClearAllDataProjectCode()
        {
            cm_Categories.SelectedItem = -1;
            txt_Description.Text = "";
            
        }

        bool validationProjects()
        {
            bool result;
            if (cm_Project.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose the Project first.");
                return false;
            }
            else
            {
                result = true;
            }
            
           
            return result;
        }

        bool validationProjectCode()
        {
            bool result;
            if (Convert.ToInt32(cm_Categories.SelectedValue) > 0)
            {
                result = true;
                
            }
            else
            {
                MessageBox.Show("Please choose the category to add the Project Code.");
                return false;
            }
            if (Convert.ToInt32(cm_UnifiedCode.SelectedValue) > 0)
            {
                result = true;

            }
            else
            {
                MessageBox.Show("Please choose the Unified Code to add the Project Code.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Description.Text))
            {
                MessageBox.Show("Please add the description of the Project Code to add the Project Code.");
                return false;
            } 
            else
            {
                result = true;
            }
            return result;
        }

        void AddRootProjectCode(string Category, string ProjectCode_Description, string UnidiedCodeTitle, int CategoryId, int UnidiedCodeId, int ProjectId)
        {
            var _Tag = new Models.C_Cost_Project_Codes { Category_Id = CategoryId, Description = ProjectCode_Description, Unified_Code_Id = UnidiedCodeId, Project_Id = ProjectId };

             tree_ProjectCode.FocusedNode = tree_ProjectCode.AppendNode(
                nodeData: new object[] {0, "/" + (tree_ProjectCode.Nodes.Count +1)
                , ProjectCode_Description, UnidiedCodeTitle, Category, 0 }, parentNode: null, tag: _Tag);

        }

        void AddChildProjectCode(string Category,string ProjectCode_Description, string UnidiedCodeTitle, int CategoryId, int UnidiedCodeId, int ProjectId)
        {
            if (tree_ProjectCode.FocusedNode != null)
            {
                if (tree_ProjectCode.FocusedNode.Level > 2)
                {
                    MessageBox.Show("This Node Level Maxminim 4");
                }
                else
                {
                    string IdNode = " ";
                    if (tree_ProjectCode.FocusedNode.Level+1 > 0)
                    {
                        var _Tag = new Models.C_Cost_Project_Codes { Category_Id = CategoryId, Description = ProjectCode_Description,Unified_Code_Id = UnidiedCodeId,Project_Id = ProjectId };
                        //var vs = tree_ProjectCode.GetDataRecordByNode(tree_ProjectCode.FocusedNode);
                        //IList objectList = vs as IList;
                        //string NodeCode = objectList[0].ToString();
                        IdNode = (tree_ProjectCode.FocusedNode.Level.ToString()
                            + "/"
                            + (tree_ProjectCode.FocusedNode.Nodes.Count + 1).ToString());

                        tree_ProjectCode.FocusedNode =  tree_ProjectCode.AppendNode(
                                nodeData: new object[] { 0, IdNode, ProjectCode_Description, UnidiedCodeTitle, Category, 0 }
                                , parentNode: tree_ProjectCode.FocusedNode, tag: _Tag);
                    }             
                }
            }
        }

        void DeleteProjectCode()
        {
            string msg = string.Format("The node {0} is about to be deleted. Do you want to proceed?", tree_ProjectCode.FocusedNode);
            if (XtraMessageBox.Show(msg, "Deleting node", MessageBoxButtons.YesNo) == DialogResult.Yes)
                if (tree_ProjectCode.FocusedNode != null)
                    tree_ProjectCode.DeleteNode(tree_ProjectCode.FocusedNode);
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
            //TreeListColumn col8 = tl.Columns.Add();
            //col8.Caption = "Edit";
            //col8.Name = "Edit";
            //col8.VisibleIndex = 6;
            //col8.Visible = false;
            //col8.ColumnType.;
            tl.EndUpdate();
        }

        async void GetProjectCode(int projectId)
        {
            IProjectCodeCategoryService _categoryService = ServiceBuilder.Build<IProjectCodeCategoryService>();
            IUnifiedCodeService _unifiedCodeService = ServiceBuilder.Build<IUnifiedCodeService>();
            IProjectCodeService _ProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();
            var ResualtCategory = await _categoryService.GetCategories();
            var ResualtProjectCode = await _ProjectCodeService.GetProjectCodes(projectId);
            var ResualtProject = await _externalAPIs.GetProjectsAsync();
            var ResualtUnifiedCode = await _unifiedCodeService.GetUnifiedCodes();
            var innerJoin = from p in ResualtProjectCode
                            join c in ResualtCategory on p.Category_Id equals c.Id
                            join Pro in ResualtProject on p.Project_Id equals Pro.ContractId
                            join u in ResualtUnifiedCode on p.Unified_Code_Id equals u.Id
                            select new
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
            //var ProjectList = innerJoin.ToList();
            var linqlisti = innerJoin.ToList().AsEnumerable();
            DataTable table = LINQResultToDataTable(linqlisti);
            //tree_ProjectCode.OptionsBehavior.PopulateServiceColumns = true;
            if (table.Rows.Count > 0)
            {
                tree_ProjectCode.KeyFieldName = "Id";
                tree_ProjectCode.ParentFieldName = "ProjectCode_Parent";
                //tree_ProjectCode.DataSource = table;
                tree_ProjectCode.ClearNodes();
                var linqlist = linqlisti.Where(x => x.ProjectCode_Parent as int? == null).AsEnumerable();
                DataTable dataRows = LINQResultToDataTable(linqlist);
                for (int i = 0; i < dataRows.Rows.Count; i++)
                {
                    int id, ProjectCode_Parent, CategoryId, UnidiedCodeId, ProjectId;
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
                        new object[] { id, ProjectCode_Code, ProjectCode_Description, UnidiedCodeTitle, Category_Name, null }
                    , null, tag: _Tag);

                    
                    var linqlistj = linqlisti.Where(x => x.ProjectCode_Parent == id).AsEnumerable();
                    DataTable dataRowsj = LINQResultToDataTable(linqlistj);
                    for (int j = 0; j < dataRowsj.Rows.Count; j++)
                    {
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

                        TreeListNode parentNodex = tree_ProjectCode.AppendNode(
                            new object[] { id, ProjectCode_Code, ProjectCode_Description, UnidiedCodeTitle, Category_Name, ProjectCode_Parent }
                        , parentNodej, tag: _Tagj);

                        var linqlistx = innerJoin.Where(x => x.ProjectCode_Parent == id).AsEnumerable();
                        DataTable dataRowsx = LINQResultToDataTable(linqlistx);
                        for (int x = 0; x < dataRowsx.Rows.Count; x++)
                        {
                            id = Convert.ToInt32(dataRowsx.Rows[x]["id"].ToString());
                            ProjectCode_Code = dataRowsx.Rows[x]["ProjectCode_Code"].ToString();
                            ProjectCode_Description = dataRowsx.Rows[x]["ProjectCode_Description"].ToString();
                            UnidiedCodeTitle = dataRowsx.Rows[x]["UnifiedCode_Title"].ToString();
                            CategoryId = Convert.ToInt32(dataRowsx.Rows[x]["CategoryId"].ToString());
                            UnidiedCodeId = Convert.ToInt32(dataRowsx.Rows[x]["UnifiedCode_Id"].ToString());
                            ProjectId = Convert.ToInt32(dataRowsx.Rows[x]["ProjectId"].ToString());
                            Category_Name = dataRowsx.Rows[x]["Category_Name"].ToString();
                            ProjectCode_Parent = Convert.ToInt32(dataRowsx.Rows[x]["ProjectCode_Parent"].ToString());

                            var _Tagq = new Models.C_Cost_Project_Codes
                            {
                                Id = id,
                                Code = ProjectCode_Code,
                                Category_Id = CategoryId,
                                Description = ProjectCode_Description,
                                Unified_Code_Id = UnidiedCodeId,
                                Project_Id = ProjectId,
                                Parent = ProjectCode_Parent
                            };

                            TreeListNode parentNodeq = tree_ProjectCode.AppendNode(
                                new object[] { id, ProjectCode_Code, ProjectCode_Description, UnidiedCodeTitle, Category_Name, ProjectCode_Parent }
                            , parentNodex, tag: _Tagq);

                            var linqlistq = innerJoin.Where(m => m.ProjectCode_Parent == id).AsEnumerable();
                            DataTable dataRowsq = LINQResultToDataTable(linqlistq);
                            for (int q = 0; q < dataRowsq.Rows.Count; q++)
                            {
                                id = Convert.ToInt32(dataRowsq.Rows[q]["id"].ToString());
                                ProjectCode_Code = dataRowsq.Rows[q]["ProjectCode_Code"].ToString();
                                ProjectCode_Description = dataRowsq.Rows[q]["ProjectCode_Description"].ToString();
                                UnidiedCodeTitle = dataRowsq.Rows[q]["UnifiedCode_Title"].ToString();
                                CategoryId = Convert.ToInt32(dataRowsq.Rows[q]["CategoryId"].ToString());
                                UnidiedCodeId = Convert.ToInt32(dataRowsq.Rows[q]["UnifiedCode_Id"].ToString());
                                ProjectId = Convert.ToInt32(dataRowsq.Rows[q]["ProjectId"].ToString());
                                Category_Name = dataRowsq.Rows[q]["Category_Name"].ToString();
                                ProjectCode_Parent = Convert.ToInt32(dataRowsq.Rows[q]["ProjectCode_Parent"].ToString());

                                var _Tagz = new Models.C_Cost_Project_Codes
                                {
                                    Id = id,
                                    Code = ProjectCode_Code,
                                    Category_Id = CategoryId,
                                    Description = ProjectCode_Description,
                                    Unified_Code_Id = UnidiedCodeId,
                                    Project_Id = ProjectId,
                                    Parent = ProjectCode_Parent
                                };

                                TreeListNode parentNodez = tree_ProjectCode.AppendNode(
                                    new object[] { id, ProjectCode_Code, ProjectCode_Description, UnidiedCodeTitle, Category_Name, ProjectCode_Parent }
                                , parentNodeq, tag: _Tagz);

                            }
                        }
                    }
                }
                //  TreeList.AppendNode adds a new TreeListNode containing the specified values to the XtraTreeList.
                tree_ProjectCode.ExpandAll();
            }
            else
            {
                tree_ProjectCode.ClearNodes();
            }
            




            txt_Description.Enabled = true;
            cm_Categories.Enabled = true;
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

        async void SaveProectCode(int projectId)
        {

            IProjectCodeService _ProjectCodeService = ServiceBuilder.Build<IProjectCodeService>();

            var ResualtProjectCode = await _ProjectCodeService.GetProjectCodes(projectId);

            var Resault = TreeListHandler.ToSequentialList<C_Cost_Project_Codes>(tree_ProjectCode).ToList();
            if (ResualtProjectCode.Any())
            {
                await _ProjectCodeService.Update(projectId, Resault);
            }
            else
            {
                await _ProjectCodeService.NewCodesForProject(projectId, Resault);
            }
            tree_ProjectCode.Nodes.Clear();
            MessageBox.Show("The data has been saved successfully. ");
        }


        #endregion Methods For my Form

        private void cm_Project_DropDownClosed(object sender, EventArgs e)
        {

            if (Convert.ToInt32(cm_Project.SelectedValue) > 0)
            {
                GetProjectCode(Convert.ToInt32(cm_Project.SelectedValue));
            }
        }
        

    }
}