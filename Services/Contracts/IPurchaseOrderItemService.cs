using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPurchaseOrderItemService
    {
        void UpdatePurchaseOrderItem(PurchaseOrderItem purchaseOrderItem, int Id);
        PurchaseOrderItem AddPurchaseOrderItem(PurchaseOrderItem purchaseOrderItem);
        void DeletePurchaseOrderItem(int Id);

    }
}
