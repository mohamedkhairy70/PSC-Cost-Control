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
    
    public partial class C_Cost_Project_Codes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_Cost_Project_Codes()
        {
            this.C_Cost_Indirect_Project_Code_Summerizing = new HashSet<C_Cost_Indirect_Project_Code_Summerizing>();
            this.C_Cost_Project_Codes_Items = new HashSet<C_Cost_Project_Codes_Items>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> Unified_Code_Id { get; set; }
        public Nullable<int> Category_Id { get; set; }
        public Nullable<int> Project_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Cost_Indirect_Project_Code_Summerizing> C_Cost_Indirect_Project_Code_Summerizing { get; set; }
        public virtual C_Cost_Project_Code_Categories C_Cost_Project_Code_Categories { get; set; }
        public virtual C_Cost_Unified_Codes C_Cost_Unified_Codes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Cost_Project_Codes_Items> C_Cost_Project_Codes_Items { get; set; }
        public virtual Project Project { get; set; }
    }
}
