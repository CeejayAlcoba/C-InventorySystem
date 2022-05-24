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
    public class ProductHistoryRepository : GenericRepository<ProductHistory>, IProductHistoryRepository
    {

        public ProductHistoryRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable GetProductHistory(bool includeProduct=true,bool includeSalesOrder=true, bool includePurchaseOrder =true, bool isActive=true)
        {
            var query = _context.ProductHistories.AsQueryable();
            if (includeProduct)
                query = query.Include(x => x.Product);
            if (includeSalesOrder)
                query = query.Include(x => x.SalesOrder);

            if (includePurchaseOrder)
                query = query.Include(x => x.PurchaseOrder);
            var productHistory = query.Where(c => c.IsActive == isActive);
            return productHistory;

        }
        public IQueryable GetProductHistoryById(int salesorderId =0,int purchaseOrderId=0,bool includeProduct = true, bool includeSalesOrder = true, bool includePurchaseOrder = true, bool isActive = true)
        {
            if (purchaseOrderId > 0)
            {
                var query = _context.ProductHistories.AsQueryable();
                if (includeProduct)
                    query = query.Include(x => x.Product);
                if (includeSalesOrder)
                    query = query.Include(x => x.SalesOrder);

                if (includePurchaseOrder)
                    query = query.Include(x => x.PurchaseOrder);
                var productHistory = query.Where(c => c.PurchaseOrderId == purchaseOrderId);
                return productHistory;
            }
            else if (salesorderId > 0)
            {
                var query = _context.ProductHistories.AsQueryable();
                if (includeProduct)
                    query = query.Include(x => x.Product);
                if (includeSalesOrder)
                    query = query.Include(x => x.SalesOrder);

                if (includePurchaseOrder)
                    query = query.Include(x => x.PurchaseOrder);
                var productHistory = query.Where(c => c.SalesOrderId == salesorderId);
                return productHistory;
            }
            else return null;
        }

    }
}
