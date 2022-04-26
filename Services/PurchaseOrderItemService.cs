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
    public class PurchaseOrderItemService : IPurchaseOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public PurchaseOrderItem AddPurchaseOrderItem(PurchaseOrderItem purchaseOrderItem,int id)
        {
            var newPurchaseOrderItem = new PurchaseOrderItem()
            {
                ProductId = purchaseOrderItem.ProductId,
                PurchaseOrderId = id,
                Price = purchaseOrderItem.Price,
                DiscountAmount = purchaseOrderItem.DiscountAmount,
                Quantity = purchaseOrderItem.Quantity,
                TaxPercentage = purchaseOrderItem.TaxPercentage,
                SubTotal = purchaseOrderItem.SubTotal,
                BeforeTotal = purchaseOrderItem.BeforeTotal,
                TaxAmount = purchaseOrderItem.TaxAmount,
                Total = purchaseOrderItem.Total
            };
            _unitOfWork.PurchaseOrderItems.Add(newPurchaseOrderItem);
            _unitOfWork.Complete();
            return newPurchaseOrderItem;
        }

        public void DeletePurchaseOrderItem(int Id)
        {

            var purchaseOrderItem = _unitOfWork.PurchaseOrderItems.GetById(Id);
            _unitOfWork.PurchaseOrderItems.Remove(purchaseOrderItem);
            _unitOfWork.Complete();
        }

        public void UpdatePurchaseOrderItem(PurchaseOrderItem purchaseOrderItem, int Id)
        {
            var getPurchaseOrderItem = _unitOfWork.PurchaseOrderItems.GetById(Id);
            getPurchaseOrderItem.ProductId = purchaseOrderItem.ProductId;
            getPurchaseOrderItem.Price = purchaseOrderItem.Price;
            getPurchaseOrderItem.DiscountAmount = purchaseOrderItem.DiscountAmount;
            getPurchaseOrderItem.Quantity = purchaseOrderItem.Quantity;
            getPurchaseOrderItem.TaxPercentage = purchaseOrderItem.TaxPercentage;
            getPurchaseOrderItem.SubTotal = purchaseOrderItem.SubTotal;
            getPurchaseOrderItem.BeforeTotal = purchaseOrderItem.BeforeTotal;
            getPurchaseOrderItem.TaxAmount = purchaseOrderItem.TaxAmount;
            getPurchaseOrderItem.Total = purchaseOrderItem.Total;
            _unitOfWork.Complete();

        }
    }
}
