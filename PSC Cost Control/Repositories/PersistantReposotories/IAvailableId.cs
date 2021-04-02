using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories
{
    public interface IAvailableId
    {
         int NextId { set; get; }
    }
}
