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

        readonly Static st = new Static();
        public Frm_UnifiedCode_Show()
        {
            InitializeComponent();
            _externalAPIs = new ExternalAPIs();

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
            else if (btn.Caption == "Save Unified")
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

                    ClearAllDataUnified();
                }

            }

        }

        private void Frm_UnifiedCode_Show_Load(object sender, EventArgs e)
        {
            ClearAllDataUnified();
            CreateColumns(tree_UnifiedCode);



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
            IUnifiedCodeCategoryService _categoryService = ServiceBuilder.Build<IUnifiedCodeCategoryService>();
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
            if (cm_Categories.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose the Unified first.");
                return false;
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

        void AddRootUnifiedCode(string Category, string UnifiedCodeTitle, int CategoryId)
        {
            var _Tag = new Models.C_Cost_Unified_Codes { Category_Id = CategoryId, Title = UnifiedCodeTitle };
            //TreeListNode newNode = tree_UnifiedCode.AppendNode(
            //    nodeData: new object[] { "/" + (tree_UnifiedCode.Nodes.Count +1)
            //    , Category, UnifiedCodeTitle },parentNode: null);
            //tree_UnifiedCode.FocusedNode = newNode;


            tree_UnifiedCode.FocusedNode = tree_UnifiedCode.AppendNode(
               nodeData: new object[] {0, "/" + (tree_UnifiedCode.Nodes.Count +1)
                , UnifiedCodeTitle,0, Category }, parentNode: null, tag: _Tag);

        }

        void AddChildUnifiedCode(string Category, string UnifiedCodeTitle, int CategoryId)
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
                    if (tree_UnifiedCode.FocusedNode.Level + 1 > 0)
                    {
                        var _Tag = new Models.C_Cost_Unified_Codes { Category_Id = CategoryId, Title = UnifiedCodeTitle };
                        //var vs = tree_UnifiedCode.GetDataRecordByNode(tree_UnifiedCode.FocusedNode);
                        //IList objectList = vs as IList;
                        //string NodeCode = objectList[0].ToString();
                        IdNode = (tree_UnifiedCode.FocusedNode.Level.ToString()
                            + "/"
                            + (tree_UnifiedCode.FocusedNode.Nodes.Count + 1).ToString());

                        tree_UnifiedCode.FocusedNode = tree_UnifiedCode.AppendNode(
                                nodeData: new object[] { 0, IdNode, UnifiedCodeTitle, 0, Category }
                                , parentNode: tree_UnifiedCode.FocusedNode, tag: _Tag);
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
            col1.Caption = "Id";
            col1.Name = "Id";
            col1.VisibleIndex = 0;
            col1.Visible = false;
            TreeListColumn col2 = tl.Columns.Add();
            col2.Caption = "Unified Code";
            col2.Name = "UnifiedCode_Code";
            col2.VisibleIndex = 1;
            col2.Visible = true;
            TreeListColumn col3 = tl.Columns.Add();
            col3.Caption = "Unified Code Description";
            col3.Name = "UnifiedCode_Title";
            col3.VisibleIndex = 2;
            col3.Visible = true;
            TreeListColumn col4 = tl.Columns.Add();
            col4.Caption = "Unified Code Parent";
            col4.Name = "UnifiedCode_Parent";
            col4.VisibleIndex = 3;
            col4.Visible = false;
            TreeListColumn col5 = tl.Columns.Add();
            col5.Caption = "Category Name";
            col5.Name = "Category_Name";
            col5.VisibleIndex = 4;
            col5.Visible = true;
            tl.EndUpdate();
        }

        async void GetUnifiedCode()
        {
            IUnifiedCodeCategoryService _categoryService = ServiceBuilder.Build<IUnifiedCodeCategoryService>();
            IUnifiedCodeService _unifiedCodeService = ServiceBuilder.Build<IUnifiedCodeService>();
            var ResualtCategory = await _categoryService.GetCategories();
            var ResualtUnifiedCode = await _unifiedCodeService.GetUnifiedCodes();
            var innerJoin = from p in ResualtUnifiedCode
                            join c in ResualtCategory on p.Category_Id equals c.Id
                            select new
                            {
                                Id = p.Id,
                                UnifiedCode_Code = p.Code,
                                UnifiedCode_Title = p.Title,
                                UnifiedCode_Parent = p.Parent,
                                Category_Name = c.Name,
                                CategoryId = c.Id

                            };
            //var UnifiedList = innerJoin.ToList();
            var linqlisti = innerJoin.ToList().AsEnumerable();
            DataTable table = LINQResultToDataTable(linqlisti);
            //tree_UnifiedCode.OptionsBehavior.PopulateServiceColumns = true;
            if (table.Rows.Count > 0)
            {
                tree_UnifiedCode.KeyFieldName = "Id";
                tree_UnifiedCode.ParentFieldName = "UnifiedCode_Parent";
                //tree_UnifiedCode.DataSource = table;
                tree_UnifiedCode.ClearNodes();
                var linqlist = linqlisti.Where(x => x.UnifiedCode_Parent as int? == null).AsEnumerable();
                DataTable dataRows = LINQResultToDataTable(linqlist);
                for (int i = 0; i < dataRows.Rows.Count; i++)
                {
                    int id, UnifiedCode_Parent, CategoryId;
                    string UnifiedCode_Code, UnifiedCode_Title, Category_Name;
                    id = Convert.ToInt32(dataRows.Rows[i]["id"].ToString());
                    UnifiedCode_Code = dataRows.Rows[i]["UnifiedCode_Code"].ToString();
                    UnifiedCode_Title = dataRows.Rows[i]["UnifiedCode_Title"].ToString();
                    CategoryId = Convert.ToInt32(dataRows.Rows[i]["CategoryId"].ToString());
                    Category_Name = dataRows.Rows[i]["Category_Name"].ToString();

                    var _Tag = new Models.C_Cost_Unified_Codes
                    {
                        Id = id,
                        Code = UnifiedCode_Code,
                        Category_Id = CategoryId
                        ,
                        Title = UnifiedCode_Title,
                        Parent = null
                    };
                    TreeListNode parentNode = tree_UnifiedCode.AppendNode(new object[] { id, UnifiedCode_Code, UnifiedCode_Title, null, Category_Name }, null, tag: _Tag);

                    var linqlistj = linqlisti.Where(x => x.UnifiedCode_Parent == id).AsEnumerable();
                    DataTable dataRowsj = LINQResultToDataTable(linqlistj);
                    for (int j = 0; j < dataRowsj.Rows.Count; j++)
                    {
                        id = Convert.ToInt32(dataRowsj.Rows[j][0].ToString());
                        UnifiedCode_Code = dataRowsj.Rows[j][1].ToString();
                        UnifiedCode_Title = dataRowsj.Rows[j][2].ToString();
                        UnifiedCode_Parent = Convert.ToInt32(dataRowsj.Rows[j]["UnifiedCode_Parent"].ToString());
                        CategoryId = Convert.ToInt32(dataRowsj.Rows[j]["CategoryId"].ToString());
                        Category_Name = dataRowsj.Rows[j]["Category_Name"].ToString();

                        _Tag = new Models.C_Cost_Unified_Codes { Id = id, Code = UnifiedCode_Code, Category_Id = CategoryId, Title = UnifiedCode_Title, Parent = UnifiedCode_Parent };
                        TreeListNode parentNodex = tree_UnifiedCode.AppendNode(new object[] { id, UnifiedCode_Code, UnifiedCode_Title, UnifiedCode_Parent, Category_Name }, parentNode, tag: _Tag);

                        var linqlistx = innerJoin.Where(x => x.UnifiedCode_Parent == id).AsEnumerable();
                        DataTable dataRowsx = LINQResultToDataTable(linqlistx);
                        for (int x = 0; x < dataRowsx.Rows.Count; x++)
                        {
                            id = Convert.ToInt32(dataRowsx.Rows[x][0].ToString());
                            UnifiedCode_Code = dataRowsx.Rows[x][1].ToString();
                            UnifiedCode_Title = dataRowsx.Rows[x][2].ToString();
                            UnifiedCode_Parent = Convert.ToInt32(dataRowsx.Rows[x]["UnifiedCode_Parent"].ToString());
                            CategoryId = Convert.ToInt32(dataRowsx.Rows[x]["CategoryId"].ToString());
                            Category_Name = dataRowsx.Rows[x]["Category_Name"].ToString();

                            _Tag = new Models.C_Cost_Unified_Codes { Id = id, Code = UnifiedCode_Code, Category_Id = CategoryId, Title = UnifiedCode_Title, Parent = UnifiedCode_Parent };
                            TreeListNode parentNodeq = tree_UnifiedCode.AppendNode(new object[] { id, UnifiedCode_Code, UnifiedCode_Title, UnifiedCode_Parent, Category_Name }, parentNodex, tag: _Tag);

                            var linqlistq = innerJoin.Where(m => m.UnifiedCode_Parent == id).AsEnumerable();
                            DataTable dataRowsq = LINQResultToDataTable(linqlistq);
                            for (int q = 0; q < dataRowsq.Rows.Count; q++)
                            {
                                id = Convert.ToInt32(dataRowsq.Rows[q][0].ToString());
                                UnifiedCode_Code = dataRowsq.Rows[q][1].ToString();
                                UnifiedCode_Title = dataRowsq.Rows[q][2].ToString();
                                UnifiedCode_Parent = Convert.ToInt32(dataRowsq.Rows[q]["UnifiedCode_Parent"].ToString());
                                CategoryId = Convert.ToInt32(dataRowsq.Rows[q]["CategoryId"].ToString());
                                Category_Name = dataRowsq.Rows[q]["Category_Name"].ToString();

                                _Tag = new Models.C_Cost_Unified_Codes { Id = id, Code = UnifiedCode_Code, Category_Id = CategoryId, Title = UnifiedCode_Title, Parent = UnifiedCode_Parent };
                                tree_UnifiedCode.AppendNode(new object[] { id, UnifiedCode_Code, UnifiedCode_Title, UnifiedCode_Parent, Category_Name }, parentNodeq, tag: _Tag);
                            }
                        }
                    }
                }
            }

            //  TreeList.AppendNode adds a new TreeListNode containing the specified values to the XtraTreeList.




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

        async void SaveProectCode()
        {
            IUnifiedCodeService _unifiedCodeService = ServiceBuilder.Build<IUnifiedCodeService>();
            var ResualtUnifiedCode = await _unifiedCodeService.GetUnifiedCodes();
            //var UnifiedList = innerJoin.ToList();
            var linqlisti = ResualtUnifiedCode.ToList().AsEnumerable();
            DataTable table = LINQResultToDataTable(linqlisti);

            var Resault = TreeListHandler.ToSequentialList<C_Cost_Unified_Codes>(tree_UnifiedCode).ToList();
            if (table.Rows.Count > 0)
            {
                await _unifiedCodeService.Update(Resault);
            }
            else
            {
                await _unifiedCodeService.NewUnifiedCodes(Resault);
            }
            MessageBox.Show("The data has been saved successfully. ");
        }

        #endregion Methods For my Form


    }
}