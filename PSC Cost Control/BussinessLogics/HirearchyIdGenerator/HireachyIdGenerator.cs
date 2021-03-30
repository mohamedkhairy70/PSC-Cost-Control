using PSC_Cost_Control.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.BussinessLogics.HirearchyIdGenerator
{
    public class HireachyIdGenerator<T> where T:HasCode
    {
        public HireachyIdGenerator() { }
        public string Generate(T parent,T lastNeighbour)
        {
            if (parent == null) return "/";
            var lN =lastNeighbour==null?new string[] { "0"}:lastNeighbour.HCode.Split('/');
            var lDigit = UInt16.Parse(lN.Last())+1;
            return $"{parent.HCode}/{lDigit}/";
        }
    }
}
