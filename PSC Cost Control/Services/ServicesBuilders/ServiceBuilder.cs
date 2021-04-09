using PSC_Cost_Control.Services.ServicesBuilders.servicesFactories;
using System;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.UnifiedCodesServices;
using PSC_Cost_Control.Services.ProjectCodeItemRegisterationServices;

namespace PSC_Cost_Control.Services.ServicesBuilders
{
    public static class ServiceBuilder
    {
        public static T Build<T>()=>GetBuilder<T>().Build();

        private  static IBuild<T> GetBuilder<T>()
        {
            var t = typeof(T);

            if (!t.IsInterface)
                throw new NotSupportedException("T must be an interface type!");

            return t.Equals(typeof(IProjectCodeService)) ?
                 (IBuild<T>)new ProjectCodesServiceBuilder()
                :
                t.Equals(typeof(IProjectCodeCategoryService)) ?
                 (IBuild<T>)new ProjectCodesCategoryServiceBuilder()
                :
                t.Equals(typeof(IUnifiedCodeService)) ?
                 (IBuild<T>)new UnifiedCodeServiceBuilder()
                :
                t.Equals(typeof(IRegisterationService))?
                (IBuild<T>)new ProjectCodeItemRegisterationServiceBuilder()
                :
                (IBuild<T>)new UnifiedCodesCategoryServiceBuilder();

        }
    }
}
