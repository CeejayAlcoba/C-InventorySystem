using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(ApplicationContext context) : base(context)
        {
        }

        public Sale GetPurchase(int saleId, bool includeCustomer = false, bool includeProduct = false)
        {
            var query = _context.Sales.AsQueryable();

            if (includeCustomer)
                query = query.Include(x => x.Customer);

            if (includeProduct)
                query = query.Include(x => x.Product);

            return query.FirstOrDefault(x => x.SaleId == saleId);
        }
    }
}
