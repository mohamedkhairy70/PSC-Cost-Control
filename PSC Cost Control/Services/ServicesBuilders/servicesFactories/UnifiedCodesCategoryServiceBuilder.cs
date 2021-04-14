using PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories;
using PSC_Cost_Control.Services.UnifiedCodesServices;

namespace PSC_Cost_Control.Services.ServicesBuilders.servicesFactories
{
    public class UnifiedCodesCategoryServiceBuilder : IBuild<IUnifiedCodeCategoryService>
    {
        public IUnifiedCodeCategoryService Build() =>
                        new UnifiedCodeCategoryService(new UnifiedCodeCategoriesRepo());
    }
}

