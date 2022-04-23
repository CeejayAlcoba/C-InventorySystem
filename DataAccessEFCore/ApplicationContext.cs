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
        public DbSet<SalesDeliveryItem> SalesDeliveryItems { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }
        public DbSet<SalesReturn> SalesReturns { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Uom> Uoms { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
