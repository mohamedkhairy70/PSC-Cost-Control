using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Models.DTO
{
    public interface IItemPair<T>
    {
         T Item { set; get; }
         int ItemId { set; get; }
         C_Cost_Project_Codes ProjectCode { set; get; }
         int ProjecCodeId { set; get; }
    }
}
