using PSC_Cost_Control.Models;
using PSC_Cost_Control.Repositories.PersistantReposotories.ItemsRegisterationRepositories;
using PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices;
using PSC_Cost_Control.Trackers.Commiters;

namespace PSC_Cost_Control.Services.ServicesBuilders.servicesFactories
{
    public class ProjectCodeItemRegisterationServiceBuilder:IBuild<IRegisterationService>
    {
        public IRegisterationService Build()
        {
            return new ItemsRegisterationService(
                new DirectItemRegisterationRepo()
                ,new IndirectCostItemRegisterationRepo()
                ,new Trackers.Tracker<C_Cost_Project_Codes_Items>()
                , new Trackers.Tracker<C_Cost_Indirect_Project_Code_Summerizing>());
        }
    }
}
