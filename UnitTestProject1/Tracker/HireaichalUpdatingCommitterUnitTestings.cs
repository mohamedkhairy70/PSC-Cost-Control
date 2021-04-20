using Moq;
using NUnit.Framework;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Trackers;
using PSC_Cost_Control.Trackers.Commiters;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1.Tracker
{
    [TestFixture]
    public class HireaichalUpdatingCommitterUnitTestings
    {
        private HireaichalUpdatingCommitter<C_Cost_Project_Codes> _commiter;

        private C_Cost_Project_Codes n1;
        private C_Cost_Project_Codes p33;
        private C_Cost_Project_Codes p22;
        private C_Cost_Project_Codes n2;
        private C_Cost_Project_Codes n3;
        private C_Cost_Project_Codes p10;
        private IDictionary<string, int> damaged;
        private Mock<IHirechicalPersistent<C_Cost_Project_Codes>> _persisitent;
        private Mock<ITracker<C_Cost_Project_Codes>> _tracker;

        [SetUp]
        public void SetUp()
        {
            damaged = new Dictionary<string, int>();
            n1 = new C_Cost_Project_Codes { Description = "n1", Code = "/22/", HParent = null };
            p33 = new C_Cost_Project_Codes { Id = 33, Description = "p33", Code = "/44/", HParent = null };//old 
            p22 = new C_Cost_Project_Codes { Id = 22, Description = "p22", Code = "/22/5/", HParent = n1 };//old
            n2 = new C_Cost_Project_Codes { Description = "n2", Code = "/22/3/", HParent = n1 };
            n3 = new C_Cost_Project_Codes { Description = "n3", Code = "/44/7/", HParent = p33 };
            p10 = new C_Cost_Project_Codes { Id = 10, Description = "p10", Code = "/44/10/", HParent = p33 };

            var deleted = new List<C_Cost_Project_Codes> {
                new C_Cost_Project_Codes{Id=77,Description="deleted77"}
            };

            var added = new List<C_Cost_Project_Codes> {
                n1,n2,n3
            };

            var updated = new List<C_Cost_Project_Codes> {
                p22,p33
            };
            var notChanged = new List<C_Cost_Project_Codes> {
                p10
            };

            _tracker = new Mock<ITracker<C_Cost_Project_Codes>>();

            _tracker.Setup(t => t.GetDeletedEntities()).Returns(deleted);

            _tracker.Setup(t => t.GetUpdatedEntities()).Returns(updated);

            _tracker.Setup(t => t.GetNewEntities()).Returns(added);

            _tracker.Setup(t => t.GetUnChangedEntities()).Returns(notChanged);

            _persisitent = new Mock<IHirechicalPersistent<C_Cost_Project_Codes>>();


            _persisitent.Setup(c => c.GetDamagedHiraichals(null)).Returns(damaged);
            _commiter = new HireaichalUpdatingCommitter<C_Cost_Project_Codes>(_persisitent.Object, _tracker.Object);

        }

        [Test]
        public void Commit_WhenCalled_AllNewNodesIdsWillBeFixedAndHaveARealValues()
        {
            damaged.Add("/22/", 22);
            damaged.Add("/22/3/", 3);
            damaged.Add("/44/7/", 7);
            _commiter.Commit();

            Assert.That(n1.Id, Is.Not.Null.Or.Zero);
            Assert.That(n2.Id, Is.Not.Null.Or.Zero);
            Assert.That(n3.Id, Is.Not.Null.Or.Zero);
        }



        [Test]
        public void Commit_DamagedEntitiesContainsAnUpdatedEntity_AllNewNodesParentsAreValidASTheParentHasTheRealIdOfTheParentNode()
        {
            damaged.Add("/22/", 22);

            damaged.Add("/22/3/", 3);
            damaged.Add("/44/7/", 7);

            damaged.Add("/44/", 33);//updated entity
            _commiter.Commit();

            Assert.That(n1.Parent, Is.EqualTo(null));
            Assert.That(n2.Parent, Is.EqualTo(n1.Id));
            Assert.That(p22.Parent, Is.EqualTo(n1.Id));
            Assert.That(p33.Parent, Is.EqualTo(null));
            Assert.That(n3.Parent, Is.EqualTo(p33.Id));
            Assert.That(p10.Parent, Is.EqualTo(p33.Id));
        }

        [Test]
        public void Commit_WhenCalled_AllNewNodesParentsAreValidASTheParentHasTheRealIdOfTheParentNode()
        {
            damaged.Add("/22/", 22);
            damaged.Add("/22/3/", 3);
            damaged.Add("/44/7/", 7);
            _commiter.Commit();

            Assert.That(n1.Parent, Is.EqualTo(null));
            Assert.That(n2.Parent, Is.EqualTo(n1.Id));
            Assert.That(p22.Parent, Is.EqualTo(n1.Id));
            Assert.That(p33.Parent, Is.EqualTo(null));
            Assert.That(n3.Parent, Is.EqualTo(p33.Id));
        }
        [Test]
        public void Commit_DamagedEntitiesContainsAnUpdatedEntity_AllNewNodesIdsWillBeFixedAndHaveARealValues()
        {
            damaged.Add("/22/", 22);
            damaged.Add("/22/3/", 3);
            damaged.Add("/44/7/", 7);

            damaged.Add("/44/", 33);//updated entity

            _commiter.Commit();

            Assert.That(n1.Id, Is.Not.Null.Or.Zero);
            Assert.That(n2.Id, Is.Not.Null.Or.Zero);
            Assert.That(n3.Id, Is.Not.Null.Or.Zero);
        }

        [Test]
        public void Commit_WhenCalled_InvokeUpdateCollectionWithAListOfCountEqualTheNewEntitiesCountPlusTheUpdatedEntitiesCountInTracker()
        {
            damaged.Add("/22/", 22);
            damaged.Add("/22/3/", 3);
            damaged.Add("/44/7/", 7);
            _commiter.Commit();

            var excpectedCount = _tracker.Object.GetNewEntities().Count() + _tracker.Object.GetUpdatedEntities().Count();

            _persisitent.Verify(p => p.UpdateCollection(It.Is<List<C_Cost_Project_Codes>>(c => c.Count == excpectedCount)));
        }

        [Test]
        public void Commit_WhenCalled_InvokeDeleteCollectionWithAlistCountEqualsEntitiesCountOFDeletedEntitiesCountInTracker()
        {
            damaged.Add("/22/", 22);
            damaged.Add("/22/3/", 3);
            damaged.Add("/44/7/", 7);
            _commiter.Commit();

            var excpectedCount = _tracker.Object.GetDeletedEntities().Count();

            _persisitent.Verify(p => p.DeleteCollection(It.Is<List<C_Cost_Project_Codes>>(c => c.Count == excpectedCount)));
        }

        [Test]
        public void Commit_WhenCalled_InvokeInsertCollectionWithAlistCountEqualsEntitiesCountOFNewEntitiesCountInTracker()
        {
            damaged.Add("/22/", 22);
            damaged.Add("/22/3/", 3);
            damaged.Add("/44/7/", 7);
            _commiter.Commit();

            var excpectedCount = _tracker.Object.GetNewEntities().Count();

            _persisitent.Verify(p => p.AddCollection(It.Is<List<C_Cost_Project_Codes>>(c => c.Count == excpectedCount)));
        }


    }
}
