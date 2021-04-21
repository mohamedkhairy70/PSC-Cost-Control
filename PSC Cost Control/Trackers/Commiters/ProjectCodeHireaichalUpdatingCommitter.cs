using PSC_Cost_Control.Models;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System.Collections.Generic;
using System.Linq;


namespace PSC_Cost_Control.Trackers.Commiters
{

    public class ProjectCodeHireaichalUpdatingCommitter : HireaichalUpdatingCommitter<C_Cost_Project_Codes>
    {
        public ProjectCodeHireaichalUpdatingCommitter
            (
             IPersistent<C_Cost_Project_Codes> persistent
            , ITracker<C_Cost_Project_Codes> tracker
            ) : base(persistent, tracker)
        {
        }

        public override IDictionary<string, int> GetDamaged()
        {
            return (_persistent as IHirechicalPersistent<C_Cost_Project_Codes>).GetDamagedHiraichals(_allMap.Values.FirstOrDefault().Project_Id);
        }
    }
}
