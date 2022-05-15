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
    public class PurchaseOrderItemRepository : GenericRepository<PurchaseOrderItem>, IPurchaseOrderItemRepository
    {

        public PurchaseOrderItemRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable GetPurchaseOrderItemById(int Id)
        {
            var query = _context.PurchaseOrderItems.AsQueryable();
            query = query.Include(x => x.Product);
            var filter = query.Where(c => c.PurchaseOrderId == Id);
            return filter;
        }
    }
}
