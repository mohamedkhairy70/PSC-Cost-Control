using NUnit.Framework;
using PSC_Cost_Control.Helper.Interfaces;
using System.Collections.Generic;
using System.Linq;
using PSC_Cost_Control.Trackers;
using Moq;
using PSC_Cost_Control.Trackers.PersistantCruds;

namespace UnitTestProject1.Tracker
{
    [TestFixture]
    public class TrackerUnitTestings
    {
        private List<Entity> _origin;
        public class Entity : IHasId
        {
            public int MId { set; get; }
            public string Name { set; get; }
            public int Id { get => MId; set =>Id=value; }

            public override bool Equals(object obj)
            {
                var o = obj as Entity;
                return o.Name.Equals(Name);
            }
        }

        [SetUp]
        public void SetUp()
        {
             _origin = new List<Entity>
            {
                new Entity{MId=2,Name="ahmed"},
                new Entity{MId=1,Name="khaled"}
            };
        }

        [Test]
        public void TrackCollection_Add2NewEntities_GetNewEntitiesHas2ElementsAndUpdatedElemntsHas0AndDeletedElemtHas0()
        {
            var tracked = new List<Entity> {
                new Entity{Name="sameh"},
                new Entity{Name="ali"}
            };
            var persistent = new Mock<IPersistent<Entity>>();
            var tracker = new Tracker<Entity>(_origin);
            tracker.TrackCollection(tracked);

            Assert.That(tracker.GetNewEntities().ToList(), Has.Count.EqualTo(2));
            Assert.That(tracker.GetUpdatedEntities().ToList(), Has.Count.EqualTo(0));
        }

        [Test]
        public void TrackCollection_AddAnEntityThatEqualsAnEntityInOrignButDoesNotHaveId_GetNewEntitiesReturns1AndUpdatedEquals0()
        {
            var tracked = new List<Entity> {
                new Entity{Name="ahmed"},
            };
            var persistent = new Mock<IPersistent<Entity>>();
            var tracker = new Tracker<Entity>( _origin);
            tracker.TrackCollection(tracked);

            Assert.That(tracker.GetNewEntities().ToList(), Has.Count.EqualTo(1));
            Assert.That(tracker.GetUpdatedEntities().ToList(), Has.Count.EqualTo(0));
        }

        [Test]
        public void TrackCollection_TrackedEntitiesDoesNotContainAnyElementInOrigin_GetDeletedElementsEquals2()
        {
            var tracked = new List<Entity> {
                new Entity{Name="ahmed"},
            };
            var persistent = new Mock<IPersistent<Entity>>();
            var tracker = new Tracker<Entity>( _origin);
            tracker.TrackCollection(tracked);

            Assert.That(tracker.GetDeletedEntities().ToList(), Has.Count.EqualTo(2));
        }

        [Test]
        public void TrackCollection_TrackedEntityExistsInOriginButUpdated_GetUpdatedElementsEquals1()
        {
            var tracked = new List<Entity> {
                new Entity{MId=1,Name="ahmed"},
            };
            var persistent = new Mock<IPersistent<Entity>>();
            var tracker = new Tracker<Entity>(_origin);
            tracker.TrackCollection(tracked);
            Assert.That(tracker.GetUpdatedEntities().ToList(), Has.Count.EqualTo(1));
        }

        [Test]
        public void TrackCollection_OriginIsEmpty_AllTrackedWillBeInGetntities()
        {
            var tracked = new List<Entity> {
                new Entity{Name="ahmed"},
            };
            var persistent = new Mock<IPersistent<Entity>>();
            var tracker = new Tracker<Entity>(new List<Entity> { });
            tracker.TrackCollection(tracked);

            Assert.That(tracker.GetNewEntities().ToList(), Has.Count.EqualTo(1));
        }

    }
}
