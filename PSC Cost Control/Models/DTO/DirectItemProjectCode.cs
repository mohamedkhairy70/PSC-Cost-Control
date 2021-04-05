using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;

namespace PSC_Cost_Control.Models.DTO
{
    public class DirectItemProjectCode:IItemPair<BOQ_Items>
    {
        public C_Cost_Project_Codes ProjectCode { set; get; }
        public BOQ_Items Item { set; get; }
        public int ItemId { get ; set; }
        public int ProjecCodeId { get; set; }
    }
}
