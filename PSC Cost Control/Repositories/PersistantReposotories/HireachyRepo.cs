using PSC_Cost_Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories
{
    public abstract class HireachyRepo<T> : BaseRepo<T>
    {
        protected HireachyRepo(PSC_COST3Entities context) : base(context)
        {
        }

        public void DeleteNode(int nodeId)
        {
            Context.Delete_parent_With_HisChilds(Table.ToString(), nodeId);
        }
    }
}
