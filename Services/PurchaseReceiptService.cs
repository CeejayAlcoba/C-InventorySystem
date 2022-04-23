using Domain.Entities;
using Domain.Interfaces;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PurchaseReceiptService : IPurchaseReceiptService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseReceiptService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public PurchaseReceipt AddPurchaseReceipt(PurchaseReceipt purchaseReceipt)
        {
            throw new NotImplementedException();
        }

        public void DeletePurchaseReceipt(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePurchaseReceipt(PurchaseReceipt purchaseReceipt, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
