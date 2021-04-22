using PSC_Cost_Control.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Models
{
    public partial class C_Cost_Project_Codes:IHireichy, IHasId
    {
        public string HCode { get => this.Code; set => Code = value; }
        public int? ParentId { get => Parent; set => Parent = value; }

        public IHireichy HParent { get => this.C_Cost_Project_Codes2; set => C_Cost_Project_Codes2 = (C_Cost_Project_Codes)value; }
        public override bool Equals(object obj)
        {
            var o = obj as C_Cost_Project_Codes;
                return o != null&&o.Description.Equals(Description)
                &&
                o.Parent.Equals(Parent)
                &&
                o.Id == Id
                &&
                o.Project_Id == Project_Id
                &&
                o.Unified_Code_Id == Unified_Code_Id
                &&
                o.Category_Id == Category_Id
                &&
                o.Code == Code;
        }
        public override int GetHashCode()
        {
            return Id + 297;
        }

    }
}
