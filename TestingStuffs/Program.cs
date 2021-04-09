using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC_Cost_Control.Services;
using PSC_Cost_Control.Services.ServicesBuilders;
using PSC_Cost_Control.Services.ProjectCodesServices;

namespace TestingStuffs
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            //test project code service 
            var service = ServiceBuilder.Build<IProjectCodeService>();
            var l=(await service.GetProjectCodes(1)).ToList();

            //end of testing project code service 


        }
    }
}
