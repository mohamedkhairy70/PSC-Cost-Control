﻿using DevExpress.XtraEditors;
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

namespace PSC_Cost_Control.Forms.Project_Code
{
    public partial class Frm_ProjectCode_Show : DevExpress.XtraEditors.XtraForm
    {
        readonly Static st = new Static();



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
            CreateColumns(tree_ProjectCode);

            //CreateNodes(treeList1);
            AppendingNodes(tree_ProjectCode);
            RemovingNode(tree_ProjectCode);
            RemovingSelectedNodes(tree_ProjectCode);
            tree_ProjectCode.ExpandAll();
            DragDropManager.Default.DragOver += OnDragOver;
            DragDropManager.Default.DragDrop += OnDragDrop;
            
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
        public void ClearAllData()
        {
            cm_Categories.DataSource = null;
            cm_Categories.SelectedItem = -1;
            cm_Categories.Enabled = false;


            txt_Description.Text = "";
            txt_Description.Enabled = false;

            cm_Projects.Enabled = true;
            cm_Projects.SelectedItem = -1;

            tree_ProjectCode.DataSource = null;
        }


        private void cm_Projects_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                string NameProject = cm_Projects.SelectedText.ToString();

            }
            catch { }
        }
    }
}