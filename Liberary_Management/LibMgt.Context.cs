﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Liberary_Management
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LiberaryManagementEntities : DbContext
    {
        public LiberaryManagementEntities()
            : base("name=LiberaryManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admin> admin { get; set; }
        public virtual DbSet<author> author { get; set; }
        public virtual DbSet<book> book { get; set; }
        public virtual DbSet<borrow> borrow { get; set; }
        public virtual DbSet<branch> branch { get; set; }
        public virtual DbSet<copy> copy { get; set; }
        public virtual DbSet<location> location { get; set; }
        public virtual DbSet<publisher> publisher { get; set; }
        public virtual DbSet<reader> reader { get; set; }
        public virtual DbSet<reserve> reserve { get; set; }
        public virtual DbSet<bookinfo> bookinfo { get; set; }
    
        public virtual ObjectResult<SearchBookBy_Result> SearchBookBy(Nullable<int> option, string searchData)
        {
            var optionParameter = option.HasValue ?
                new ObjectParameter("option", option) :
                new ObjectParameter("option", typeof(int));
    
            var searchDataParameter = searchData != null ?
                new ObjectParameter("searchData", searchData) :
                new ObjectParameter("searchData", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SearchBookBy_Result>("SearchBookBy", optionParameter, searchDataParameter);
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
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
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
    
        public virtual ObjectResult<SP_GetBookCopyForAdmin_Result> SP_GetBookCopyForAdmin(Nullable<int> option, string searchValue)
        {
            var optionParameter = option.HasValue ?
                new ObjectParameter("option", option) :
                new ObjectParameter("option", typeof(int));
    
            var searchValueParameter = searchValue != null ?
                new ObjectParameter("searchValue", searchValue) :
                new ObjectParameter("searchValue", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetBookCopyForAdmin_Result>("SP_GetBookCopyForAdmin", optionParameter, searchValueParameter);
        }
    
        public virtual int SP_InsertBookCopy(string isbn, string title, string publisherid, string author, string publicationDate, string branchid, string position)
        {
            var isbnParameter = isbn != null ?
                new ObjectParameter("isbn", isbn) :
                new ObjectParameter("isbn", typeof(string));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var publisheridParameter = publisherid != null ?
                new ObjectParameter("publisherid", publisherid) :
                new ObjectParameter("publisherid", typeof(string));
    
            var authorParameter = author != null ?
                new ObjectParameter("author", author) :
                new ObjectParameter("author", typeof(string));
    
            var publicationDateParameter = publicationDate != null ?
                new ObjectParameter("publicationDate", publicationDate) :
                new ObjectParameter("publicationDate", typeof(string));
    
            var branchidParameter = branchid != null ?
                new ObjectParameter("branchid", branchid) :
                new ObjectParameter("branchid", typeof(string));
    
            var positionParameter = position != null ?
                new ObjectParameter("position", position) :
                new ObjectParameter("position", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InsertBookCopy", isbnParameter, titleParameter, publisheridParameter, authorParameter, publicationDateParameter, branchidParameter, positionParameter);
        }
    
        public virtual ObjectResult<SearchBookBy1_Result> SearchBookBy1(Nullable<int> option, string searchData)
        {
            var optionParameter = option.HasValue ?
                new ObjectParameter("option", option) :
                new ObjectParameter("option", typeof(int));
    
            var searchDataParameter = searchData != null ?
                new ObjectParameter("searchData", searchData) :
                new ObjectParameter("searchData", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SearchBookBy1_Result>("SearchBookBy1", optionParameter, searchDataParameter);
        }
    
        public virtual ObjectResult<SP_GetBookCopyForAdmin1_Result> SP_GetBookCopyForAdmin1(Nullable<int> option, string searchValue)
        {
            var optionParameter = option.HasValue ?
                new ObjectParameter("option", option) :
                new ObjectParameter("option", typeof(int));
    
            var searchValueParameter = searchValue != null ?
                new ObjectParameter("searchValue", searchValue) :
                new ObjectParameter("searchValue", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetBookCopyForAdmin1_Result>("SP_GetBookCopyForAdmin1", optionParameter, searchValueParameter);
        }
    
        public virtual int SP_InsertBookCopy1(string isbn, string title, string publisherid, string author, string publicationDate, string branchid, string position)
        {
            var isbnParameter = isbn != null ?
                new ObjectParameter("isbn", isbn) :
                new ObjectParameter("isbn", typeof(string));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var publisheridParameter = publisherid != null ?
                new ObjectParameter("publisherid", publisherid) :
                new ObjectParameter("publisherid", typeof(string));
    
            var authorParameter = author != null ?
                new ObjectParameter("author", author) :
                new ObjectParameter("author", typeof(string));
    
            var publicationDateParameter = publicationDate != null ?
                new ObjectParameter("publicationDate", publicationDate) :
                new ObjectParameter("publicationDate", typeof(string));
    
            var branchidParameter = branchid != null ?
                new ObjectParameter("branchid", branchid) :
                new ObjectParameter("branchid", typeof(string));
    
            var positionParameter = position != null ?
                new ObjectParameter("position", position) :
                new ObjectParameter("position", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InsertBookCopy1", isbnParameter, titleParameter, publisheridParameter, authorParameter, publicationDateParameter, branchidParameter, positionParameter);
        }
    
        public virtual ObjectResult<SP_Top10Borrower_Result> SP_Top10Borrower(Nullable<int> brnachid)
        {
            var brnachidParameter = brnachid.HasValue ?
                new ObjectParameter("brnachid", brnachid) :
                new ObjectParameter("brnachid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Top10Borrower_Result>("SP_Top10Borrower", brnachidParameter);
        }
    }
}
