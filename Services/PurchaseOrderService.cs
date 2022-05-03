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
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public PurchaseOrder AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            _unitOfWork.PurchaseOrders.Add(purchaseOrder);

            var purchasedProductIds = purchaseOrder.PurchaseOrderItems
                .Select(x => x.ProductId);
            var purchasedProducts = _unitOfWork.Products
                .Find(x => purchasedProductIds.Contains(x.ProductId));

            purchasedProducts.ToList()
                .ForEach(p => p.Quantity +=
                    purchaseOrder.PurchaseOrderItems.First(poi => poi.ProductId == p.ProductId).Quantity);

            _unitOfWork.Complete();

            return purchaseOrder;
        }

        public void DeletePurchaseOrder(int Id)
        {
            var purchaseOrder = _unitOfWork.PurchaseOrders.GetById(Id);
            _unitOfWork.PurchaseOrders.Remove(purchaseOrder);
            _unitOfWork.Complete();
        }

        public void UpdatePurchaseOrder(PurchaseOrder purchaseOrder, int Id)
        {
            var getPurchaseOrder = _unitOfWork.PurchaseOrders.GetById(Id);
            getPurchaseOrder.Description = purchaseOrder.Description;
            getPurchaseOrder.OrderDate = purchaseOrder.OrderDate;
            getPurchaseOrder.SupplierId = purchaseOrder.SupplierId;
            getPurchaseOrder.SubTotal = purchaseOrder.SubTotal;
            getPurchaseOrder.Discount = purchaseOrder.Discount;
            getPurchaseOrder.BeforeTax = purchaseOrder.BeforeTax;
            getPurchaseOrder.TaxAmount = purchaseOrder.TaxAmount;
            getPurchaseOrder.OtherCharge = purchaseOrder.OtherCharge;
            getPurchaseOrder.Total = purchaseOrder.Total;
            _unitOfWork.Complete();
        }
    }
}
