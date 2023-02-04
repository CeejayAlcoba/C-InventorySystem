using Domain.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public DbSet<Role> Roles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ProductHistory> ProductHistories { get; set; }
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
            var salt = ModelBuilderExtensions.GenerateSalt("Admin");
            var hashedPassword = ModelBuilderExtensions.GenerateHashPassword("Admin", salt);
            modelBuilder.Entity<Role>().HasData(
             new Role
             {
                 RoleId = 1,
                 RoleType = "Admin",
             },
             new Role
             {
                 RoleId = 2,
                 RoleType = "Staff",

             }
                );
            modelBuilder.Entity<User>().HasData(
             new User
             {
                 Id = 1,
                 Firstname = "Admin",
                 Lastname = "Admin",
                 Username = "Admin",
                 Salt = salt,
                 HashPassword = hashedPassword,
                 RoleId=1

             }
                );
            
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
            modelBuilder.Entity<ProductHistory>()
            .Property(b => b.IsActive)
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
        public static class ModelBuilderExtensions
        {
            public static byte[] GenerateSalt(string password)
            {
                var salt = new byte[128 / 8];

                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetNonZeroBytes(salt);
                }
                return salt;
            }
            public static string GenerateHashPassword(string password, byte[] salt)
            {
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
                return hashed;
            }

        }
       
    }
}
