using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Helper.Interfaces
{
    public interface IHireichy:IHasId
    {
        string HCode { set; get; }
        IHireichy HParent { set; get; }
        int? ParentId { set; get; }
    }
}
