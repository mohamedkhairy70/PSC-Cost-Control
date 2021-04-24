using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.BL
{
    public class Unified_Code_by_Join
    {
        public int Id { get; set; }
        public string UnifiedCode_Code { get; set; }
        public string UnifiedCode_Title { get; set; }
        public string Category_Name { get; set; }
        public int? UnifiedCode_Parent { get; set; }
        public int CategoryId { get; set; }
    }
}
