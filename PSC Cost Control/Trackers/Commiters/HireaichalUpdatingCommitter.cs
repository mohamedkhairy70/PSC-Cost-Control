﻿using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Trackers.Commiters
{
    public class HireaichalUpdatingCommitter<T> : UpdatingCommiter<T> where T : IHasId
    {
        public HireaichalUpdatingCommitter(IPersistent<T> persistent, ITracker<T> tracker) : base(persistent, tracker)
        {
        }

        public override void Commit()
        {
            throw new NotImplementedException();
        }
    }
}