using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductHistoryRepository : IGenericRepository<ProductHistory>
    {
        IQueryable GetProductHistory(bool includeProduct = true, bool includeSalesOrder = true, bool includePurchaseOrder = true, bool isActive = true);
        IQueryable GetProductHistoryById(int salesorderId = 0, int purchaseOrderId = 0, bool includeProduct = true, bool includeSalesOrder = true, bool includePurchaseOrder = true, bool isActive = true);
    }
}
