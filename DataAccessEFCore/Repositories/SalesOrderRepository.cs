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
    public class SalesOrderRepository : GenericRepository<SalesOrder>, ISalesOrderRepository
    {

        public SalesOrderRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable GetAllSalesOrder(int salesOrderId, bool includeCustomer, bool includeSalesChannel, bool includeSalesOrderItem)
        {

            var query = _context.SalesOrders.AsQueryable();

            if (includeCustomer)
                query = query.Include(x => x.Customer);

            if (includeSalesChannel)
                query = query.Include(x => x.SalesChannel);

            if (includeSalesOrderItem)
                query = query.Include(x => x.SalesOrderItem);
            return query.ToList();
        }

        public SalesOrder GetSalesOrder(int salesOrderId, bool includeCustomer, bool includeSalesChannel, bool includeSalesOrderItem)
        {
            var query = _context.SalesOrders.AsQueryable();

            if (includeCustomer)
                query = query.Include(x => x.Customer);

            if (includeSalesChannel)
                query = query.Include(x => x.SalesChannel);
            if (includeSalesOrderItem)
                query = query.Include(x => x.SalesOrderItem);

            return query.FirstOrDefault(x => x.SalesOrderId== salesOrderId);
        }
    }
}

