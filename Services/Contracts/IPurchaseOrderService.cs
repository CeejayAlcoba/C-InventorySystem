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
        void UpdatePurchaseOrder(PurchaseOrder purchaseOrder, int Id);
        PurchaseOrder AddPurchaseOrder(PurchaseOrder purchaseOrder);
        void DeletePurchaseOrder(int Id);

    }
}
