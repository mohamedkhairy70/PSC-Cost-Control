using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories
{
    public class UnifedCodeRepo : BaseRepo<C_Cost_Unified_Codes>
    {
        public UnifedCodeRepo(PSC_COST3Entities context) : base(context)
        {
        }

        public async Task<IEnumerable<C_Cost_Unified_Codes>> GetUnifiedCodesAsync()
        {
            return await Context.C_Cost_Unified_Codes.ToListAsync();
        }
    }
}
