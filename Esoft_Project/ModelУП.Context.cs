﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Esoft_Project
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class УПEntities : DbContext
    {
        public УПEntities()
            : base("name=УПEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<КлиентыSet> КлиентыSet { get; set; }
        public virtual DbSet<Объекты_недвижимостиSet> Объекты_недвижимостиSet { get; set; }
        public virtual DbSet<ПотребностиSet> ПотребностиSet { get; set; }
        public virtual DbSet<ПредложенияSet> ПредложенияSet { get; set; }
        public virtual DbSet<РиэлторSet> РиэлторSet { get; set; }
        public virtual DbSet<СделкиSet> СделкиSet { get; set; }
    }
}
