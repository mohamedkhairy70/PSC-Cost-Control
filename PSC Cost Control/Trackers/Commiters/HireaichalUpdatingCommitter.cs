using PSC_Cost_Control.Helper;
using PSC_Cost_Control.Helper.FakeIDsGenerator;
using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Helper.TreeListHandler;
using PSC_Cost_Control.Trackers.PersistantCruds;
using PSC_Cost_Control.Trackers.Reducers;
using System.Collections.Generic;
using System.Linq;

namespace PSC_Cost_Control.Trackers.Commiters
{
    public abstract class HireaichalUpdatingCommitter<T> : IUpdatingCommiter where T : IHireichy
    {
        protected IReducer<T> _reducer;
        protected IDictionary<string, T> _allMap;
        private int _influencedCount;
        protected IPersistent<T> _persistent;
        protected ITracker<T> _tracker;


        protected HireaichalUpdatingCommitter(IPersistent<T> persistent, ITracker<T> tracker)
        {
            _reducer = new Reducer<T>();
            _persistent = persistent;
            _tracker = tracker;
        }

        public abstract IDictionary<string, int> GetDamaged();

        public async void Commit()
        {
            _persistent.DeleteCollection(_reducer.Reduce(_tracker.GetDeletedEntities()));

            SetMap();

            SetInFluencedCount();

            _tracker.GetNewEntities().InjectFakeIds();//fake Ids 

            await _persistent.AddCollection(_tracker.GetNewEntities());

            _persistent.UpdateCollection(_tracker.GetUpdatedEntities());

            InjectRealIds();

            SolveHireachy();

            _persistent.UpdateCollection(_allMap.Values.Take(_influencedCount).ToList());
        }

        private void SetMap()
        {
            _allMap = _tracker
                .GetNewEntities()
                .Concat(_tracker.GetUpdatedEntities())
                .Concat(_tracker.GetUnChangedEntities())
                .ToDictionary(t => t.HCode);
        }

        private void SetInFluencedCount()
        {
            _influencedCount = _tracker.GetNewEntities().Count() + _tracker.GetUpdatedEntities().Count();
        }


        private void InjectRealIds()
        {
            var damaged = GetDamaged();
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
