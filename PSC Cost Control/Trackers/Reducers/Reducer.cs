using PSC_Cost_Control.Helper;
using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Helper.TreeListHandler;
using System.Collections.Generic;
using System.Linq;

namespace PSC_Cost_Control.Trackers.Reducers
{
    /// <summary>
    /// Reduce a Collection of nodes to only  root nodes of the collection.
    /// It returns only the the highest level nodes (top parents)
    /// </summary>
    /// <typeparam name="T">Type of node</typeparam>
    public class Reducer<T> : IReducer<T> where T : IHireichy
    {
        private HashSet<string> _codes;
        /// <summary>
        /// return the root nodes of the passed collection
        /// </summary>
        /// <param name="nodes">the nodes needed to b reduced</param>
        /// <returns>collection with the root noodes</returns>
        public IEnumerable<T> Reduce(IEnumerable<T> nodes)
        {
            _codes = new HashSet<string>(nodes.Select(n => n.HCode).Distinct());

            foreach (var n in nodes)
                if (!_codes.Contains(n.ParentCode()))
                    yield return n;
        }
    }
}
