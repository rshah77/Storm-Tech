﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StormTech.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class STdatabaseEntities1 : DbContext
    {
        public STdatabaseEntities1()
            : base("name=STdatabaseEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Invoice_table> Invoice_table { get; set; }
        public DbSet<Item_table> Item_table { get; set; }
        public DbSet<Purchase_Table> Purchase_Table { get; set; }
        public DbSet<Supplier_table> Supplier_table { get; set; }
    }
}
