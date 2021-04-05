﻿using PSC_Cost_Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Repositories.PersistantReposotories
{
    public abstract class HireachyRepo<T> : BaseRepo<T>
    {
        protected HireachyRepo(ApplicationContext context) : base(context)
        {
        }

        public void DeleteNode(int nodeId)
        {
            Context.f_COST_Delete_By_Id(Table.ToString(), nodeId);
        }
    }
}
