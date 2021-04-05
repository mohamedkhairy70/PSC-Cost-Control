﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PSC_COST3Entities : DbContext
    {
        public PSC_COST3Entities()
            : base("name=PSC_COST3Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BOQ_Items> BOQ_Items { get; set; }
        public virtual DbSet<BOQs> BOQs { get; set; }
        public virtual DbSet<BreakdownItemType> BreakdownItemType { get; set; }
        public virtual DbSet<C_Cost_Direct_Project_Codes_Summerizng> C_Cost_Direct_Project_Codes_Summerizng { get; set; }
        public virtual DbSet<C_Cost_Indirect_Project_Code_Summerizing> C_Cost_Indirect_Project_Code_Summerizing { get; set; }
        public virtual DbSet<C_Cost_Project_Code_Categories> C_Cost_Project_Code_Categories { get; set; }
        public virtual DbSet<C_Cost_Project_Codes> C_Cost_Project_Codes { get; set; }
        public virtual DbSet<C_Cost_Project_Codes_Items> C_Cost_Project_Codes_Items { get; set; }
        public virtual DbSet<C_Cost_Unified_Code_Category> C_Cost_Unified_Code_Category { get; set; }
        public virtual DbSet<C_Cost_Unified_Codes> C_Cost_Unified_Codes { get; set; }
        public virtual DbSet<IndirectCostItems> IndirectCostItems { get; set; }
        public virtual DbSet<Item_Breakdowns> Item_Breakdowns { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Units> Units { get; set; }
    
        public virtual int f_Cost_SP_Insert_Project_Codes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("f_Cost_SP_Insert_Project_Codes");
        }
    
        public virtual int f_Cost_SP_Insert_Unified_Codes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("f_Cost_SP_Insert_Unified_Codes");
        }
    
        public virtual int f_Cost_Add_Project_Codes_Category(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("f_Cost_Add_Project_Codes_Category", nameParameter);
        }
    
        public virtual int f_Cost_Add_Unified_Codes_Category(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("f_Cost_Add_Unified_Codes_Category", nameParameter);
        }
    
        public virtual int f_COST_Delete_By_Id(string table, Nullable<int> id)
        {
            var tableParameter = table != null ?
                new ObjectParameter("table", table) :
                new ObjectParameter("table", typeof(string));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("f_COST_Delete_By_Id", tableParameter, idParameter);
        }
    
        public virtual int f_COST_Update_Project_Code(Nullable<int> forId, string description, Nullable<int> unifiedCode_Id, Nullable<int> categoryId, string code, Nullable<int> parent)
        {
            var forIdParameter = forId.HasValue ?
                new ObjectParameter("forId", forId) :
                new ObjectParameter("forId", typeof(int));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var unifiedCode_IdParameter = unifiedCode_Id.HasValue ?
                new ObjectParameter("unifiedCode_Id", unifiedCode_Id) :
                new ObjectParameter("unifiedCode_Id", typeof(int));
    
            var categoryIdParameter = categoryId.HasValue ?
                new ObjectParameter("CategoryId", categoryId) :
                new ObjectParameter("CategoryId", typeof(int));
    
            var codeParameter = code != null ?
                new ObjectParameter("code", code) :
                new ObjectParameter("code", typeof(string));
    
            var parentParameter = parent.HasValue ?
                new ObjectParameter("parent", parent) :
                new ObjectParameter("parent", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("f_COST_Update_Project_Code", forIdParameter, descriptionParameter, unifiedCode_IdParameter, categoryIdParameter, codeParameter, parentParameter);
        }
    
        public virtual int f_COST_Update_Project_Codes_Hireachy()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("f_COST_Update_Project_Codes_Hireachy");
        }
    
        public virtual int Delete_parent_With_HisChilds(string tableName, Nullable<int> deletedId)
        {
            var tableNameParameter = tableName != null ?
                new ObjectParameter("tableName", tableName) :
                new ObjectParameter("tableName", typeof(string));
    
            var deletedIdParameter = deletedId.HasValue ?
                new ObjectParameter("deletedId", deletedId) :
                new ObjectParameter("deletedId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Delete_parent_With_HisChilds", tableNameParameter, deletedIdParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int Clear_Project_Codes(Nullable<int> forProjectId)
        {
            var forProjectIdParameter = forProjectId.HasValue ?
                new ObjectParameter("forProjectId", forProjectId) :
                new ObjectParameter("forProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Clear_Project_Codes", forProjectIdParameter);
        }
    
        public virtual int f_Cost_SP_Insert_Direct_Project_Codes_Summerizng()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("f_Cost_SP_Insert_Direct_Project_Codes_Summerizng");
        }
    
        public virtual int f_COST_Update_Unified_Code(Nullable<int> forId, string title, Nullable<int> categoryId, string code, Nullable<int> parent)
        {
            var forIdParameter = forId.HasValue ?
                new ObjectParameter("forId", forId) :
                new ObjectParameter("forId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var categoryIdParameter = categoryId.HasValue ?
                new ObjectParameter("CategoryId", categoryId) :
                new ObjectParameter("CategoryId", typeof(int));
    
            var codeParameter = code != null ?
                new ObjectParameter("code", code) :
                new ObjectParameter("code", typeof(string));
    
            var parentParameter = parent.HasValue ?
                new ObjectParameter("parent", parent) :
                new ObjectParameter("parent", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("f_COST_Update_Unified_Code", forIdParameter, titleParameter, categoryIdParameter, codeParameter, parentParameter);
        }
    
        public virtual int f_Cost_SP_Insert_Indirect_Project_Codes_Summerizng()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("f_Cost_SP_Insert_Indirect_Project_Codes_Summerizng");
        }
    
        public virtual int f_COST_Register_Items_To_ProjectCodes(string type)
        {
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("f_COST_Register_Items_To_ProjectCodes", typeParameter);
        }
    
        public virtual int f_Cost_UPdate_Items_Registeration(string type)
        {
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("f_Cost_UPdate_Items_Registeration", typeParameter);
        }
    }
}
