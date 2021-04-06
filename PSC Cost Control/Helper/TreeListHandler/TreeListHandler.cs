using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using PSC_Cost_Control.Helper.Interfaces;

namespace PSC_Cost_Control.Helper.TreeListHandler
{
    public static class TreeListHandler
    {
        /// <summary>
        /// convert from treeList in devExpress to List with elements have apropriate HireachyId and parent.
        /// it will generate new code for every node even if it has a value that is not Null
        /// </summary>
        /// <typeparam name="T">data type of Tag in TreeListNode</typeparam>
        /// <param name="tree">Devexpree treeList object</param>
        /// <returns></returns>
        public static List<T> ToSequentialList<T> (this TreeList tree) where T:IHireichy
        {
            var list = new List<T>();
            var parents = tree.Nodes.ToList();
            foreach(var n in parents)
            {
                //code is generated in random
                var code = $"/{GetGuid()}/";

                //add code and parent to object
                var o = (T)n.Tag;
                o.HCode = code;
                o.HParent = null;//root node has no Parent

                list.Add(o);
                ToList_Rec(n,code , list);
            }
            return list;
        }

        private static int GetGuid() => new Random().Next(10, 1000000);

        private static void ToList_Rec<T>(TreeListNode node,string code,List<T> rt) where T : IHireichy
        {
            var childs = node.Nodes.ToList();
            foreach(var n in childs)
            {
                var newCode = $"{code}{GetGuid()}/";

                var o = (T)n.Tag;

                o.HParent = (T)n.ParentNode.Tag;
                o.HCode = newCode;

                rt.Add(o);
                ToList_Rec(n,newCode, rt);
            }
        }

  
    }
}
