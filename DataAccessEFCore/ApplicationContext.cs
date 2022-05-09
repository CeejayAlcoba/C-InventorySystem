using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<PurchaseReceipt> PurchaseReceipts { get; set; }
        public DbSet<PurchaseReturn> PurchaseReturns { get; set; }
        public DbSet<SalesChannel> SalesChannels { get; set; }
        public DbSet<SalesDelivery> SalesDeliveries { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }
        public DbSet<SalesReturn> SalesReturns { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Uom> Uoms { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseOrder>()
                .Property(b => b.Status)
                .HasDefaultValue("Open");
            modelBuilder.Entity<PurchaseOrder>()
              .Property(b => b.IsDelete)
              .HasDefaultValue(false);
            modelBuilder.Entity<SalesOrder>()
              .Property(b => b.IsDelete)
              .HasDefaultValue(false);
            modelBuilder.Entity<SalesOrder>()
                .Property(b => b.Status)
                .HasDefaultValue("Open");
            modelBuilder.Entity<PurchaseOrder>()
              .Property(b => b.IsDelete)
              .HasDefaultValue(false);
            modelBuilder.Entity<User>()
              .Property(b => b.IsDelete)
              .HasDefaultValue(false);
            modelBuilder.Entity<Brand>()
             .Property(b => b.IsDelete)
             .HasDefaultValue(false);
            modelBuilder.Entity<Category>()
            .Property(b => b.IsDelete)
           .HasDefaultValue(false);
            modelBuilder.Entity<Colour>()
             .Property(b => b.IsDelete)
             .HasDefaultValue(false);
            modelBuilder.Entity<Location>()
            .Property(b => b.IsDelete)
            .HasDefaultValue(false);
            modelBuilder.Entity<Product>()
            .Property(b => b.IsDelete)
            .HasDefaultValue(false);
            modelBuilder.Entity<PurchaseOrderItem>()
            .Property(b => b.IsDelete)
            .HasDefaultValue(false);
            modelBuilder.Entity<PurchaseReceipt>()
            .Property(b => b.IsDelete)
            .HasDefaultValue(false);
            modelBuilder.Entity<PurchaseReturn>()
            .Property(b => b.IsDelete)
            .HasDefaultValue(false);
            modelBuilder.Entity<SalesChannel>()
            .Property(b => b.IsDelete)
            .HasDefaultValue(false);
            modelBuilder.Entity<SalesDelivery>()
            .Property(b => b.IsDelete)
            .HasDefaultValue(false);
            modelBuilder.Entity<SalesDeliveryItem>()
            .Property(b => b.IsDelete)
            .HasDefaultValue(false);
            modelBuilder.Entity<SalesOrderItem>()
            .Property(b => b.IsDelete)
            .HasDefaultValue(false);
            modelBuilder.Entity<SalesReturn>()
            .Property(b => b.IsDelete)
            .HasDefaultValue(false);
            modelBuilder.Entity<Shipper>()
           .Property(b => b.IsDelete)
           .HasDefaultValue(false);
            modelBuilder.Entity<Size>()
           .Property(b => b.IsDelete)
           .HasDefaultValue(false);
            modelBuilder.Entity<Supplier>()
           .Property(b => b.IsDelete)
           .HasDefaultValue(false);
            modelBuilder.Entity<Uom>()
           .Property(b => b.IsDelete)
           .HasDefaultValue(false);
        }
    }
}
