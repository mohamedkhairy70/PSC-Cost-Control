using PSC_Cost_Control.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories
{
    public interface IUnifiedCodeCategoriesRepo
    {
        void AddUnifiedCodeCategory(C_Cost_Unified_Code_Category category);
        Task<IEnumerable<C_Cost_Unified_Code_Category>> GetCategoriesAsync();
    }
}