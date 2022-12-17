using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPurchaseOrderService
    {
        PurchaseOrder CompletePurchaseOrder(int id, DateTime date);
        PurchaseOrder ReturnPurchaseOrder(int id, DateTime date);
        void UpdatePurchaseOrder(PurchaseOrder purchaseOrder, int Id);
        PurchaseOrder AddPurchaseOrder(PurchaseOrder purchaseOrder);
        PurchaseOrder CancelPurchaseOrder(int id, DateTime date);
        PurchaseOrder ReOpenPurchaseOrder(int id);
        void DeletePurchaseOrder(int Id);
        void CancelPurchaseOrder(IEnumerable<PurchaseOrder> purchaseOrder);

    }
}
