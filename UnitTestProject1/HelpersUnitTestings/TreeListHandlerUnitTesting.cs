using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using PSC_Cost_Control.Helper.TreeListHandler;

namespace UnitTestProject1.HelpersUnitTestings
{
    [TestFixture]
    public class TreeListHandlerUnitTesting
    {
        private TreeList _tree;
        [SetUp]
        public void SetUp()
        {
            _tree = new TreeList();
            var p1=_tree.Nodes.Add(new object());
            p1.Nodes.Add(new object());
            p1.Nodes.Add(new object());

            var p2 = _tree.Nodes.Add(new object());
            p2.Nodes.Add(new object());

        }

        [Test]
        public void t1()
        {
            var h = new TreeListHandler();
           var l= h.HandleProjectCodes(_tree);
            Assert.That(l.Count, Is.EqualTo(5));
           
        }

    }
}
