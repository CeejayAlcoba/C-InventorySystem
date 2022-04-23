using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(x => x.Name == name);
        }
    }
}
