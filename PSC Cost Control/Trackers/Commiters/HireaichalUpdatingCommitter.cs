using PSC_Cost_Control.Helper;
using PSC_Cost_Control.Helper.FakeIDsGenerator;
using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Helper.TreeListHandler;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System.Collections.Generic;
using System.Linq;

namespace PSC_Cost_Control.Trackers.Commiters
{
    public class HireaichalUpdatingCommitter<T> : UpdatingCommiter<T> where T : IHireichy
    {
        private IDictionary<string, T> _allMap;
        private IEnumerable<T> _all;
        private int _influencedCount;
        public HireaichalUpdatingCommitter(IPersistent<T> persistent, ITracker<T> tracker) : base(persistent, tracker)
        {
            var add = tracker.GetNewEntities().Count();
            var updated = tracker.GetUpdatedEntities().Count();
        }

        public async override void Commit()
        {
            Persistent.DeleteCollection(Tracker.GetDeletedEntities());

            SetAllAndMap();

            SetInFluencedCount();

            Tracker.GetNewEntities().InjectFakeIds();//fake Ids 

            await Persistent.AddCollection(Tracker.GetNewEntities());

            InjectRealIds();

            SolveHireachy();

            Persistent.UpdateCollection(_all.Take(_influencedCount).ToList());
        }

        private void SetAllAndMap()
        {
            _all = Tracker
                .GetNewEntities()
                .Concat(Tracker.GetUpdatedEntities())
                .Concat(Tracker.GetUnChangedEntities());
            _allMap = _all.ToDictionary(t => t.HCode);
        }

        private void SetInFluencedCount()
        {
            _influencedCount = Tracker.GetNewEntities().Count() + Tracker.GetUpdatedEntities().Count();
        }


        private void InjectRealIds()
        {
            var damaged = (Persistent as IHirechicalPersistent<T>).GetDamagedHiraichals();
            damaged.ForEach(d => _allMap[d.Key].Id = d.Value);
        }

        private void SolveHireachy()
        {
            _allMap.ForEach(c =>
            {
                var parentCode = c.Value.ParentCode();
                c.Value.ParentId = parentCode.Equals("/") ? (int?)null : _allMap[parentCode].Id;
            });
        }
    }
}
