using PSC_Cost_Control.Models;


namespace PSC_Cost_Control.Repositories.PersistantReposotories
{
    public abstract class HireachyRepo<T> : BaseRepo<T>
    {
        protected HireachyRepo() 
        {
        }

        public void DeleteNode(int nodeId)
        {
            using (var Context = new ApplicationContext())
            {
                Context.f_COST_Delete_By_Id(Table.ToString(), nodeId);
            }
        }
    }
}
