using PSC_Cost_Control.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Services.UnifiedCodesServices
{
    public interface IUnifiedCodeService
    {
        Task<IEnumerable<C_Cost_Unified_Codes>> GetUnifiedCodes();
        Task NewUnifiedCodes(List<C_Cost_Unified_Codes> codes);
        Task Update(List<C_Cost_Unified_Codes> codes);
    }
}