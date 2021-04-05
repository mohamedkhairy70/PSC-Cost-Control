using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Factories.PersistantCruds
{
    public interface IPersistent<T>
    {
        Task AddCollection(IEnumerable<T> entities);
        void UpdateCollction(IEnumerable<T> entities);
        void DeleteCollection(IEnumerable<T> entities);

    }
}
