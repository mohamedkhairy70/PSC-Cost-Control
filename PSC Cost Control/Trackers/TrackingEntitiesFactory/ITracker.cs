using PSC_Cost_Control.Helper.Interfaces;
using System.Collections.Generic;

namespace PSC_Cost_Control.Trackers
{
    /// <summary>
    /// it tracks a collection of data to specifiy which entities are new so that it will be inserted 
    /// ,which are updated and which was existed but deleted
    /// </summary>
    /// <typeparam name="T">the tracked entity type.the type must be override the Equal method</typeparam>
    public interface ITracker<T> where T : IHasId
    {
        /// <summary>
        /// distrubute entities to Delation,insertion,Updating repositories to be steady for commiting.
        /// </summary>
        /// <param name="entities">the entities that will be tracked</param>
        void TrackCollection(IEnumerable<T> entities);
        /// <summary>
        /// Get entities categorized as new entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetNewEntities();
        /// <summary>
        /// Get entities categorized as Updated entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetUpdatedEntities();
        /// <summary>
        /// Get entities categorized as Deleted entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetDeletedEntities();
        /// <summary>
        /// Get entities had Not changed from the One In Origin
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetUnChangedEntities();
    }
}