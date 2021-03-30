using EntityFrameworkExtras.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Models.UDFs
{
    [UserDefinedTableType("_Cost_Project_Codes_List")]
    public class ProjectCodeUdT
    {
       
        [UserDefinedTableTypeColumn(1)]
        public string Description { set; get; }

        [UserDefinedTableTypeColumn(2)]
        public int CategoryId { set; get; }

        [UserDefinedTableTypeColumn(3)]
        public int UnifiedCodeId { set; get; }

        [UserDefinedTableTypeColumn(4)]
        public int parent { set; get; }

        /// <summary>
        /// string represention for  SQL HireachyId Type
        /// </summary>
        [UserDefinedTableTypeColumn(5)]
        public string Code { set; get; }

        [UserDefinedTableTypeColumn(6)]
        public int ProjectId { set; get; } 
        
    }
}
