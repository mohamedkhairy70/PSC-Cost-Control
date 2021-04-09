using EntityFrameworkExtras.EF6;
using PSC_Cost_Control.Models.UDFs;
using System.Collections.Generic;
using System.Data;

namespace PSC_Cost_Control.Models.SPs
{
    [StoredProcedure("_Cost_Update_Unified_Codes")]
    public class UpdateUnifiedCodeSP
    {
        [StoredProcedureParameter(SqlDbType.Udt)]
        public List<UnifiedCodeUDT> list { set; get; }
    }
}
