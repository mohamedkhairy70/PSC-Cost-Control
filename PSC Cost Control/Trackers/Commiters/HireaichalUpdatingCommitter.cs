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
            Hireaical = new Dictionary<string, string>();
        }

        public async override void Commit()
        {
            Persistent.DeleteCollection(Tracker.GetDeletedEntities());

            SetAllAndMap();

            SnapShotHireacalParent_Child();

            Tracker.GetNewEntities().InjectIds();//fake Ids 

            await Persistent.AddCollection(Tracker.GetNewEntities());

            InjectRealIds();

            SolveHireachy();

            Persistent.UpdateCollection(All);
        }
        private void SnapShotHireacalParent_Child()
        {
              Hireaical = All
                .Select(c => new { Code = c.HCode, ParentCode = c.HParent?.HCode })
                .ToDictionary(c => c.Code, c => c.ParentCode);
        }
       
        private void SetAllAndMap()
        {
            All = Tracker
                .GetNewEntities()
                .Concat(Tracker.GetUpdatedEntities())
                .Concat(Tracker.GetUnChangedEntities());

            ALLMap= All.ToDictionary(t => t.HCode);
        }

        private void InjectRealIds()
        {
            var damaged=(Persistent as IHirechicalPersistent<T>).GetDamagedHiraichals();
            damaged.ForEach(d => ALLMap[d.Key].Id = d.Value);
        }

        private void SolveHireachy()
        {
             ALLMap.ForEach
                (c => c.Value.ParentId = Hireaical[c.Value.HCode] is null?null: ALLMap[Hireaical[c.Value?.HCode]]?.Id);
        }
    }
}
