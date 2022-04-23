using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPurchaseReceiptService
    {
        void UpdatePurchaseReceipt(PurchaseReceipt purchaseReceipt, int Id);
        PurchaseReceipt AddPurchaseReceipt(PurchaseReceipt purchaseReceipt);
        void DeletePurchaseReceipt(int Id);

    }
}
