using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;
using PSC_Cost_Control.Services.ProjectCodesServices;

namespace PSC_Cost_Control.Services.ServicesBuilders.servicesFactories
{
    public class ProjectCodesCategoryServiceBuilder : IBuild<IProjectCodeCategoryService>
    {
        public IProjectCodeCategoryService Build()=>
                        new ProjectCodeCategoryService(new ProjectCodesCategoriesRepo(new Models.ApplicationContext()));

    }
}
