using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPurchaseReturnService
    {
        void UpdatePurchaseReturn(PurchaseReturn purchaseReturn, int Id);
        PurchaseReturn AddPurchaseReturn(PurchaseReturn purchaseReturn);
        void DeletePurchaseReturn(int Id);

    }
}
