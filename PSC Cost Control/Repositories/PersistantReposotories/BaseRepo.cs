using PSC_Cost_Control.Models;
using PSC_Cost_Control.Repositories.Helpers.Enums;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories
{
    public abstract class BaseRepo<T>
    {
        protected readonly ApplicationContext Context;
        protected BaseRepo(ApplicationContext context)
        {
            Context = context;
        }
        public async Task<T> FindByIdAsync(int id)
        {
            return (T)await Context.Set(typeof(T)).FindAsync(id);
        }

        protected abstract TablesEnum Table { get; }

        public virtual void Delete(int id)
        {
            Context.f_COST_Delete_By_Id(Table.ToString(), id);
        }
    }
}
