using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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

        public IEnumerable GetAllProduct(bool includeUom, bool includeBrand, bool includeCategory, bool includeSize, bool includeColour)
        {
            var query = _context.Products.AsQueryable();

            if (includeUom)
                query = query.Include(x => x.Uom);
            if (includeBrand)
                query = query.Include(x => x.Brand);
            if (includeCategory)
                query = query.Include(x => x.Category);
            if (includeSize)
                query = query.Include(x => x.Size);
            if (includeColour)
                query = query.Include(x => x.Colour);

            return query.ToList();
        }

        public Product GetProduct(int productId, bool includeUom, bool includeBrand, bool includeCategory, bool includeSize, bool includeColour)
        {
            var query = _context.Products.AsQueryable();

            if (includeUom)
                query = query.Include(x => x.Uom);
            if (includeBrand)
                query = query.Include(x => x.Brand);
            if (includeCategory)
                query = query.Include(x => x.Category);
            if (includeSize)
                query = query.Include(x => x.Size);
            if (includeColour)
                query = query.Include(x => x.Colour);

            return query.FirstOrDefault(x => x.ProductId == productId);
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(x => x.Name == name);
        }
        public IEnumerable GetMinimumStocks(bool includeUom, bool includeBrand, bool includeCategory, bool includeSize, bool includeColour)
        {
            var query = _context.Products.AsQueryable();

            if (includeUom)
                query = query.Include(x => x.Uom);
            if (includeBrand)
                query = query.Include(x => x.Brand);
            if (includeCategory)
                query = query.Include(x => x.Category);
            if (includeSize)
                query = query.Include(x => x.Size);
            if (includeColour)
                query = query.Include(x => x.Colour);

            var getQuantity = query.Where(c=>c.Quantity <=20);
            
            return getQuantity;
        }
    }
}
