using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Models.DTO
{
    public interface IItemPairWithId<T>:IItemPair<T>
    {
        int Id { set; get; }
    }
}
