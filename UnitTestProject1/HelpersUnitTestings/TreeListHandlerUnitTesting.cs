﻿using NUnit.Framework;
using System;
using System.Linq;
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

        [Test]
        public void ToSequentialList_TreeHasANodeThatAlreadyHasACodeAndTheParentDoesNotHaveChanged_AssertThatCodeIsValidAndDoesNotHaveChanged()
        {
            var tree = new TreeList();

            var p1 = tree.Nodes.Add();
            p1.Tag = new Hi {HCode="/44/", Name = "p1" };

            var x1 = p1.Nodes.Add();
            x1.Tag = new Hi { Name = "x1" };


            var p2 = tree.Nodes.Add();
            p2.Tag = new Hi { Name = "p2" };

            var p22 = p2.Nodes.Add();
            p22.Tag = new Hi { Name = "p2/1" };

            var list = tree.ToSequentialList<Hi>();
            var p1Code = list[0].Code;// p1 Node
            var x1Code = list[1].Code;

            var p1CodeLevel = p1Code.Split('/').Where(s => !string.IsNullOrEmpty(s)).ToList();
            var x1CodeLevel = x1Code.Split('/').Where(s => !string.IsNullOrEmpty(s)).ToList();

            Assert.That(p1Code, Is.EqualTo("/44/"));
            Assert.That(x1CodeLevel, Has.Count.EqualTo(2));
            Assert.That(x1Code, Does.Contain("/44/"));
        }

        [Test]
        public void ToSequentialList_TreeHasANodeThatAlreadyHasACodeAndTheParentHaveChanged_AssertThatCodeIsValidAndChanged()
        {
            var tree = new TreeList();

            var p1 = tree.Nodes.Add();
            p1.Tag = new Hi { HCode = "/44/", Name = "p1" };


            var p2 = tree.Nodes.Add();
            p2.Tag = new Hi { Name = "p2" };

            var x1 = p2.Nodes.Add();
            x1.Tag = new Hi { Name = "x1",HCode="/44/1/" };



            var p22 = p2.Nodes.Add();
            p22.Tag = new Hi { Name = "p2/1" };

            var list = tree.ToSequentialList<Hi>();
            var p1Code = list[0].Code;// p1 Node
            var x1Code = list[2].Code;

            var p1CodeLevel = p1Code.Split('/').Where(s => !string.IsNullOrEmpty(s)).ToList();
            var x1CodeLevel = x1Code.Split('/').Where(s => !string.IsNullOrEmpty(s)).ToList();

            Assert.That(x1CodeLevel, Has.Count.EqualTo(2));

            Assert.That(x1Code, Is.Not.EqualTo("/44/1/"));
        }

        [Test]
        public void ToSequentialList_TreeHasNodesThatAlreadyHaveCodes_AssertThatParentIsValid()
        {

            var tree = new TreeList();

            var p1 = tree.Nodes.Add();
            p1.Tag = new Hi { HCode = "/44/", Name = "p1" };

            var x1 = p1.Nodes.Add();
            x1.Tag = new Hi { Name = "x1" };


            var p2 = tree.Nodes.Add();
            p2.Tag = new Hi { Name = "p2" };

            var p22 = p2.Nodes.Add();
            p22.Tag = new Hi { Name = "p2/1" };

            var list = tree.ToSequentialList<Hi>();
            var pn2 = list[2];
            var pn22 = list[3];
            Assert.That(pn2.Parent, Is.Null);
            Assert.That(pn22.Parent, Is.SameAs(pn2));
        }

        [Test]
        public void HasChild_childHasAnappropriateCodeThatImpressThatChildFromHisParent_ReturnTrue()
        {
            var parent = new Hi { HCode = "/22/1/" };
            var chid = new Hi { HCode = "/22/1/15/", HParent = parent };
            Assert.That(parent.HasChild(chid));
        }

        [Test]
        public void HasChild_childDoesNotHaveAnappropriateCodeThatImpressChildFromHisParent_ReturnFalse()
        {
            var parent = new Hi { HCode = "/22/1/" };
            var chid = new Hi { HCode = "/22/3/15", HParent = parent };
            Assert.That(! parent.HasChild(chid));
        }

        [Test]
        public void HasChild_childIsNotTheDirectChildOfThePrent_ReturnFalse()
        {
            var parent = new Hi { HCode = "/22/1/" };
            var chid = new Hi { HCode =   "/22/1/17/15/", HParent = parent };
            Assert.That(!parent.HasChild(chid));
        }

        [Test]
        public void HasChild_ChildHasCodeEqualsNull_ReturnFalse()
        {
            var parent = new Hi { HCode = "/22/1/" };
            var child = new Hi { HParent = parent };
            Assert.That(!parent.HasChild(child));
        }

        [Test]
        public void HasChild_ParentHasCodeEqualsNull_ReturnFalse()
        {
            var parent = new Hi { };
            var child = new Hi { HCode = "/22/1/" , HParent = parent };
            Assert.That(!parent.HasChild(child));
        }

        [Test]
        public void HasChild_ChildCodeContainsOneALevelFromParentCode_ReturnFalse()
        {
            var parent = new Hi { HCode = "/1/" };
            var chid = new Hi { HCode = "/44/1/", HParent = parent };
            Assert.That(!parent.HasChild(chid));
        }
    }
}
