using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Repositories.Helpers.Enums;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories
{
    public class UnifiedCodeCategoriesRepo : HireachyRepo<C_Cost_Unified_Code_Category>, IUnifiedCodeCategoriesRepo
    {
        protected override TablesEnum Table => TablesEnum.C_Cost_Unified_Code_Category;

        public UnifiedCodeCategoriesRepo() 
        {
        }

        public async Task<IEnumerable<C_Cost_Unified_Code_Category>> GetCategoriesAsync()
        {
            using (var Context = new ApplicationContext())
            {
                return await Context.C_Cost_Unified_Code_Category.ToListAsync();
            }
        }
        public void AddUnifiedCodeCategory(C_Cost_Unified_Code_Category category)
        {
            using (var Context = new ApplicationContext())
            {
                Context.f_Cost_Add_Unified_Codes_Category(category.Name);
            }
        }



    }
}
