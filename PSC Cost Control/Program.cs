using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories;
using PSC_Cost_Control.Repositories.PersistantReposotories.UnifiedCodesRepositories;
using PSC_Cost_Control.Models;
using ApplicationContext = PSC_Cost_Control.Models.ApplicationContext;
using PSC_Cost_Control.Models.UDFs;
using PSC_Cost_Control.Services.ServicesBuilders;
using PSC_Cost_Control.Services.ProjectCodesServices;
using PSC_Cost_Control.Services.DependencyApis;

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
           // await Test();
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

            //Frm_UnifiedCode_Show
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
        {
            //         var service = ServiceBuilder.Build<IProjectCodeService>();
            //   var l = (await service.GetProjectCodes(1)).ToList();
            /**var code1 =
                new C_Cost_Project_Codes
                {
                    Code = "/2555/",
                    Category_Id = 2,
                    Unified_Code_Id = 1,
                    Description = "bug1",
                    HParent=null,
                };
            var code2 =
                new C_Cost_Project_Codes
                {
                    Code = "/2555/545/",
                    Category_Id = 2,
                    Unified_Code_Id = 1,
                    Description = "bug2",
                    HParent = code1,
                };
            var z=await service.NewCodesForProject(2, new List<C_Cost_Project_Codes>
            {
                code1,code2
            });
            **/

            //var service = ServiceBuilder.Build<IUnifiedCodeService>();
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
            //  var l = await service.GetUnifiedCodes();
            //  var exeternal = new PSC_Cost_Control.Services.DependencyApis.ExternalAPIs(new Models.ApplicationContext());
            //  var l =await  exeternal.GetProjectsAsync();
            // var service = ServiceBuilder.Build<IRegisterationService>();
            //     var list =( await service.GetBOQRegisteration(2)).ToList();
            //var list= (await service.GetIndirectItemRegisteration(1)).ToList();

            /**  var input = new List<C_Cost_Project_Codes_Items> {
                  new C_Cost_Project_Codes_Items
                  {
                      Id=63,
                      BOQ_Items = new BOQ_Items { Id = 1 },
                      C_Cost_Project_Codes = new C_Cost_Project_Codes { Id = 12 },
                  }};**/
            //
            //service.RegisterBOQItems(input);
            //    service.UpdateBOQItems(1, input);
            /**  var input = new List<C_Cost_Indirect_Project_Code_Summerizing>
              {
                  new C_Cost_Indirect_Project_Code_Summerizing
                  {
                      IndirectCostItems=new IndirectCostItems{Id=1},
                      C_Cost_Project_Codes=new C_Cost_Project_Codes{Id=12}
                  }
              };**/

            //   service.UpdateInDirectItems(1 ,input);
            /**var service= ServiceBuilder.Build<IProjectCodeService>();
               var code1 =
                  new C_Cost_Project_Codes
                  {//the same
                      Id=1,
                      Code = "/25565/",
                      Category_Id = 2,
                      Unified_Code_Id = 1,
                      Description = "bug1",
                      HParent = null,
                  };
               var code2=
                   new C_Cost_Project_Codes
                   {//update category
                       Id=2,
                       Code = "/25565/545/",
                       Category_Id = 3,
                       Unified_Code_Id = 1,
                       Description = "bug2",
                       HParent = code1,
                   };**/
            //await service.Update(2, new List<C_Cost_Project_Codes> { code1,code2});
            var service = new ExternalAPIs();
            var l = await service.GetBOQ_ItemsAsync(1);
        }

    }
}
