using PSC_Cost_Control.Repositories.PersistantReposotories.ItemsRegisterationRepositories;
using PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices;

namespace PSC_Cost_Control.Services.ServicesBuilders.servicesFactories
{
    public class ProjectCodeItemRegisterationServiceBuilder:IBuild<IRegisterationService>
    {
        public IRegisterationService Build()
        {
            return new ItemsRegisterationService(new DirectItemRegisterationRepo(),new IndirectCostItemRegisterationRepo());
        }
    }
}
