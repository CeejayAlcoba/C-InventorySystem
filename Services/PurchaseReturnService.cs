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
    public class PurchaseReturnService : IPurchaseReturnService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseReturnService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public PurchaseReturn AddPurchaseReturn(PurchaseReturn purchaseReturn)
        {
            var newPurchaseReturn = new PurchaseReturn()
            {
                Description = purchaseReturn.Description,
                ReturnDate = purchaseReturn.ReturnDate,
                PurchaseReceiptId = purchaseReturn.PurchaseReceiptId,
                Total = purchaseReturn.Total
            };
            _unitOfWork.PurchaseReturns.Add(newPurchaseReturn);
            _unitOfWork.Complete();
            return newPurchaseReturn;
        }

        public void DeletePurchaseReturn(int Id)
        {
            var purchaseReturn = _unitOfWork.PurchaseReturns.GetById(Id);
            _unitOfWork.PurchaseReturns.Remove(purchaseReturn);
            _unitOfWork.Complete();
        }

        public void UpdatePurchaseReturn(PurchaseReturn purchaseReturn, int Id)
        {
            var getPurchaseReturn = _unitOfWork.PurchaseReturns.GetById(Id);
            getPurchaseReturn.Description = purchaseReturn.Description;
            getPurchaseReturn.ReturnDate = purchaseReturn.ReturnDate;
            getPurchaseReturn.PurchaseReceiptId = purchaseReturn.PurchaseReceiptId;
            getPurchaseReturn.Total = purchaseReturn.Total;
            _unitOfWork.Complete();
        }
    }
}
