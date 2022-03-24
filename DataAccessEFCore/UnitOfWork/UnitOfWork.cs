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
            Products = new ProductRepository(_context);
            Suppliers = new SupplierRepository(_context);
            Customers = new CustomerRepository(_context);
            Purchases = new PurchaseRepository(_context);
        }
        public IUserRepository Users { get; private set; }
        public IProductRepository Products { get; private set; }
        public ISupplierRepository Suppliers { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IPurchaseRepository Purchases { get; private set; }

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
