using PSC_Cost_Control.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Trackers.PersistantCruds
{
    public interface IHirechicalPersistent<T>:IPersistent<T> where T:IHireichy
    {
        /// <summary>
        /// Get entities has parent value =null ,so they need to be fixed or remain the same if the object is head parent(at level 0 in Tree)
        /// </summary>
        /// <returns>dictionary of key Is Code,value is Id</returns>
        IDictionary<string, int> GetDamagedHiraichals(int? projectId=null);
    }
}
