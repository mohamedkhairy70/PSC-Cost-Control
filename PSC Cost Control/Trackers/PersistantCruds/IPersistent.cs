using PSC_Cost_Control.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Trackers.PersistantCruds
{
    /// <summary>
    /// Crud operation deligating for Trackers
    /// </summary>
    /// <typeparam name="T">type of tracked entity</typeparam>
    public interface IPersistent<T>
    {
        Task AddCollection(IEnumerable<T> entities);
        void UpdateCollction(IEnumerable<T> entities);
        void DeleteCollection(IEnumerable<T> entities);
    }
}
