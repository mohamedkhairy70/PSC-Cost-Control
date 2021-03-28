using EntityFrameworkExtras.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Models.UDFs
{
    [UserDefinedTableType("_Cost_Unified_Codes_List")]
    public class UnifiedCodeUDT
    {
        [UserDefinedTableTypeColumn(1)]
        public string Title { set; get; }

        [UserDefinedTableTypeColumn(2)]
        public int CategoryId { set; get; }

        [UserDefinedTableTypeColumn(3)]
        public int parent { set; get; }
        /// <summary>
        /// Node is a string represention for SQL hirearchyId type
        /// </summary>
        [UserDefinedTableTypeColumn(4)]
        public string Node { set; get; }
    }
}
