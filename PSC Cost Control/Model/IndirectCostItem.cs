//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PSC_Cost_Control.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class IndirectCostItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IndirectCostItem()
        {
            this.C_Cost_Indirect_Project_Code_Summerizing = new HashSet<C_Cost_Indirect_Project_Code_Summerizing>();
            this.IndirectCostItems1 = new HashSet<IndirectCostItem>();
        }
    
        public int Id { get; set; }
        public int BOQId { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public string Description { get; set; }
        public Nullable<int> ParentId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Cost_Indirect_Project_Code_Summerizing> C_Cost_Indirect_Project_Code_Summerizing { get; set; }
        public virtual BOQ BOQ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IndirectCostItem> IndirectCostItems1 { get; set; }
        public virtual IndirectCostItem IndirectCostItem1 { get; set; }
    }
}
