using EntityFrameworkExtras.EF6;
using PSC_Cost_Control.Models.UDFs;
using System.Collections.Generic;
using System.Data;

namespace PSC_Cost_Control.Models.SPs
{
    [StoredProcedure("_Cost_SP_Insert_Project_Codes")]
    public class ProjectCodesInserion
    {
        [StoredProcedureParameter(SqlDbType.Udt)]
        public List<ProjectCodeUdT> list { set; get; }
    }
}
