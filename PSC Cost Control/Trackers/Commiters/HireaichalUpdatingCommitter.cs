using PSC_Cost_Control.Helper;
using PSC_Cost_Control.Helper.FakeIDsGenerator;
using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System.Collections.Generic;
using System.Linq;

namespace PSC_Cost_Control.Trackers.Commiters
{
    public class HireaichalUpdatingCommitter<T> : UpdatingCommiter<T> where T : IHireichy
    {
        private IDictionary<string,T> ALLMap;

        private IEnumerable<T> All;
        private IDictionary<string,string> Hireaical;
        
        public HireaichalUpdatingCommitter(IPersistent<T> persistent, ITracker<T> tracker) : base(persistent, tracker)
        {

        }

        public override void Commit()
        {
            Persistent.DeleteCollection(Tracker.GetDeletedEntities());

            SnapShotHireacal();

            SetAllAndMap();

            Tracker.GetNewEntities().InjectIds();

            Persistent.AddCollection(Tracker.GetNewEntities());

            InjectRealIds();

            SolveHireachy();

            Persistent.UpdateCollection(All);
        }


        private void SnapShotHireacal()
        {
              Hireaical = All
                .Select(c => new { Code = c.HCode, ParentCode = c.HParent.HCode })
                .ToDictionary(c => c.Code, c => c.ParentCode);
        }
       
        private void SetAllAndMap()
        {
            All = Tracker.GetNewEntities();

            ALLMap= All.ToDictionary(t => t.HCode);
        }

        private void InjectRealIds()
        {
            var damaged=(Persistent as IHirechicalPersistent<T>).GetDamagedHiraichals();
            ALLMap.ForEach(a => a.Value.Id = damaged[a.Key]);
        }

        private void SolveHireachy()
        {
            ALLMap.ForEach(c => c.Value.ParentId = ALLMap[c.Value.HCode].Id);
        }
    }
}
