using PSC_Cost_Control.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Models
{
    public partial class C_Cost_Project_Codes:IHireichy, IHasId
    {
        public string HCode { get => this.Code; set => Code = value; }
        public IHireichy HParent { get => this.C_Cost_Project_Codes2; set => C_Cost_Project_Codes2 = (C_Cost_Project_Codes)value; }
    }
}
