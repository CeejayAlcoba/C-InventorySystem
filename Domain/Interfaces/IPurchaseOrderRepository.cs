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
        int GetNextId();
        PurchaseOrder GetPurchase(
          int purchaseOrderId,
          bool includeSupplier,
          bool includePurchaseOrderItem,
          string status,
          bool isDelete
         );
        IEnumerable GetAllPurchase(
          bool includeSupplier,
          bool includePurchaseOrderItem,
          string status,
          bool isDelete);
        double GetPurchaseOrderItemsTotalQuantity(string status);
        IEnumerable GetDailyPurchase(
           bool includeSupplier = false,
           bool includePurchaseOrderItem = false,
           bool isDelete = false
           );
    }
}
