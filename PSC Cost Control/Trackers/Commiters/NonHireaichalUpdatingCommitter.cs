using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Trackers.Commiters
{
    public class NonHireaichalUpdatingCommitter<T> : IUpdatingCommiter where T : IHasId
    {
        private IPersistent<T> _persistent;
        private ITracker<T> _tracker;
        public NonHireaichalUpdatingCommitter(IPersistent<T> persistent, ITracker<T> tracker)
        {
            _persistent = persistent;
            _tracker = tracker;

        }

        public void Commit()
        {
            _persistent.DeleteCollection(_tracker.GetDeletedEntities());
            _persistent.AddCollection(_tracker.GetNewEntities());
            _persistent.UpdateCollection(_tracker.GetUpdatedEntities());
        }

    }
}
