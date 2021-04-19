using NUnit.Framework;
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
        public void ToSequentialList_TreeHasAChildNodeWithCodeOfARoot_AssertThatTheTreeIsValid()
        {

            var tree = new TreeList();

            var p3 = tree.Nodes.Add();
            p3.Tag = new Hi { HCode = "/2/3/", Name = "p3" };

            var p1 = p3.Nodes.Add();//was root and changed to be a child
            p1.Tag = new Hi { HCode="/2/", Name = "p1" };


            var p2 = p1.Nodes.Add();
            p2.Tag = new Hi { HCode = "/2/2/", Name = "p2" };


            var list = tree.ToSequentialList<Hi>();
            var pL3 = list[0];
            var pL1 = list[1];
            var pL2 = list[2];


            var p3CodeLevel = pL3.Code.Split('/').Where(s => !string.IsNullOrEmpty(s)).ToList();
            var p1CodeLevel = pL1.Code.Split('/').Where(s => !string.IsNullOrEmpty(s)).ToList();
            var p2CodeLevel = pL2.Code.Split('/').Where(s => !string.IsNullOrEmpty(s)).ToList();


            //assert for vaild code
            Assert.That(p3CodeLevel.Count, Is.EqualTo(1).And.Not.EqualTo("/2/3/"));
            Assert.That(p1CodeLevel.Count, Is.EqualTo(2).And.Not.EqualTo("/2/"));
            Assert.That(p2CodeLevel.Count, Is.EqualTo(3).And.Not.EqualTo("/2/2/"));
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

        [Test]
        public void IsRoot_HireachyCodeHasOneLvel_ReturnTrueAsTheNodeIsARoot()
        {
            var node = new Hi { HCode = "/11/" };
            var IsRoot = node.IsRoot();

            Assert.That(condition: IsRoot);
        }

        [Test]
        public void IsRoot_HireachyCodeHasTwoLvel_ReturnFalseAsTheNodeIsNotARoot()
        {
            var node = new Hi { HCode = "/11/12/" };
            var IsRoot = node.IsRoot();

            Assert.That(condition: !IsRoot);
        }

        [Test]
        public void IsRoot_HireachyCodeIsASlash_ReturnTrueAsTheNodeIsARoot()
        {
            var node = new Hi { HCode = "/" };
            var IsRoot = node.IsRoot();

            Assert.That(condition: IsRoot);
        }

        [Test]
        public void IsRoot_HireachyCodeIsANull_ReturnFalseAsTheNodeIsNotARoot()
        {
            var node = new Hi { };
            var IsRoot = node.IsRoot();

            Assert.That(condition: !IsRoot);
        }

        [Test]
        public void ParentCode_NodeIsNotRoot_ReturnCodeOfParent()
        {
            var node = new Hi { HCode = "/555/111/" };
            var parent = node.ParentCode();
            Assert.That(parent, Is.EqualTo("/555/"));
        }

        [Test]
        public void ParentCode_NodeIsARoot_ReturnCodeOfParentIsSlash()
        {
            var node = new Hi { HCode = "/555/" };
            var parent = node.ParentCode();
            Assert.That(parent, Is.EqualTo("/"));
        }
        [Test]
        public void ParentCode_NodeCodeIsNull_ThrowArgumentNullException()
        {
            var node = new Hi {};

            Assert.Throws<ArgumentNullException>(()=>node.ParentCode());
        }




    }
}
