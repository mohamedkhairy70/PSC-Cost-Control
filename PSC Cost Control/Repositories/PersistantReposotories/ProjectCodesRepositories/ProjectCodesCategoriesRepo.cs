using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;
using PSC_Cost_Control.Repositories.Helpers.Enums;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories
{
    public class ProjectCodesCategoriesRepo : BaseRepo<C_Cost_Project_Code_Categories>, IProjectCodesCategoriesRepo
    {
        protected override TablesEnum Table { get => TablesEnum.C_Cost_Project_Code_Categories; }

        public ProjectCodesCategoriesRepo() 
        {
        }

        public async Task<IEnumerable<C_Cost_Project_Code_Categories>> GetCategoriesAsync()
        {
            using (var Context = new ApplicationContext())
            {
                return await Context.C_Cost_Project_Code_Categories.ToListAsync();
            }
        }
        public void AddProjectCodeCategory(C_Cost_Project_Code_Categories category)
        {
            using (var Context = new ApplicationContext())
            {
                Context.f_Cost_Add_Project_Codes_Category(category.Name);
            }
        }

    }
}
