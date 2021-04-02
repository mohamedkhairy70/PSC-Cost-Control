using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Helper.Interfaces
{
    public interface IHireichy
    {
        string HCode { set; get; }
        IHireichy HParent { set; get; }
    }
}
