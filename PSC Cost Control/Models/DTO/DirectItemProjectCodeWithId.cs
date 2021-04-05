using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Models.DTO
{
    public class DirectItemProjectCodeWithId : IItemPairWithId<BOQ_Items>
    {
        public int Id { get; set; }
        public BOQ_Items Item { get; set; }
        public int ItemId { get; set; }
        public C_Cost_Project_Codes ProjectCode { get; set; }
        public int ProjecCodeId { set; get; }
    }
}
