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
    public class SalesOrderItemRepository : GenericRepository<SalesOrderItem>, ISalesOrderItemRepository
    {

        public SalesOrderItemRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable GetSsalesOrderItemById(int Id)
        {
            var query = _context.SalesOrderItems.AsQueryable();
            query = query.Include(x => x.Product);
            var filter = query.Where(c => c.SalesOrderId == Id);
            return filter;
        }
    }
}
