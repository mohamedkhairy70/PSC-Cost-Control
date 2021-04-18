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
using PSC_Cost_Control.Services.UnifiedCodesServices;
using PSC_Cost_Control.Services.ServicesBuilders;
using System.Reflection;

namespace PSC_Cost_Control.Forms.Unified_Code
{
    public partial class Frm_UnifiedCode_Show : DevExpress.XtraEditors.XtraForm
    {
        public ExternalAPIs _externalAPIs;
        public IUnifiedCodeCategoryService _categoryService;
        public IUnifiedCodeService _UnifiedCode;
        public IUnifiedCodeService _unifiedCodeService;

        readonly Static st = new Static();
        public Frm_UnifiedCode_Show()
        {
            InitializeComponent();
            _externalAPIs = new ExternalAPIs();
            _categoryService = ServiceBuilder.Build<IUnifiedCodeCategoryService>();
            _UnifiedCode = ServiceBuilder.Build<IUnifiedCodeService>();
            _unifiedCodeService = ServiceBuilder.Build<IUnifiedCodeService>();

        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            if (btn.Caption == "New Unified Code")
            {
                //Clear all Data from Unified Code Combobox Categore and text Description
                ClearAllDataUnifiedCode();
            }
            else if (btn.Caption == "New Unified")
            {
                //Clear all Data from Unified Code Combobox Categore and text Description and Unified
                ClearAllDataUnified();
            }
            else if (btn.Caption == "Add Root")
            {
                //Check if Unified is Null
                if (validationUnifieds())
                {

                    //Check if Category and description is Null
                    if (validationUnifiedCode())
                    {
                        //Add Root Unified Code To Treelist
                        AddRootUnifiedCode(cm_Categories.Text, txt_Description.Text, Convert.ToInt32(cm_Categories.SelectedValue));

                        //Clear Combobox Categore and text Description
                         ClearAllDataUnifiedCode();
                    }
                }
            }
            else if (btn.Caption == "Add Child")
            {
                //Check if Unified is Null
                if (validationUnifieds())
                {

                    //Check if Category and description is Null
                    if (validationUnifiedCode())
                    {
                        //Add Child Unified Code To Treelist
                        AddChildUnifiedCode(cm_Categories.Text, txt_Description.Text, Convert.ToInt32(cm_Categories.SelectedValue));

                        //Clear Combobox Categore and text Description
                        ClearAllDataUnifiedCode();
                    }
                }
                
            }
            else if (btn.Caption == "Delete")
            {
                //Check if Unified is Null
                if (validationUnifieds())
                {
                    //Delete Unified Code To Treelist
                    DeleteUnifiedCode();

                    //Clear Combobox Categore and text Description
                    ClearAllDataUnifiedCode();
                }
            }
            else if(btn.Caption == "Save Unified")
            {
                //Check if Unified is Null
                if (validationUnifieds())
                {
                    //Add Unified Code To Treelist
                    if (tree_UnifiedCode.AllNodesCount > 0)
                    {
                        SaveProectCode();
                    }
                    else
                    {
                        MessageBox.Show("There's no data on the Unified Code table. ");
                    }
                    //Clear Combobox Categore and text Description
                    MessageBox.Show("The data has been saved successfully. ");
                    ClearAllDataUnifiedCode();
                }
                
            }

        }

        private async void Frm_UnifiedCode_Show_Load(object sender, EventArgs e)
        {
            ClearAllDataUnified();
            //CreateColumns(tree_UnifiedCode);
            
            
            
            DragDropManager.Default.DragOver += OnDragOver;
            DragDropManager.Default.DragDrop += OnDragDrop;

            GetUnifiedCode();
            tree_UnifiedCode.ExpandAll();
        }


        private void tree_UnifiedCode_NodeChanged(object sender, NodeChangedEventArgs e)
        {

        }

        #region Method for Create TreeList


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
        async void ClearAllDataUnified()
        {

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

            tree_UnifiedCode.DataSource = null;
        }

        void ClearAllDataUnifiedCode()
        {
            cm_Categories.SelectedItem = -1;
            txt_Description.Text = "";

        }

        bool validationUnifieds()
        {
            bool result;
            if(cm_Categories.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose the Unified first.");
                return  false;
            }
            else
            {
                result = true;
            }
           
            return result;
        }

        bool validationUnifiedCode()
        {
            bool result;
            if (Convert.ToInt32(cm_Categories.SelectedValue) > 0)
            {
                result = true;
                
            }
            else
            {
                MessageBox.Show("Please choose the category to add the Unified Code.");
                return false;
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

        void AddRootUnifiedCode(string Category,string UnifiedCodeTitle,int CategoryId)
        {
            var _Tag = new Models.C_Cost_Unified_Codes { Category_Id = CategoryId, Title = UnifiedCodeTitle };
            tree_UnifiedCode.FocusedNode = tree_UnifiedCode.AppendNode(nodeData: new object[] { "/" + (tree_UnifiedCode.Nodes.Count +1), Category, UnifiedCodeTitle },parentNode: null, tag: _Tag);
        }

        void AddChildUnifiedCode(string Category,string UnifiedCodeTitle, int CategoryId)
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
                        var _Tag = new Models.C_Cost_Unified_Codes { Category_Id = CategoryId, Title = UnifiedCodeTitle };
                        //var vs = tree_UnifiedCode.GetDataRecordByNode(tree_UnifiedCode.FocusedNode);
                        //DataRow objectList = vs as DataRow;
                        //string NodeCode = objectList[0].ToString();
                        //IdNode = (NodeCode
                        //    + "/"
                        //    + (tree_UnifiedCode.FocusedNode.Nodes.Count +1).ToString());

                        tree_UnifiedCode.FocusedNode =  tree_UnifiedCode.AppendNode(
                                nodeData: new object[] { IdNode, Category, UnifiedCodeTitle }
                                , parentNode:null,tag: _Tag);
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
        private void CreateColumns(TreeList tl)
        {
            // Create three columns.
            tl.BeginUpdate();
            TreeListColumn col1 = tl.Columns.Add();
            col1.Caption = "Unified Code";
            col1.Name = "UnifiedCode_Code";
            col1.VisibleIndex = 0;
            TreeListColumn col2 = tl.Columns.Add();
            col2.Caption = "Unified Code Title";
            col2.Name = "UnifiedCode_Title";
            col2.VisibleIndex = 1;
            TreeListColumn col3 = tl.Columns.Add();
            col3.Caption = "Category Name";
            col3.Name = "Category_Name";
            col3.VisibleIndex = 2;
            TreeListColumn col4 = tl.Columns.Add();
            col4.Caption = "Unified Code Parent";
            col4.Name = "UnifiedCode_Parent";
            col4.VisibleIndex = 3;
            tl.EndUpdate();
        }
        async void GetUnifiedCode()
        {
            var ResualtCategory = await _categoryService.GetCategories();
            var ResualtUnifiedCode = await _unifiedCodeService.GetUnifiedCodes();
            var ResualtUnified = await _UnifiedCode.GetUnifiedCodes();
            var innerJoin = from p in ResualtUnified
                            join c in ResualtCategory on p.Category_Id equals c.Id
                            select new
                            {
                                Id = p.Id,
                                UnifiedCode_Code = p.Code,
                                UnifiedCode_Title = p.Title,
                                UnifiedCode_Parent = p.Parent,
                                Category_Name = c.Name
                            };
            //var UnifiedList = innerJoin.ToList();
            DataTable table = LINQResultToDataTable(innerJoin);

            //tree_UnifiedCode.OptionsBehavior.PopulateServiceColumns = true;
                tree_UnifiedCode.KeyFieldName = "Id";
                tree_UnifiedCode.ParentFieldName = "UnifiedCode_Parent";
                tree_UnifiedCode.DataSource = table;
            
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
        async Task<List<C_Cost_Unified_Codes>> Get()
        {
            return (List<C_Cost_Unified_Codes>)await _UnifiedCode.GetUnifiedCodes();
        }
        void SaveProectCode()
        {
             var Resault = TreeListHandler.ToSequentialList<C_Cost_Unified_Codes>(tree_UnifiedCode).ToList();
            //if (Get().GetAwaiter().GetResult().Count > 0)
            //{
            //    _UnifiedCode.Update(Resault);
            //}
            //else
            //{
                _UnifiedCode.NewUnifiedCodes(Resault);
            //}
            
        }

        #endregion Methods For my Form


    }
}