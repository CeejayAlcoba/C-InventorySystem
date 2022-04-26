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
            var newPurchaseReceipt = new PurchaseReceipt()
            {
                Description = purchaseReceipt.Description,
                ReceiptDate = purchaseReceipt.ReceiptDate,
                PurchaseOrderId = purchaseReceipt.PurchaseOrderId,
                Location = purchaseReceipt.Location,
                Total = purchaseReceipt.Total
            };
            _unitOfWork.PurchaseReceipts.Add(newPurchaseReceipt);
            _unitOfWork.Complete();
            return newPurchaseReceipt;
        }

        public void DeletePurchaseReceipt(int Id)
        {
            var purchaseReceipt = _unitOfWork.PurchaseReceipts.GetById(Id);
            _unitOfWork.PurchaseReceipts.Remove(purchaseReceipt);
            _unitOfWork.Complete();
        }

        public void UpdatePurchaseReceipt(PurchaseReceipt purchaseReceipt, int Id)
        {
            var getPurchaseReceipt = _unitOfWork.PurchaseReceipts.GetById(Id);
            getPurchaseReceipt.Description = purchaseReceipt.Description;
            getPurchaseReceipt.ReceiptDate = purchaseReceipt.ReceiptDate;
            getPurchaseReceipt.PurchaseOrderId = purchaseReceipt.PurchaseOrderId;
            getPurchaseReceipt.Location = purchaseReceipt.Location;
            getPurchaseReceipt.Total = purchaseReceipt.Total;
            _unitOfWork.Complete();
        }
    }
}
