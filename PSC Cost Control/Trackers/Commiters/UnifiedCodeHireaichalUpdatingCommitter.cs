using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System.Collections.Generic;

namespace PSC_Cost_Control.Trackers.Commiters
{
    class UnifiedCodeHireaichalUpdatingCommitter : HireaichalUpdatingCommitter<C_Cost_Unified_Codes>
    {
        public UnifiedCodeHireaichalUpdatingCommitter(IPersistent<C_Cost_Unified_Codes> persistent, ITracker<C_Cost_Unified_Codes> tracker) : base(persistent, tracker)
        {
        }

        public override IDictionary<string, int> GetDamaged()
        {
            return (_persistent as IHirechicalPersistent<C_Cost_Unified_Codes>).GetDamagedHiraichals();
        }
    }
}
