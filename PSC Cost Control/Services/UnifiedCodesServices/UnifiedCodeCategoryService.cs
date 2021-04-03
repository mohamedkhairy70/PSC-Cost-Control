using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC_Cost_Control.Repositories;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories;

namespace PSC_Cost_Control.Services.UnifiedCodesServices
{
    public class UnifiedCodeCategoryService : IUnifiedCodeCategoryService
    {
        private IUnifiedCodeCategoriesRepo _repo;

        public UnifiedCodeCategoryService(IUnifiedCodeCategoriesRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<C_Cost_Unified_Code_Category>> GetCategories()
        {
            return await _repo.GetCategoriesAsync();
        }

        public void Add(string name)
        {
            _repo.AddUnifiedCodeCategory(new C_Cost_Unified_Code_Category { Name = name });
        }
    }
}
