using PSC_Cost_Control.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Services.DependencyApis
{
    public partial class ExternalAPIs
    {
      
        public async Task<IEnumerable<Projects>> GetProjectsAsync()
        {
            using (var Context = new ApplicationContext())
            {
                return await Context.Projects.AsNoTracking().ToListAsync();
            }
        }

        public async Task<IEnumerable<Projects>> SearchProjectsBYName(string name)
        {
            using (var Context = new ApplicationContext())
            {
                return await Context.Projects
                                    .Where(
                                    p => DbFunctions.Like(p.Name, $"{name}%")
                                    ||
                                    DbFunctions.Like(p.Name, $"%{name}")
                                    ||
                                    p.Name.Contains(name)
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<BOQs>> GetBOQsAsync(int contractId)
        {
            using (var Context = new ApplicationContext())
            {

                return await Context.BOQs.Where(b => b.ContractId == contractId).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IEnumerable<BOQ_Items>> GetBOQ_ItemsAsync(int BOQId)
        {
            using (var Context = new ApplicationContext())
            {

                return await Context.BOQ_Items.Where(i => i.BOQId == BOQId).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IEnumerable<IndirectCostItems>> GetIndirectItems(int BOQId)
        {
            using (var Context = new ApplicationContext())
            {
                return await Context.IndirectCostItems.Where(i => i.BOQId == BOQId).AsNoTracking().ToListAsync();
            }
        }

    }
}
