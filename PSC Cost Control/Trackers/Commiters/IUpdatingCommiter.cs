﻿using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Trackers.Commiters
{
    public interface IUpdatingCommiter 
    {
         void Commit();
    }
}
