using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace eStore.Models
{
    public partial class eStoreModels : DbContext
    {
        public eStoreModels()
            : base("name=eStoreModels")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Freight)
                .HasPrecision(10, 2);

            //modelBuilder.Entity<Order>()
            //    .HasMany(e => e.OrderDetails)
            //    .WithRequired(e => e.Order)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.weight)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            //modelBuilder.Entity<Product>()
            //    .HasMany(e => e.OrderDetails)
            //    .WithRequired(e => e.Product)
            //    .WillCascadeOnDelete(false);
        }
    }
}
