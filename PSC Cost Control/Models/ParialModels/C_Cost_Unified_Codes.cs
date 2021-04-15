using PSC_Cost_Control.Helper.Interfaces;


namespace PSC_Cost_Control.Models
{
    public partial class C_Cost_Unified_Codes : IHireichy, IHasId
    {
        public string HCode { get => Code; set => Code = value; }
        public IHireichy HParent { get => this.C_Cost_Unified_Codes2; set => C_Cost_Unified_Codes2= (C_Cost_Unified_Codes)value; }
        public int? ParentId { get => Parent; set =>Parent=value; }


        public override bool Equals(object obj)
        {
            if (!(obj is C_Cost_Unified_Codes o))
                return false;

            return o.Title.Equals(Title)
                &&
                o.Parent.Equals(Parent)
                &&
                o.Id == Id
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
