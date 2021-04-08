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
using System.Data.Entity;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils.DragDrop;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Serializing;
using PSC_Cost_Control.Models.UDFs;
using System.Collections;
using PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories;
using PSC_Cost_Control.Helper.TreeListHandler;
using PSC_Cost_Control.Services.DependencyApis;
using PSC_Cost_Control.Services.UnifiedCodesServices;

namespace PSC_Cost_Control.Forms.Unified_Code
{
    public partial class Frm_UnifiedCode_Show : DevExpress.XtraEditors.XtraForm
    {
        public ExternalAPIs _externalAPIs;
        public UnifiedCodeCategoryService _categoryService;
        public UnifiedCodeService _UnifiedCode;
        readonly Static st = new Static();
        public Frm_UnifiedCode_Show()
        {
            InitializeComponent();
            _externalAPIs = new ExternalAPIs(new Models.ApplicationContext());
            _categoryService = new UnifiedCodeCategoryService(new UnifiedCodeCategoriesRepo(new Models.ApplicationContext()));
            _UnifiedCode = new UnifiedCodeService(new UnifedCodeRepo(new Models.ApplicationContext()));
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            if (btn.Caption == "New Unified Code")
            {
                //Clear all Data from Unified Code Combobox Categore and text Description
                ClearAllDataUnifiedCode();
            }
            else if (btn.Caption == "New Project")
            {
                //Clear all Data from Unified Code Combobox Categore and text Description and Project
                ClearAllDataProject();
            }
            else if (btn.Caption == "Add Root")
            {


                //Check if Category and description is Null
                if (validationUnifiedCode())
                {
                    //Add Root Unified Code To Treelist
                    AddRootUnifiedCode(cm_Categories.SelectedText, txt_Description.Text);

                    //Clear Combobox Categore and text Description
                    ClearAllDataUnifiedCode();
                }

            }
            else if (btn.Caption == "Add Child")
            {
                //Check if Category and description is Null
                if (validationUnifiedCode())
                {
                    //Add Child Unified Code To Treelist
                    AddChildUnifiedCode(cm_Categories.SelectedText, txt_Description.Text);

                    //Clear Combobox Categore and text Description
                    ClearAllDataUnifiedCode();
                }


            }
            else if (btn.Caption == "Delete")
            {
                //Check if Project is Null
                if (tree_UnifiedCode.AllNodesCount > 0)
                {
                    //Delete Unified Code To Treelist
                    DeleteUnifiedCode();

                    //Clear Combobox Categore and text Description
                    ClearAllDataUnifiedCode();
                }
            }
            else if (btn.Caption == "Save Project")
            {

                //Add Unified Code To Treelist
                if (tree_UnifiedCode.AllNodesCount > 0)
                {
                    AddProectCode();
                }
                else
                {
                    MessageBox.Show("There's no data on the Unified Code table. ");
                }
                //Clear Combobox Categore and text Description
                ClearAllDataUnifiedCode();


            }
            else if(btn.Caption == "All Unified Code")
            {
                try
                {
                    GetUnifiedCode();

                }
                catch { }
            }

        }

        private void Frm_UnifiedCode_Show_Load(object sender, EventArgs e)
        {
            CreateColumns(tree_UnifiedCode);
            tree_UnifiedCode.ExpandAll();
            DragDropManager.Default.DragOver += OnDragOver;
            DragDropManager.Default.DragDrop += OnDragDrop;
            
        }

        private void cm_Projects_DropDownClosed(object sender, EventArgs e)
        {
           
        }

        private void tree_UnifiedCode_NodeChanged(object sender, NodeChangedEventArgs e)
        {

        }

        #region Method for Create TreeList
        private void CreateColumns(TreeList tl)
        {
            // Create three columns.
            tl.BeginUpdate();
            TreeListColumn col1 = tl.Columns.Add();
            col1.Caption = "UnifiedCode_Code";
            col1.VisibleIndex = 0;
            TreeListColumn col2 = tl.Columns.Add();
            col2.Caption = "UnifiedCode_Description";
            col2.VisibleIndex = 1;
            TreeListColumn col3 = tl.Columns.Add();
            col3.Caption = "Category_Name";
            col3.VisibleIndex = 2;
            TreeListColumn col4 = tl.Columns.Add();
            col4.Caption = "UnifiedCode_Parent";
            col4.VisibleIndex = 0;
            tl.EndUpdate();
        }

        private void OnDragDrop(object sender, DragDropEventArgs e)
        {
            if (object.ReferenceEquals(e.Source, e.Target))
                return;
            e.Handled = true;
            if (e.Action == DragDropActions.None || e.InsertType == InsertType.None)
                return;
            if (e.Target == tree_UnifiedCode)
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
            tree_UnifiedCode.BeginUpdate();
            tree_UnifiedCode.Selection.UnselectAll();
            List<object> _items = new List<object>(items);
            foreach (object _item in _items)
            {
                DataRowView rowView = _item as DataRowView;
                TreeListNode node = tree_UnifiedCode.AppendNode(rowView.Row.ItemArray, index == -1000 ? destNode : null);
                if (index > -1)
                {

                    tree_UnifiedCode.MoveNode(node, destNode.ParentNode, true, index);
                    index++;
                }
                if (e.Action != DragDropActions.Copy)

                    tree_UnifiedCode.SelectNode(node);
                if (node.ParentNode != null)
                    node.ParentNode.Expand();
            }

            tree_UnifiedCode.EndUpdate();
        }

        int CalcDestNodeIndex(DragDropEventArgs e, TreeListNode destNode)
        {
            if (destNode == null)
                return -1;
            if (e.InsertType == InsertType.AsChild)
                return -1000;
            var nodes = destNode.ParentNode == null ? tree_UnifiedCode.Nodes : destNode.ParentNode.Nodes;
            int index = nodes.IndexOf(destNode);
            if (e.InsertType == InsertType.After)
                return ++index;
            return index;
        }

        TreeListNode GetDestNode(Point hitPoint)
        {
            Point pt = tree_UnifiedCode.PointToClient(hitPoint);
            DevExpress.XtraTreeList.TreeListHitInfo ht = tree_UnifiedCode.CalcHitInfo(pt);
            TreeListNode destNode = ht.Node;
            if (destNode is TreeListAutoFilterNode)
                return null;
            return destNode;
        }
        #endregion Method for Create TreeList

        #region Methods For my Form
        void ClearAllDataProject()
        {
            cm_Categories.DataSource = null;
            cm_Categories.SelectedItem = -1;
            cm_Categories.Enabled = false;


            txt_Description.Text = "";
            txt_Description.Enabled = false;

            tree_UnifiedCode.DataSource = null;
        }

        void ClearAllDataUnifiedCode()
        {
            cm_Categories.SelectedItem = -1;

            txt_Description.Text = "";

        }

        bool validationUnifiedCode()
        {
            bool result;
            if (string.IsNullOrWhiteSpace(cm_Categories.SelectedText))
            {
                MessageBox.Show("Please choose the category to add the Unified Code.");
                return false;
            }
            else
            {
                result =  true;
            }
            if (string.IsNullOrWhiteSpace(txt_Description.Text))
            {
                MessageBox.Show("Please add the description of the Unified Code to add the Unified Code.");
                return false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        void AddRootUnifiedCode(string Category, string Description)
        {

            tree_UnifiedCode.FocusedNode = tree_UnifiedCode.AppendNode(new object[] { "/" + (tree_UnifiedCode.Nodes.Count +1), Category, Description }, parentNode: null);
        }

        void AddChildUnifiedCode(string Category, string Description)
        {
            if (tree_UnifiedCode.FocusedNode != null)
            {
                if (tree_UnifiedCode.FocusedNode.Level > 2)
                {
                    MessageBox.Show("This Node Level Maxminim 4");
                }
                else
                {
                    string IdNode = " ";
                    if (tree_UnifiedCode.FocusedNode.Level+1 > 0)
                    {
                        var vs = tree_UnifiedCode.GetDataRecordByNode(tree_UnifiedCode.FocusedNode);
                        IList objectList = vs as IList;
                        string NodeCode = objectList[0].ToString();
                        IdNode = (NodeCode
                            + "/"
                            + (tree_UnifiedCode.FocusedNode.Nodes.Count +1).ToString());
                        tree_UnifiedCode.FocusedNode =
                            tree_UnifiedCode.AppendNode(
                                new object[] { IdNode, Category, Description }, tree_UnifiedCode.FocusedNode);
                    }             
                }
            }
        }

        void DeleteUnifiedCode()
        {
            string msg = string.Format("The node {0} is about to be deleted. Do you want to proceed?", tree_UnifiedCode.FocusedNode);
            if (XtraMessageBox.Show(msg, "Deleting node", MessageBoxButtons.YesNo) == DialogResult.Yes)
                if (tree_UnifiedCode.FocusedNode != null)
                    tree_UnifiedCode.DeleteNode(tree_UnifiedCode.FocusedNode);
        }

        void GetUnifiedCode()
        {
            var ResualtCategory = _categoryService.GetCategories().Result;
            var ResualtProject = _UnifiedCode.GetUnifiedCodes().Result;
            var innerJoin = from p in ResualtProject
                            join c in ResualtCategory on p.Category_Id equals c.Id
                            select new
                            {
                                UnifiedCode_Code = p.Code,
                                UnifiedCode_Description = p.Title,
                                UnifiedCode_Parent = p.Parent,
                                Category_Name = c.Name
                            };
            if (ResualtProject.Count() > 0)
            {
                tree_UnifiedCode.DataSource = innerJoin;
                tree_UnifiedCode.KeyFieldName = "UnifiedCode_Code";
                tree_UnifiedCode.ParentFieldName = "UnifiedCode_Parent";
            }
        }

        void AddProectCode()
        {
            var Resault =  TreeListHandler.ToSequentialList<C_Cost_Unified_Codes>(tree_UnifiedCode).ToList();

            _UnifiedCode.NewUnifiedCodes(Resault).ConfigureAwait(true);
        }

        #endregion Methods For my Form

        #region My Old Method
        public void Add_Oold()
        {
            for (int i = 0; i < tree_UnifiedCode.AllNodesCount; i++)
            {
                var dt = tree_UnifiedCode.GetDataRecordByNode(tree_UnifiedCode.Nodes[i]);
                //int KeyName = tree_UnifiedCode.KeyFieldName[tree_UnifiedCode.Nodes[i].ParentNode.Id];
                //int keyparent = tree_UnifiedCode.ParentFieldName[tree_UnifiedCode.Nodes[i].ParentNode.Id];
                int NodeCountx = tree_UnifiedCode.Nodes[i].Nodes.Count;
                if (NodeCountx > 0)
                {
                    if (NodeCountx == 1)
                    {
                        var dt2 = tree_UnifiedCode.GetDataRecordByNode(tree_UnifiedCode.Nodes[i]);
                        int KeyName2 = tree_UnifiedCode.ParentFieldName[tree_UnifiedCode.Nodes[i].ParentNode.Id];
                        //int keyparent2 = tree_UnifiedCode.ParentFieldName[tree_UnifiedCode.Nodes[i].Nodes[c].Id];
                        for (int x = 0; x < NodeCountx; x++)
                        {
                            dt2 = tree_UnifiedCode.GetDataRecordByNode(tree_UnifiedCode.Nodes[i].Nodes[x]);
                            KeyName2 = tree_UnifiedCode.ParentFieldName[tree_UnifiedCode.Nodes[i].Nodes[x].ParentNode.Id];
                            //int keyparent2 = tree_UnifiedCode.ParentFieldName[tree_UnifiedCode.Nodes[i].Nodes[c].Id];
                        }
                    }
                    else if (NodeCountx == 2)
                    {
                        for (int x = 0; x < NodeCountx; x++)
                        {
                            int NodeCountc = tree_UnifiedCode.Nodes[i].Nodes[NodeCountx].Nodes.Count;
                            for (int c = 0; c < NodeCountc; c++)
                            {

                            }
                        }
                    }
                    else if (NodeCountx == 3)
                    {
                        for (int x = 0; x < NodeCountx; x++)
                        {
                            int NodeCountc = tree_UnifiedCode.Nodes[i].Nodes[NodeCountx].Nodes.Count;
                            for (int c = 0; c < NodeCountc; c++)
                            {
                                int NodeCountv = tree_UnifiedCode.Nodes[i].Nodes[NodeCountx].Nodes[NodeCountc].Nodes.Count;
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