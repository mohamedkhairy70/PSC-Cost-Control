using PSC_Cost_Control.Helper.Interfaces;
using System.Collections.Generic;

namespace PSC_Cost_Control.Trackers.Reducers
{
    public interface IReducer<T> where T : IHireichy
    {
        IEnumerable<T> Reduce(IEnumerable<T> nodes);
    }
}