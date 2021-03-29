using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            });
            /**End of adding AutoMapper*/


            /**Dependency Injection Resolving*/
            var builder = new ContainerBuilder();
            //start Registeration of services
            builder.RegisterType<Mapper>().As<IMapper>();

            //end of registeration of service 
          
            var container = builder.Build();
            
        }
    }
}
