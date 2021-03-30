using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Repositories.Helpers.Enums;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories
{
    public class UnifiedCodeCategoriesRepo:BaseRepo<C_Cost_Unified_Code_Category>
    {
        protected override TablesEnum Table => TablesEnum._Cost_Unified_Code_Category;

        public UnifiedCodeCategoriesRepo(PSC_COST3Entities context) : base(context)
        {
        }

        public async Task<IEnumerable<C_Cost_Unified_Code_Category>> GetCategoriesAsync()
        {
            return await Context.C_Cost_Unified_Code_Category.ToListAsync();
        }
        public void  AddUnifiedCodeCategory(C_Cost_Project_Code_Categories category)
        {
            Context.f_Cost_Add_Unified_Codes_Category(category.Name);
        }
    }
}
