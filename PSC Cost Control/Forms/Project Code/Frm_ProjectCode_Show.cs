using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
using PSC_Cost_Control.Services.UnifiedCodesServices;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Forms.Project_Code
{
    public partial class Frm_ProjectCode_Show : DevExpress.XtraEditors.XtraForm
    {
        public ExternalAPIs _externalAPIs;
        public IProjectCodeCategoryService _categoryService;
        public IProjectCodeService _projectCode;
        public IUnifiedCodeService _unifiedCodeService;

        readonly Static st = new Static();
        public Frm_ProjectCode_Show()
        {
            InitializeComponent();
            _externalAPIs = new ExternalAPIs();
            _categoryService = ServiceBuilder.Build<IProjectCodeCategoryService>();
            _projectCode = ServiceBuilder.Build<IProjectCodeService>();
            _unifiedCodeService = ServiceBuilder.Build<IUnifiedCodeService>();

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
                ClearAllDataProject().GetAwaiter();
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
                        AddRootProjectCode(cm_Categories.Text, txt_Description.Text,cm_UnifiedCode.Text);

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
                        AddChildProjectCode(cm_Categories.Text, txt_Description.Text, cm_UnifiedCode.Text);

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
                        SaveProectCode(Convert.ToInt32(cm_Projects.SelectedValue));
                    }
                    else
                    {
                        MessageBox.Show("There's no data on the Project Code table. ");
                    }
                    //Clear Combobox Categore and text Description
                    ClearAllDataProjectCode();
                }
                
            }

        }

        private void Frm_ProjectCode_Show_Load(object sender, EventArgs e)
        {
            ClearAllDataProject().GetAwaiter();
            CreateColumns(tree_ProjectCode);
            tree_ProjectCode.ExpandAll();
            DragDropManager.Default.DragOver += OnDragOver;
            DragDropManager.Default.DragDrop += OnDragDrop;
            
        }

        private void cm_Projects_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (cm_Projects.SelectedValue != null)
                {
                    int IdProject = Convert.ToInt32(cm_Projects.SelectedValue);
                    GetProjectCode(IdProject).GetAwaiter();
                    if (IdProject > 0)
                        cm_Projects.Enabled = false;
                }
            }
            catch { }
        }

        private void tree_ProjectCode_NodeChanged(object sender, NodeChangedEventArgs e)
        {

        }

        #region Method for Create TreeList
        private void CreateColumns(TreeList tl)
        {
            // Create three columns.
            tl.BeginUpdate();
            TreeListColumn col1 = tl.Columns.Add();
            col1.Caption = "Project Code";
            col1.Name = "ProjectCode_Code";
            col1.VisibleIndex = 0;
            TreeListColumn col2 = tl.Columns.Add();
            col2.Caption = "Project Code Description";
            col2.Name = "ProjectCode_Description";
            col2.VisibleIndex = 1;
            TreeListColumn col3 = tl.Columns.Add();
            col3.Caption = "Category Name";
            col3.Name = "Category_Name";
            col3.VisibleIndex = 2;
            TreeListColumn col4 = tl.Columns.Add();
            col4.Caption = "Unified Code Name";
            col4.Name = "UnifiedCode_Name";
            col4.VisibleIndex = 3;
            TreeListColumn col5 = tl.Columns.Add();
            col5.Caption = "Project Code Parent";
            col5.Name = "ProjectCode_Parent";
            col5.VisibleIndex = 4;
            tl.EndUpdate();
        }

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
        async Task ClearAllDataProject()
        {
            cm_Categories.Enabled = false;
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
            txt_Description.Enabled = false;

            cm_Projects.Enabled = true;
            var ProjectList = await _externalAPIs.GetProjectsAsync();
            
            cm_Projects.DataSource = ProjectList;
            cm_Projects.DisplayMember = "Name";
            cm_Projects.ValueMember = "ContractId";
            cm_Projects.SelectedItem = -1;

            var UnifiedCodeList = await _unifiedCodeService.GetUnifiedCodes();

            cm_UnifiedCode.DataSource = UnifiedCodeList;
            cm_UnifiedCode.DisplayMember = "Title";
            cm_UnifiedCode.ValueMember = "Id";
            cm_UnifiedCode.SelectedItem = -1;

            tree_ProjectCode.DataSource = null;
        }

        void ClearAllDataProjectCode()
        {
            cm_Categories.SelectedItem = -1;
            cm_UnifiedCode.SelectedItem = -1;
            txt_Description.Text = "";

            cm_Projects.Enabled = false;
        }

        bool validationProjects()
        {
            bool result;
            if(cm_Projects.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose the project first.");
                return  false;
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

        void AddRootProjectCode(string Category, string Description,string UnifiedCodeTitle)
        {

            tree_ProjectCode.FocusedNode = tree_ProjectCode.AppendNode(new object[] { "/" + (tree_ProjectCode.Nodes.Count +1), Category, Description, UnifiedCodeTitle,null }, parentNode: null);
        }

        void AddChildProjectCode(string Category, string Description,string UnifiedCodeTitle)
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
                        var vs = tree_ProjectCode.GetDataRecordByNode(tree_ProjectCode.FocusedNode);
                        IList objectList = vs as IList;
                        string NodeCode = objectList[0].ToString();
                        IdNode = (NodeCode
                            + "/"
                            + (tree_ProjectCode.FocusedNode.Nodes.Count +1).ToString());
                        tree_ProjectCode.FocusedNode =
                            tree_ProjectCode.AppendNode(
                                new object[] { IdNode, Category, Description, UnifiedCodeTitle,null }, tree_ProjectCode.FocusedNode);
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

        async Task GetProjectCode(int _ProjectId)
        {
            var ResualtCategory = await _categoryService.GetCategories();
            var ResualtUnifiedCode = await _unifiedCodeService.GetUnifiedCodes();
            var ResualtProject = await _projectCode.GetProjectCodes(_ProjectId);
            var innerJoin = from p in ResualtProject
                            join c in ResualtCategory on p.Category_Id equals c.Id
                            join U in ResualtUnifiedCode on p.Unified_Code_Id equals U.Id
                            select new
                            {
                                ProjectCode_Code = p.Code,
                                ProjectCode_Description = p.Description,
                                ProjectCode_Parent = p.HParent,
                                Category_Name = c.Name,
                                UnifiedCode_Name = U.Title
                            };
            if (ResualtProject.Count() > 0)
            {
                tree_ProjectCode.DataSource = innerJoin;
                tree_ProjectCode.KeyFieldName = "ProjectCode_Code";
                tree_ProjectCode.ParentFieldName = "ProjectCode_Parent";
            }
            txt_Description.Enabled = true;
            cm_Categories.Enabled = true;
        }

        void SaveProectCode(int _ProjectId)
        {
            var Resault = TreeListHandler.ToSequentialList<C_Cost_Project_Codes>(tree_ProjectCode).ToList();
            if (_projectCode.GetProjectCodes(_ProjectId).Result.Count() > 0)
            {
                _projectCode.Update(_ProjectId, Resault);
            }
            else
            {
                _projectCode.NewCodesForProject(_ProjectId, Resault);
            }
            
        }

        #endregion Methods For my Form

        #region My Old Method
        public void Add_Oold()
        {
            for (int i = 0; i < tree_ProjectCode.AllNodesCount; i++)
            {
                var dt = tree_ProjectCode.GetDataRecordByNode(tree_ProjectCode.Nodes[i]);
                //int KeyName = tree_ProjectCode.KeyFieldName[tree_ProjectCode.Nodes[i].ParentNode.Id];
                //int keyparent = tree_ProjectCode.ParentFieldName[tree_ProjectCode.Nodes[i].ParentNode.Id];
                int NodeCountx = tree_ProjectCode.Nodes[i].Nodes.Count;
                if (NodeCountx > 0)
                {
                    if (NodeCountx == 1)
                    {
                        var dt2 = tree_ProjectCode.GetDataRecordByNode(tree_ProjectCode.Nodes[i]);
                        int KeyName2 = tree_ProjectCode.ParentFieldName[tree_ProjectCode.Nodes[i].ParentNode.Id];
                        //int keyparent2 = tree_ProjectCode.ParentFieldName[tree_ProjectCode.Nodes[i].Nodes[c].Id];
                        for (int x = 0; x < NodeCountx; x++)
                        {
                            dt2 = tree_ProjectCode.GetDataRecordByNode(tree_ProjectCode.Nodes[i].Nodes[x]);
                            KeyName2 = tree_ProjectCode.ParentFieldName[tree_ProjectCode.Nodes[i].Nodes[x].ParentNode.Id];
                            //int keyparent2 = tree_ProjectCode.ParentFieldName[tree_ProjectCode.Nodes[i].Nodes[c].Id];
                        }
                    }
                    else if (NodeCountx == 2)
                    {
                        for (int x = 0; x < NodeCountx; x++)
                        {
                            int NodeCountc = tree_ProjectCode.Nodes[i].Nodes[NodeCountx].Nodes.Count;
                            for (int c = 0; c < NodeCountc; c++)
                            {

                            }
                        }
                    }
                    else if (NodeCountx == 3)
                    {
                        for (int x = 0; x < NodeCountx; x++)
                        {
                            int NodeCountc = tree_ProjectCode.Nodes[i].Nodes[NodeCountx].Nodes.Count;
                            for (int c = 0; c < NodeCountc; c++)
                            {
                                int NodeCountv = tree_ProjectCode.Nodes[i].Nodes[NodeCountx].Nodes[NodeCountc].Nodes.Count;
                                for (int v = 0; v < NodeCountv; v++)
                                {

                                }
                            }
                        }
                    }

                }
                else
                {

                }
            }
        }

        public void AppendingNodes(TreeList treeList)
        {
            SimpleButton appendNodeButton = new SimpleButton() { Dock = DockStyle.Top, Parent = treeList.Parent, Text = "Append node" };
            // UI Binding
            appendNodeButton.Click += (sender, e) => {
                // Appending a new Node
                TreeListNode newNode = treeList.AppendNode(
                    nodeData: new object[] {
                        "/"+((treeList.FocusedNode != null) ? treeList.FocusedNode.Id : -1)+ "/"+ treeList.AllNodesCount +"/", "Suyama, Michael", "Obere Str. 55"
                    },
                    parentNode: treeList.FocusedNode
                );
                // Using the newly added node
                treeList.FocusedNode = newNode;
            };
        }

        public void RemovingSelectedNodes(TreeList treeList)
        {
            SimpleButton deleteButton = new SimpleButton() { Dock = DockStyle.Top, Parent = treeList.Parent, Text = "Delete selected nodes" };
            // Enable multi-selection
            treeList.OptionsSelection.MultiSelect = true;
            treeList.OptionsSelection.MultiSelectMode = TreeListMultiSelectMode.RowSelect;
            // UI Binding
            deleteButton.Click += (sender, e) => {
                int count = treeList.Selection.Count;
                if (count == 0)
                    return;
                string msg = string.Format("{0} nodes is about to be deleted. Do you want to proceed?", count);
                if (XtraMessageBox.Show(msg, "Deleting node", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Delete selected nodes
                    treeList.DeleteSelectedNodes();
                }
            };
        }

        public void RemovingNode(TreeList treeList)
        {
            SimpleButton deleteButton = new SimpleButton() { Dock = DockStyle.Top, Parent = treeList.Parent, Text = "Delete focused node" };
            // Delete node action with confirmation
            Action<TreeListNode> deleteNodeWithConfirmation = (node) => {
                if (node == null)
                    return;
                string msg = string.Format("The node {0} is about to be deleted. Do you want to proceed?", node["Name"]);
                if (XtraMessageBox.Show(msg, "Deleting node", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Delete Node
                    treeList.DeleteNode(node);
                    // or you can use the TreeListNode.Remove() method
                    // node.Remove();
                }
            };
            // UI Bindings
            treeList.KeyDown += (sender, e) => {
                if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
                    deleteNodeWithConfirmation(treeList.FocusedNode);
            };
            deleteButton.Click += (sender, e) => {
                deleteNodeWithConfirmation(treeList.FocusedNode);
            };
        }

        private void CreateNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();
            // Create a root node .
            TreeListNode parentForRootNodes = null;
            TreeListNode rootNode = tl.AppendNode(
                new object[] { "/1", "Alfreds Futterkiste", "Germany, Obere Str. 57" }, parentForRootNodes);
            TreeListNode rootNode2 = tl.AppendNode(
               new object[] { "/2", "Alfreds Futterkiste", "Germany, Obere Str. 57" }, parentForRootNodes);

            // Create a child of the rootNode
            tl.AppendNode(new object[] { (rootNode[0]).ToString() + "/1", "Suyama, Michael", "Obere Str. 55" }, rootNode);
            tl.AppendNode(new object[] { (rootNode[0]).ToString() + "/2", "Suyama, Michael", "Obere Str. 55" }, rootNode);

            // Create a child of the rootNode2
            tl.AppendNode(new object[] { (rootNode2[0]).ToString() + "/1", "Suyama, Michael", "Obere Str. 55" }, rootNode2);
            tl.AppendNode(new object[] { (rootNode2[0]).ToString() + "/2", "Suyama, Michael", "Obere Str. 55" }, rootNode2);
            tl.EndUnboundLoad();
        }
        #endregion My Old Method

    }
}