﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC_Cost_Control.Models;

namespace PSC_Cost_Control.Repositories.PersistantReposotories.ProjectCodesRepositories
{
    public class ProjectCodesCategoriesRepo : BaseRepo<C_Cost_Project_Code_Categories>
    {
        public ProjectCodesCategoriesRepo(PSC_COST3Entities context) : base(context)
        {
        }

        public async Task<IEnumerable<C_Cost_Project_Code_Categories>> GetCategoriesAsync()
        {
            return await Context.C_Cost_Project_Code_Categories.ToListAsync();
        }
    }
}
