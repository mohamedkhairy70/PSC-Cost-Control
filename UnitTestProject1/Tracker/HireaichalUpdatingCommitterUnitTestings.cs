using Moq;
using NUnit.Framework;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Trackers;
using PSC_Cost_Control.Trackers.Commiters;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System.Collections.Generic;

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
        private IDictionary<string, int> damaged;

        [SetUp]
        public void SetUp()
        {
            damaged= new Dictionary<string, int>();
            n1 = new C_Cost_Project_Codes { Description = "n1", Code = "/22/", HParent = null };
             p33 = new C_Cost_Project_Codes { Id=33,Description = "p33", Code = "/44/", HParent = null };//old 
             p22 = new C_Cost_Project_Codes {Id=22, Description = "p22", Code = "/22/5/", HParent = n1 };//old
             n2 = new C_Cost_Project_Codes { Description = "n2", Code = "/22/3/", HParent = n1 };
             n3 = new C_Cost_Project_Codes { Description = "n3", Code = "/44/7/", HParent = p33 };

            var deleted = new List<C_Cost_Project_Codes> {
                new C_Cost_Project_Codes{Id=77,Description="deleted77"}
            };

            var added = new List<C_Cost_Project_Codes> {
                n1,n2,n3
            };

            var updated = new List<C_Cost_Project_Codes> {
                p22,p33
            };

            var tracker = new Mock<ITracker<C_Cost_Project_Codes>>();

            tracker.Setup(t => t.GetDeletedEntities()).Returns(deleted);

            tracker.Setup(t => t.GetUpdatedEntities()).Returns(updated);

            tracker.Setup(t => t.GetNewEntities()).Returns(added);

            var persistent = new Mock<IHirechicalPersistent<C_Cost_Project_Codes>>();
         

            persistent.Setup(c => c.GetDamagedHiraichals(null)).Returns(damaged);
            _commiter = new HireaichalUpdatingCommitter<C_Cost_Project_Codes>(persistent.Object, tracker.Object);

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

    }
}
