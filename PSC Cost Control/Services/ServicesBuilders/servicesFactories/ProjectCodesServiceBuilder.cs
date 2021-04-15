using System;
using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;
using PSC_Cost_Control.Services.ProjectCodesServices;
namespace PSC_Cost_Control.Services.ServicesBuilders.servicesFactories
{
    public class ProjectCodesServiceBuilder : IBuild<IProjectCodeService>
    {
        public IProjectCodeService Build() =>
            new ProjectCodeService
            (
                 new ProjectCodesRepo()
                ,new Trackers.Tracker<Models.C_Cost_Project_Codes>()
            );
    }
}
