using PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories;
using PSC_Cost_Control.Services.UnifiedCodesServices;


namespace PSC_Cost_Control.Services.ServicesBuilders.servicesFactories
{
    public class UnifiedCodeServiceBuilder : IBuild<IUnifiedCodeService>
    {
        public IUnifiedCodeService Build()=>
                        new UnifiedCodeService(new UnifedCodeRepo(new Models.ApplicationContext()));
    }
}
