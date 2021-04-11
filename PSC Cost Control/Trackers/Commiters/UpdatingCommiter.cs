using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Trackers.Commiters
{
    public abstract class UpdatingCommiter<T> where T:IHasId
    {
        protected IPersistent<T> Persistent;
        protected ITracker<T> Tracker;
        protected UpdatingCommiter(IPersistent<T> persistent,ITracker<T> tracker)
        {
            Persistent = persistent;
            Tracker = tracker;
         
        }

        public  abstract void Commit();
    }
}
