using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;


namespace PSC_Cost_Control.Helper.TreeListHandler
{
    public class TreeListHandler
    {
        public List<C_Cost_Project_Codes> HandleProjectCodes(TreeList tree)
        {
            var list = new List<C_Cost_Project_Codes>();
            var parents = tree.Nodes.ToList();
            foreach(var n in parents)
            {
                var code = $"/{new Random().Next(1, 1000)}/";
                list.Add(new C_Cost_Project_Codes() { Code = code });
                ProjectCodesConvertorHelper_Rec(n,code , list);
            }
            return list;
        }

        private void ProjectCodesConvertorHelper_Rec(TreeListNode node,string code,List<C_Cost_Project_Codes> rt)
        {
            var childs = node.Nodes.ToList();
            foreach(var n in childs)
            {
                var newCode = $"{code}{new Random().Next(1, 1000)}/";
                rt.Add(new C_Cost_Project_Codes() { Code = newCode });
                ProjectCodesConvertorHelper_Rec(n,newCode, rt);
            }
        }
    }
}
