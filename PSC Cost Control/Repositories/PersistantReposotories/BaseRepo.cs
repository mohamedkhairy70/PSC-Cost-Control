using PSC_Cost_Control.Models;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories
{
    public abstract class BaseRepo<T>
    {
        protected readonly PSC_COST3Entities Context;
        protected BaseRepo(PSC_COST3Entities context)
        {
            Context = context;
        }
        public async Task<T> FindByIdAsync(int id)
        {
            return (T)await Context.Set(typeof(T)).FindAsync(id);
        }
    }
}
