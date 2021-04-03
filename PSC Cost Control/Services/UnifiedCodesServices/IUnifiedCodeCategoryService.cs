using PSC_Cost_Control.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Services.UnifiedCodesServices
{
    public interface IUnifiedCodeCategoryService
    {
        void Add(string name);
        Task<IEnumerable<C_Cost_Unified_Code_Category>> GetCategories();
    }
}