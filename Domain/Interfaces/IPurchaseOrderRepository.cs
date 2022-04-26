using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPurchaseOrderRepository : IGenericRepository<PurchaseOrder>
    {
        PurchaseOrder GetPurchase(
          int purchaseOrderId,
          bool includeSupplier,
          bool includePurchaseOrderItem);
        IEnumerable GetAllPurchase(
          bool includeSupplier,
          bool includePurchaseOrderItem);
    }
}
