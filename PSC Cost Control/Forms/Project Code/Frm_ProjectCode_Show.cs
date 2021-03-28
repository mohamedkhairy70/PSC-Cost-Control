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
using PSC_Cost_Control.Model;
using PSC_Cost_Control.Helper;
using System.Data.Entity;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils.DragDrop;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Serializing;

namespace PSC_Cost_Control.Forms.Project_Code
{
    public partial class Frm_ProjectCode_Show : DevExpress.XtraEditors.XtraForm
    {
        readonly Static st = new Static();

        private readonly PSC_COST2Entities context = new PSC_COST2Entities();

        public List<C_Cost_Project_Codes> _Cost_Project_Codes = new List<C_Cost_Project_Codes>();
        public List<C_Cost_Project_Code_Categories> _Categories = new List<C_Cost_Project_Code_Categories>();
        public List<Project> _Projects = new List<Project>();
        public List<View_Cost_Project_Codes> _View_Cost_Project_Codes = new List<View_Cost_Project_Codes>();

        public List<BOQ_Items> _Boq_Items = new List<BOQ_Items>();
        public List<IndirectCostItem> _IndirectCostItems = new List<IndirectCostItem>();



        public Frm_ProjectCode_Show()
        {
            InitializeComponent();
            
        }
       


        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            if (btn.Caption == "جديد")
            {
                
            }
        }
        private void windowsUIButtonPanel1_Click_1(object sender, EventArgs e)
        {



        }

        private void Frm_ProjectCode_Show_Load(object sender, EventArgs e)
        {
            CreateColumns(treeList1);
            //CreateNodes(treeList1);
            UseNewItemRowToAddNodes(treeList1);
            AppendingNodes(treeList1);
            RemovingNode(treeList1);
            RemovingSelectedNodes(treeList1);
            treeList1.ExpandAll();
            DragDropManager.Default.DragOver += OnDragOver;
            DragDropManager.Default.DragDrop += OnDragDrop;
            
        }
        public static void AppendingNodes(TreeList treeList)
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
        private void CreateColumns(TreeList tl)
        {
            // Create three columns.
            tl.BeginUpdate();
            TreeListColumn col1 = tl.Columns.Add();
            col1.Caption = "Code";
            col1.VisibleIndex = 0;
            TreeListColumn col2 = tl.Columns.Add();
            col2.Caption = "Discription";
            col2.VisibleIndex = 1;
            TreeListColumn col3 = tl.Columns.Add();
            col3.Caption = "Category";
            col3.VisibleIndex = 2;
            tl.EndUpdate();
        }
        private void CreateNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();
            // Create a root node .
            TreeListNode parentForRootNodes = null;
            TreeListNode rootNode = tl.AppendNode(
                new object[] { "/1/", "Alfreds Futterkiste", "Germany, Obere Str. 57" }, parentForRootNodes);
            TreeListNode rootNode2 = tl.AppendNode(
               new object[] { "/2/", "Alfreds Futterkiste", "Germany, Obere Str. 57" }, parentForRootNodes);

            // Create a child of the rootNode
            tl.AppendNode(new object[] { "/" + (rootNode.Id + 1).ToString() + "/1/", "Suyama, Michael", "Obere Str. 55" }, rootNode);
            tl.AppendNode(new object[] { "/" + (rootNode.Id + 1).ToString() + "/2/", "Suyama, Michael", "Obere Str. 55" }, rootNode);

            // Create a child of the rootNode2
            tl.AppendNode(new object[] { "/" + (rootNode2.Id + 1).ToString() + "/1/", "Suyama, Michael", "Obere Str. 55" }, rootNode2);
            tl.AppendNode(new object[] { "/" + (rootNode2.Id + 1).ToString() + "/2/", "Suyama, Michael", "Obere Str. 55" }, rootNode2);
            tl.EndUnboundLoad();
        }
        private void OnDragDrop(object sender, DragDropEventArgs e)
        {
            if (object.ReferenceEquals(e.Source, e.Target))
                return;
            e.Handled = true;
            if (e.Action == DragDropActions.None || e.InsertType == InsertType.None)
                return;
            if (e.Target == treeList1)
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
            treeList1.BeginUpdate();
            treeList1.Selection.UnselectAll();
            List<object> _items = new List<object>(items);
            foreach (object _item in _items)
            {
                DataRowView rowView = _item as DataRowView;
                TreeListNode node = treeList1.AppendNode(rowView.Row.ItemArray, index == -1000 ? destNode : null);
                if (index > -1)
                {
                    treeList1.MoveNode(node, destNode.ParentNode, true, index);
                    index++;
                }
                if (e.Action != DragDropActions.Copy)

                treeList1.SelectNode(node);
                if (node.ParentNode != null)
                    node.ParentNode.Expand();
            }

            treeList1.EndUpdate();
        }
        int CalcDestNodeIndex(DragDropEventArgs e, TreeListNode destNode)
        {
            if (destNode == null)
                return -1;
            if (e.InsertType == InsertType.AsChild)
                return -1000;
            var nodes = destNode.ParentNode == null ? treeList1.Nodes : destNode.ParentNode.Nodes;
            int index = nodes.IndexOf(destNode);
            if (e.InsertType == InsertType.After)
                return ++index;
            return index;
        }
        TreeListNode GetDestNode(Point hitPoint)
        {
            Point pt = treeList1.PointToClient(hitPoint);
            DevExpress.XtraTreeList.TreeListHitInfo ht = treeList1.CalcHitInfo(pt);
            TreeListNode destNode = ht.Node;
            if (destNode is TreeListAutoFilterNode)
                return null;
            return destNode;
        }
        public static void RemovingSelectedNodes(TreeList treeList)
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
        public static void RemovingNode(TreeList treeList)
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
        //[DefaultValue(NewItemRowPosition.None)]
        //[XtraSerializableProperty]
        //public virtual NewItemRowPosition NewItemRowPosition { get; set; }
        public enum NewItemRowPosition
        public void UseNewItemRowToAddNodes(TreeList treeList)
        {

    ////        treeList1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;

    ////        Handle the InitNewRow event to initialize newly added rows.To initialize row cells use the SetRowCellValue method
    ////        treeList1.InitNewRow += (s, e) =>
    ////        {
    ////            GridView view = s as GridView;
    ////    Set the new row cell value
    ////   view.SetRowCellValue(e.RowHandle, view.Columns["RecordDate"], DateTime.Today);
    ////    view.SetRowCellValue(e.RowHandle, view.Columns["Name"], "CustomName");
    ////             Obtain the new row cell value
    ////            int newRowID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "ID"));
    ////    view.SetRowCellValue(e.RowHandle, view.Columns["Notes"], string.Format("Row ID: {0}", newRowID));
    ////        };

    ////treeList.OptionsBehavior.Editable = true;
    ////         Display a New Item Row to add nodes to the TreeList.
    ////        treeList.OptionsView.NewItemRowPosition = TreeListNewItemRowPosition.Top; // Available modes: Top, Bottom, None
        }
    }
}