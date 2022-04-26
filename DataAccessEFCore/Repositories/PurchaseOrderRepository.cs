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
        public PurchaseOrder GetPurchase(
           int purchaseOrderId,
           bool includeSupplier = false,
           bool includePurchaseOrderItem = false)
        {
            var query = _context.PurchaseOrders.AsQueryable();

            if (includeSupplier)
                query = query.Include(x => x.Supplier);

            if (includePurchaseOrderItem)
                query = query.Include(x => x.PurchaseOrderItems);

            return query.FirstOrDefault(x => x.PurchaseOrderId == purchaseOrderId);
        }
        public IEnumerable GetAllPurchase(
           bool includeSupplier = false,
           bool includePurchaseOrderItem = false)
        {

            var query = _context.PurchaseOrders.AsQueryable();

            if (includeSupplier)
                query = query.Include(x => x.Supplier);

            if (includePurchaseOrderItem)
                query = query.Include(x => x.PurchaseOrderItems);
            return query.ToList();

        }

    }
}
