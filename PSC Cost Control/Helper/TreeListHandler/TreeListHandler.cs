using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using PSC_Cost_Control.Helper.Interfaces;
using System.Text;

namespace PSC_Cost_Control.Helper.TreeListHandler
{
    public static class TreeListHandler
    {
        /// <summary>
        /// convert from treeList in devExpress to List with elements have apropriate HireachyId and parent.
        /// it will generate new code for nodes do not have code(code is empty or NULL).
        /// nodes have a code will not have new code.
        /// </summary>
        /// <typeparam name="T">data type of Tag in TreeListNode</typeparam>
        /// <param name="tree">Devexpree treeList object</param>
        /// <returns>List of items of T </returns>
        public static List<T> ToSequentialList<T> (this TreeList tree) where T:IHireichy
        {
            var list = new List<T>();
            var guidInt = new GuidIntGenerator();
            var parents = tree.Nodes.ToList();
            foreach(var n in parents)
            {
                //add code and parent to object
                var o = (T)n.Tag;

                if (string.IsNullOrEmpty(o.HCode))
                    o.HCode =$"/{guidInt.Guid()}/";
                else
                    guidInt.Block(GetLastLevelCode(o.HCode));

                o.HParent = null;//root node has no Parent

                list.Add(o);
                ToList_Rec(n,o.HCode , list,guidInt);
            }
            return list;
        }


        private static void ToList_Rec<T>(TreeListNode node,string code,List<T> rt,GuidIntGenerator guidInt) where T : IHireichy
        {
            var childs = node.Nodes.ToList();
            foreach(var n in childs)
            {
                var o = (T)n.Tag;
                o.HParent = (T)n.ParentNode.Tag;

                var b = !o.HParent.HasChild(o);
                if (string.IsNullOrEmpty(o.HCode) || !o.HParent.HasChild(o))
                    o.HCode = $"{code}{guidInt.Guid()}/";
                else
                {
                    guidInt.Block(GetLastLevelCode(o.HCode));
                }

                rt.Add(o);
                ToList_Rec(n,o.HCode, rt,guidInt);
            }
        }

        private static int GetLastLevelCode(string hireachyId)
        {
            var stack = new Stack<char>(12);

            for(var i = hireachyId.Length - 2; i >= 0 && ! hireachyId[i].Equals('/'); i++)
                stack.Push(hireachyId[i]);

            string output = "";
            while (stack.Count>0)
                output += stack.Pop();

            return short.Parse(output);
        }

        /// <summary>
        /// Check wether a specific node have a specific direct child.
        /// the process will depend only on comparing hireaical codes
        /// </summary>
        /// <param name="node">the parent</param>
        /// <param name="child">the node you need to validate if his parent is "node" or not</param>
        /// <returns></returns>
        public static bool HasChild(this IHireichy node, IHireichy child) 
        {

            var parentArr = node.HCode?.Split('/');
            var childArr = child.HCode?.Split('/');
            if (parentArr is null||childArr is null) return false;
            for(int i = 0; i<parentArr.Length-1; i++)
            {
                if (!parentArr[i].Equals(childArr[i]))
                    return false;
            }
            return
                parentArr.Length + 1 == childArr.Length;
               
        }
            
    }
}
