using PSC_Cost_Control.Helper;
using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Trackers.Commiters
{
    public class HireaichalUpdatingCommitter<T> : UpdatingCommiter<T> where T : IHireichy
    {
        private IDictionary<int,T> ALL;
        
        public HireaichalUpdatingCommitter(IPersistent<T> persistent, ITracker<T> tracker) : base(persistent, tracker)
        {
        }

        public override void Commit()
        {
            Persistent.DeleteCollection(Tracker.GetDeletedEntities());

            DamageParents();

            Persistent.AddCollection(ALL.Values);

            using(var context=new Models.ApplicationContext())
            {
            }


        }

        /// <summary>
        /// Set parentId to -1
        /// </summary>
        private void DamageParents()
        {
            var all =Tracker.GetNewEntities()
                .ForEach(t => t.ParentId = -1)
                .ToDictionary(t => t.HCode);
        }
    }
}
