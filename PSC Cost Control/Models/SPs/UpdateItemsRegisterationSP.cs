using EntityFrameworkExtras.EF6;
using PSC_Cost_Control.Models.UDTs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Models.SPs
{

    /// <summary>
    /// A stored procedure class representation to register Items to a specific 
    /// projectCode.the Item can be Direct (BOQItem) or indirect (IndirectCostItem)
    /// </summary>
    [StoredProcedure("_Cost_UPdate_Items_Registeration")]
    public class UpdateItemsRegisterationSP
    {
        /// <summary>
        /// type="direct" for BOQitem .type="indirect" for IndorectCostItem.
        /// </summary>
        [StoredProcedureParameter(SqlDbType.NVarChar)]
        public string type { set; get; }

        [StoredProcedureParameter(SqlDbType.Udt)]
        public List<UpdateItemsCodeRegisteration> list { set; get; }

    }
}
