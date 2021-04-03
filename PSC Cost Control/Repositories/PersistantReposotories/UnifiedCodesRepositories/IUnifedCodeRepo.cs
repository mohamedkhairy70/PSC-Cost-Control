using PSC_Cost_Control.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories
{
    public interface IUnifedCodeRepo
    {
        int NextId { get; set; }

        Task Add(IEnumerable<C_Cost_Unified_Codes> entities);
        Task AddUnifiedCodesAsync(List<C_Cost_Unified_Codes> codes);
        void Delete(C_Cost_Unified_Codes unified);
        void Delete(IEnumerable<C_Cost_Unified_Codes> entities);
        Task<IEnumerable<C_Cost_Unified_Codes>> GetUnifiedCodesAsync();
        void Update(C_Cost_Unified_Codes code);
        void Update(IEnumerable<C_Cost_Unified_Codes> entities);
    }
}