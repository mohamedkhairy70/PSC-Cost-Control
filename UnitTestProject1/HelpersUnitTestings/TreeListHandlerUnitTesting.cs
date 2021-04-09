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
            public int? ParentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }
        [SetUp]
        public void SetUp()
        {
            _tree = new TreeList();

            var p1=_tree.Nodes.Add();
            p1.Tag = new Hi { Name = "p1" };
       
            var x1=p1.Nodes.Add();
            x1.Tag = new Hi{Name = "x1"};
         

            var p2 = _tree.Nodes.Add();
            p2.Tag = new Hi { Name = "p2" };

            var p22=p2.Nodes.Add();
            p22.Tag = new Hi { Name = "p2/1" };

        }

        [Test]
        public void ToSequentialList_AssertListHas4Elements()
        {
            var list = _tree.ToSequentialList<Hi>();
            Assert.That(list.Count, Is.EqualTo(4));
        }

        [Test]
        public void ToSequentialList_AssertThatCodeIsValid()
        {
            var list = _tree.ToSequentialList<Hi>();
            var p1Code = list[0].Code;// p1 Node
            var p22Code = list[3].Code;//p22 Node
            var p1CodeLevel = p1Code.Split('/').Where(s=>!string.IsNullOrEmpty(s)).ToList();
            var p22CodeLevel = p22Code.Split('/').Where(s => !string.IsNullOrEmpty(s)).ToList();
            Assert.That(p1CodeLevel, Has.Count.EqualTo(1)); //level 0
            Assert.That(p22CodeLevel, Has.Count.EqualTo(2)); //level 1
        }

        [Test]
        public void ToSequentialList_AssertThatParentIsValid()
        {
            var list = _tree.ToSequentialList<Hi>();
            var p2 = list[2];
            var p22 = list[3];
            Assert.That(p2.Parent, Is.Null);
            Assert.That(p22.Parent, Is.SameAs(p2));
        }


    }
}
