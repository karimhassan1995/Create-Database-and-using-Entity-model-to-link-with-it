using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp1
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Dispence_Permission> Dispence_Permission { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Measuring_unit> Measuring_unit { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Stock_Item> Stock_Item { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supply_permission> Supply_permission { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.fax)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Item_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Dispence_Permission)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasOptional(e => e.Measuring_unit)
                .WithRequired(e => e.Item);

            modelBuilder.Entity<Item>()
                .HasOptional(e => e.Measuring_unit1)
                .WithRequired(e => e.Item1);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Stock_Item)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Supply_permission)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Measuring_unit>()
                .Property(e => e.unit)
                .IsUnicode(false);

            modelBuilder.Entity<Stock>()
                .Property(e => e.Stock_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Stock>()
                .Property(e => e.Manager_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Stock>()
                .HasMany(e => e.Dispence_Permission)
                .WithRequired(e => e.Stock)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stock>()
                .HasMany(e => e.Stock_Item)
                .WithRequired(e => e.Stock)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stock>()
                .HasMany(e => e.Supply_permission)
                .WithRequired(e => e.Stock)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Supplier_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.fax)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Dispence_Permission)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Supply_permission)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);
        }
    }
}
