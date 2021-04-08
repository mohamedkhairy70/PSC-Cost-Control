using EntityFrameworkExtras.EF6;
using PSC_Cost_Control.Models.UDFs;
using System.Collections.Generic;
using System.Data;

namespace PSC_Cost_Control.Models.SPs
{
    [StoredProcedure("_Cost_Update_Project_Codes")]
    public class UpdateProjectCodesSP
    {
        [StoredProcedureParameter(SqlDbType.Udt)]
        public List<ProjectCodeUdT> list { set; get; }
    }
}
