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
        public int GetNextId()
        {

            var salesOrders = GetAll();
            if (salesOrders.Count() != 0)
            {
                int lastId = _context.SalesOrders.Select(c => c.SalesOrderId).Max();
                return lastId + 1;
            }
            else return 1;

        }
        public IEnumerable GetAllSalesOrder(bool includeCustomer=false,
            bool includeSalesChannel=false, 
            bool includeSalesOrderItem=false,
            string status = "Open",
           bool isDelete = false)
        {

            var query = _context.SalesOrders.AsQueryable();

            if (includeCustomer)
                query = query.Include(x => x.Customer);

            if (includeSalesChannel)
                query = query.Include(x => x.SalesChannel);

            if (includeSalesOrderItem)
                query = query.Include(x => x.SalesOrderItem);
            if (status == null || status == "")
            {
                return query.ToList();
            }
            else
            {
                var list = query.Where(c => c.Status == status && c.IsDelete == isDelete).ToList();
                return list;
            }
        }

        public SalesOrder GetSalesOrder(int salesOrderId,
            bool includeCustomer = false,
            bool includeSalesChannel = false,
            bool includeSalesOrderItem = false,
            string status = "Open",
           bool isDelete = false)
        {
            var query = _context.SalesOrders.AsQueryable();

            if (includeCustomer)
                query = query.Include(x => x.Customer);

            if (includeSalesChannel)
                query = query.Include(x => x.SalesChannel);
            if (includeSalesOrderItem)
                query = query.Include(x => x.SalesOrderItem);

            var salesOrder = query.FirstOrDefault(x => x.SalesOrderId == salesOrderId);
            if (salesOrder.Status == status && salesOrder.IsDelete == isDelete)
            {
                return salesOrder;
            }
            else
            {
                return null;
            }
        }
            public double GetSalesOrderItemsTotalQuantity(string status)
            {
                var query = _context.SalesOrders.AsQueryable();
                query = query.Include(x => x.SalesOrderItem);
                if (status == "Completed")
                {
                    double sum = 0;
                    var soCompleted = query.Where(a => a.Status == "Completed");
                    var selectSoi = soCompleted.Select(c => c.SalesOrderItem);
                    foreach (var item in selectSoi)
                    {
                        sum = sum + item.Select(c => c.Quantity).Sum();
                    }
                    return sum;
                }
                else if (status == "Returned")
                {
                    double sum = 0;
                    var soReturned = query.Where(a => a.Status == "Returned");
                    var selectSoi = soReturned.Select(c => c.SalesOrderItem);
                    foreach (var item in selectSoi)
                    {
                        sum = sum + item.Select(c => c.Quantity).Sum();
                    }
                    return sum;
                }
                else
                    return 0;

            }
            public IEnumerable GetDailySales(
               bool includeCustomer = false,
               bool includeSalesOrderItem = false,
               bool isDelete = false
               )
            {
                DateTime now = DateTime.Now;
                var getDate = DateTime.Parse(now.ToLongDateString());

                var query = _context.SalesOrders.AsQueryable();

                if (includeCustomer)
                    query = query.Include(x => x.Customer);

                if (includeSalesOrderItem)
                    query = query.Include(x => x.SalesOrderItem);
                var PoCompletes = query.Where(c => c.Status == "Completed");
                var TodayPurchases = PoCompletes.Where(c => c.Date == getDate);
                return TodayPurchases;
            }
        
    }
}

