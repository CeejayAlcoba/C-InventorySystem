using DataAccessEFCore.Repositories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Brands = new BrandRepository(_context);
            Categories = new CategoryRepository(_context);
            Colours = new ColourRepository(_context);
            Customers = new CustomerRepository(_context);
            Locations = new LocationRepository(_context);
            Products = new ProductRepository(_context);
            PurchaseOrderItems = new PurchaseOrderItemRepository(_context);
            PurchaseOrders = new PurchaseOrderRepository(_context);
            PurchaseReceipts = new PurchaseReceiptRepository(_context);
            PurchaseReturns = new PurchaseReturnRepository(_context);
            SalesChannels = new SalesChannelRepository(_context);
            SalesDeliveries = new SalesDeliveryRepository(_context);
            SalesOrders = new SalesOrderRepository(_context);
            SalesOrderItems = new SalesOrderItemRepository(_context);
            SalesReturns = new SalesReturnRepository(_context);
            Shippers = new ShipperRepository(_context);
            Sizes = new SizeRepository(_context);
            Uoms = new UomRepository(_context);
            Suppliers = new SupplierRepository(_context);
            ProductHistories = new ProductHistoryRepository(_context);

        }
        public IProductHistoryRepository ProductHistories { get; private set; }
        public IUserRepository Users { get; private set; }
        public IBrandRepository Brands { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IColourRepository Colours { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public ILocationRepository Locations { get; private set; }
        public IProductRepository Products { get; private set; }
        public IPurchaseOrderItemRepository PurchaseOrderItems { get; private set; }
        public IPurchaseOrderRepository PurchaseOrders { get; private set; }
        public IPurchaseReceiptRepository PurchaseReceipts { get; private set; }
        public IPurchaseReturnRepository PurchaseReturns { get; private set; }
        public ISalesChannelRepository SalesChannels { get; private set; }
        public ISalesDeliveryRepository SalesDeliveries { get; private set; }
        public ISalesOrderRepository SalesOrders { get; private set; }
        public ISalesOrderItemRepository SalesOrderItems { get; private set; }
        public ISalesReturnRepository SalesReturns { get; private set; }
        public IShipperRepository Shippers { get; private set; }
        public ISizeRepository Sizes { get; private set; }
        public IUomRepository Uoms { get; private set; }
        public ISupplierRepository Suppliers { get; private set; }



        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
