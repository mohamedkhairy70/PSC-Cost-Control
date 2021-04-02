using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Factories.PersistantCruds
{
    public interface IPersistent<T>
    {
        Task Add(IEnumerable<T> entities);
        void Update(IEnumerable<T> entities);
        void Delete(IEnumerable<T> entities);

    }
}
