﻿using Autofac;
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

namespace PSC_Cost_Control
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
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
    }
}
