using PSC_Cost_Control.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Services.DependencyApis
{
    public partial class ExternalAPIs
    {
        private PSC_COST3Entities Context;
        public ExternalAPIs(PSC_COST3Entities context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Projects>> GetProjectsAsync()
        {
            return await Context.Projects.ToListAsync();
        }

        public async Task<IEnumerable<Projects>> SearchProjectsBYName(string name)
        {
            return await Context.Projects
                .Where(
                p => DbFunctions.Like(p.Name, $"{name}%")
                ||
                DbFunctions.Like(p.Name, $"%{name}")
                ||
                p.Name.Contains(name)
                )
                .ToListAsync();
        }

        public async Task<IEnumerable<BOQs>>GetBOQsAsync(int contractId)
        {
            return await Context.BOQs.Where(b => b.ContractId == contractId).ToListAsync();
        }

        public async Task<IEnumerable<BOQ_Items>> GetBOQ_ItemsAsync(int BOQId)
        {
            return await Context.BOQ_Items.Where(i => i.BOQId == BOQId).ToListAsync();
        }


    }
}
