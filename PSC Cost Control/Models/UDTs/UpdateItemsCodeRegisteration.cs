using EntityFrameworkExtras.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Models.UDTs
{
    [UserDefinedTableType("_Cost_UpdateRegisiteration")]
    public class UpdateItemsCodeRegisteration
    {
        [UserDefinedTableTypeColumn(1)]

        public int Id { set; get; }
        [UserDefinedTableTypeColumn(2)]

        public int ProjectCodeId { set; get; }
        [UserDefinedTableTypeColumn(3)]

        public int ItemId { set; get; }
    }
}
