//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PSC_Cost_Control.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class C_Cost_Unified_Code_Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_Cost_Unified_Code_Category()
        {
            this.C_Cost_Unified_Codes = new HashSet<C_Cost_Unified_Codes>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Cost_Unified_Codes> C_Cost_Unified_Codes { get; set; }
    }
}