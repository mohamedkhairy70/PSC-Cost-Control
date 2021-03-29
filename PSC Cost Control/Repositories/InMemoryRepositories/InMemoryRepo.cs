

using System.Collections.Generic;

namespace PSC_Cost_Control.Repositories.InMemoryRepositories
{
    public abstract class InMemoryRepo<T,V> where T:class where V:class
    {
        private IList<T> Data;
        public InMemoryRepo()
        {
            Data = new List<T>();
        }

    /**    public T Add(T data)
        {
            return Data.Add(data);
        }
    **/

    }
}
