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
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>, IPurchaseOrderRepository
    {

        public PurchaseOrderRepository(ApplicationContext context) : base(context)
        {
        }
        public int GetNextId()
        {

            var purchaseOrders = _context.PurchaseOrderItems.ToList();
            if (purchaseOrders != null)
            {
                int lastId = _context.PurchaseOrders.Select(c => c.PurchaseOrderId).Max();
                return lastId + 1;
            }
            else return 0;
            
        }
        public PurchaseOrder GetPurchase(
           int purchaseOrderId,
           bool includeSupplier = false,
           bool includePurchaseOrderItem = false,
           string status = "Open",
           bool isDelete =false
           )
        {
            var query = _context.PurchaseOrders.AsQueryable();
            var queryPOI = _context.PurchaseOrderItems.AsQueryable();

            if (includeSupplier)
                query = query.Include(x => x.Supplier);

            if (includePurchaseOrderItem)
                query = query.Include(x => x.PurchaseOrderItems);
            var purchaseOrder = query.FirstOrDefault(x => x.PurchaseOrderId == purchaseOrderId);

            if(purchaseOrder.Status == status && purchaseOrder.IsDelete== isDelete)
            {
                return purchaseOrder;
            }
            else
            {
                return null;
            }
           
        }
        public IEnumerable GetAllPurchase(
           bool includeSupplier = false,
           bool includePurchaseOrderItem = false,
           string status = "Open",
           bool isDelete = false
           )
        {

            var query = _context.PurchaseOrders.AsQueryable();

            if (includeSupplier)
                query = query.Include(x => x.Supplier);

            if (includePurchaseOrderItem)
                query = query.Include(x => x.PurchaseOrderItems);
            if(status == null || status=="")
            {
                return query.ToList();
            }
            else
            {
                var list = query.Where(c => c.Status == status && c.IsDelete == isDelete).ToList();
                return list;
            }
        }
        public double GetPurchaseOrderItemsTotalQuantity(string status)
        {
            var query = _context.PurchaseOrders.AsQueryable();
            query = query.Include(x => x.PurchaseOrderItems);
            if (status == "Completed")
            {
                double sum = 0;
                var poCompleted = query.Where(a => a.Status == "Completed");
                var selectPoi = poCompleted.Select(c => c.PurchaseOrderItems);
                foreach (var item in selectPoi)
                {
                    sum = sum + item.Select(c => c.Quantity).Sum();
                }
                return sum;
                //var PoStatus = query.Where(c => c.Status == "Completed");
                //var purchaseOrderItems = PoStatus.Select(c => c.PurchaseOrderItems);
                //return purchaseOrderItems.Select(c => c.Quantity);
            }
            else if (status == "Returned")
            {
                double sum = 0;
                var poReturned = query.Where(a => a.Status == "Returned");
                var selectPoi = poReturned.Select(c => c.PurchaseOrderItems);
                foreach (var item in selectPoi)
                {
                    sum = sum + item.Select(c => c.Quantity).Sum();
                }
                return sum;
            }
            else
                return 0;

        }
        public IEnumerable GetDailyPurchase(
           bool includeSupplier = false,
           bool includePurchaseOrderItem = false,
           bool isDelete = false
           )
        {
            DateTime now = DateTime.Now;
            var getDate = DateTime.Parse(now.ToLongDateString());

            var query = _context.PurchaseOrders.AsQueryable();

            if (includeSupplier)
                query = query.Include(x => x.Supplier);

            if (includePurchaseOrderItem)
                query = query.Include(x => x.PurchaseOrderItems);
            var PoCompletes = query.Where(c => c.Status == "Completed");
            var TodayPurchases = PoCompletes.Where(c => c.Date == getDate);
            return TodayPurchases;
        }
    }
}
