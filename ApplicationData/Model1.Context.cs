﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_PR15_Mebel_Kile2.ApplicationData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MebelEntities : DbContext
    {
        private static MebelEntities _context;
        public MebelEntities()
            : base("name=MebelEntities")
        {
        }
        public static MebelEntities GetContext()
        {
            if (_context == null)
                _context = new MebelEntities();
            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BrendTable> BrendTable { get; set; }
        public virtual DbSet<ColorTable> ColorTable { get; set; }
        public virtual DbSet<SleepAccessories> SleepAccessories { get; set; }
        public virtual DbSet<TypeTable> TypeTable { get; set; }
    }
}
