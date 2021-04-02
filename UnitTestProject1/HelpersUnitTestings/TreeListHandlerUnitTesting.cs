using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using PSC_Cost_Control.Helper.TreeListHandler;
using PSC_Cost_Control.Helper.Interfaces;

namespace UnitTestProject1.HelpersUnitTestings
{
    [TestFixture]
    public class TreeListHandlerUnitTesting
    {
        private TreeList _tree;
        public class Hi : IHireichy
        {
            public string Name { set; get; }
            public string Code { set; get; }
            public Hi Parent { set; get; }
            public string HCode { get => Code; set => Code=value; }
            public IHireichy HParent { get => Parent; set => Parent=(Hi)value; }
        }
        [SetUp]
        public void SetUp()
        {
            _tree = new TreeList();
            var p1=_tree.Nodes.Add();
            p1.Tag = new Hi { Name = "p1" };
            var p11=p1.Nodes.Add();
            p11.Tag = (new Hi { Name = "p1/1" });
            var x1=p1.Nodes.Add();
            x1.Tag = new Hi{Name = "x1"};
            var x11=x1.Nodes.Add();
            x11.Tag = new Hi { Name = "x11" };

            var p2 = _tree.Nodes.Add();
            p2.Tag = new Hi { Name = "p2" };
            var p22=p2.Nodes.Add();
            p22.Tag = new Hi { Name = "p2/1" };

        }

        [Test]
        public void ToSequentialList_ReturnAlistWithValidParentsAndCodes()
        {
            var list = _tree.ToSequentialList<Hi>();
            Assert.That(list.Count, Is.EqualTo(6));

            Assert.That(list[0].Parent, Is.Null);
            Assert.That(list[0].Code, Is.Not.Null.And.Not.Empty);

           
        }

    }
}
