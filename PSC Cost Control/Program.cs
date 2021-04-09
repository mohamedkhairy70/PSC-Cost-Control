using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC_Cost_Control.Repositories;
using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;
using PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories;
using PSC_Cost_Control.Models;
using ApplicationContext = PSC_Cost_Control.Models.ApplicationContext;
using PSC_Cost_Control.Models.UDFs;
using PSC_Cost_Control.Services.ServicesBuilders;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.UnifiedCodesServices;

namespace PSC_Cost_Control
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            await Test();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Cost_Main());

            /**adding autoMapper*/
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<C_Cost_Project_Codes, ProjectCodeUdT>()
                    .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id));
            });
            /**End of adding AutoMapper*/


            /**Dependency Injection Resolving*/
            var builder = new ContainerBuilder();
            //start Registeration of services
            builder.RegisterType<ApplicationContext>();
            builder.RegisterType<Mapper>().As<IMapper>();
            builder.RegisterType<ProjectCodesRepo>().As<IProjectCodesRepo>();
            builder.RegisterType<UnifedCodeRepo>().As<IUnifedCodeRepo>();
            builder.RegisterType<ProjectCodesRepo>().As<IProjectCodesRepo>();
            builder.RegisterType<ProjectCodesCategoriesRepo>().As<IProjectCodesCategoriesRepo>();
            builder.RegisterType<UnifiedCodeCategoriesRepo>().As<IUnifiedCodeCategoriesRepo>();
            //end of registeration of service 

            //     var container = builder.Build();

        }


        static async Task Test()
        {/**
            var service = ServiceBuilder.Build<IProjectCodeService>();
             var l = (await service.GetProjectCodes(1)).ToList();
            var code1 =
                new C_Cost_Project_Codes
                {
                    Code = "/2555/",
                    Category_Id = 2,
                    Unified_Code_Id = 1,
                    Description = "em",
                    HParent=null,
                };
            var code2 =
                new C_Cost_Project_Codes
                {
                    Code = "/2555/545/",
                    Category_Id = 2,
                    Unified_Code_Id = 1,
                    Description = "em",
                    HParent = code1,
                };
            service.NewCodesForProject(1, new List<C_Cost_Project_Codes>
            {
                code1,code2
            });
            **/
            var service = ServiceBuilder.Build<IUnifiedCodeService>();
            /**   var code1 = new C_Cost_Unified_Codes
               {
                   Title="q1",
                   Code="/8/",
                   Parent=null,
                   Category_Id=1
               };
               var code2 = new C_Cost_Unified_Codes
               {
                   Title = "q2",
                   Code = "/8/1/",
                   C_Cost_Unified_Codes2=code1,
                   Category_Id = 1
               };
               service.NewUnifiedCodes(new List<C_Cost_Unified_Codes> {code1,code2});
            **/
            var l = await service.GetUnifiedCodes();



        }

    }
}
