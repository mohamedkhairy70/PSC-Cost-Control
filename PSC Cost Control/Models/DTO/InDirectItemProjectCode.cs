using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Models.DTO
{
    public class InDirectItemProjectCode:IItemPair<IndirectCostItems>
    {
        public C_Cost_Project_Codes ProjectCode { set; get; }
        public IndirectCostItems Item { set; get; }
        public int ItemId { set; get; }
        public int ProjecCodeId { set; get; }
    }
}
