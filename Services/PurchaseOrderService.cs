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
        public PurchaseOrder CompletePurchaseOrder(int id,DateTime date)
        {
            var getPurchaseOrder = _unitOfWork.PurchaseOrders.GetById(id);
            getPurchaseOrder.Status = "Completed";
            getPurchaseOrder.Date = date;
            _unitOfWork.Complete();
            return getPurchaseOrder;
        }
        public PurchaseOrder ReturnPurchaseOrder(int id, DateTime date)
        {
            var getPurchaseOrder = _unitOfWork.PurchaseOrders.GetById(id);
            getPurchaseOrder.Status = "Returned";
            getPurchaseOrder.Date = date;
            _unitOfWork.Complete();
            return getPurchaseOrder;
        }
        public PurchaseOrder CancelPurchaseOrder(int id, DateTime date)
        {
            var getPurchaseOrder = _unitOfWork.PurchaseOrders.GetById(id);
            getPurchaseOrder.Status = "Cancelled";
            getPurchaseOrder.Date = date;
            _unitOfWork.Complete();
            return getPurchaseOrder;
        }
        public PurchaseOrder ReOpenPurchaseOrder(int id)
        {
            var getPurchaseOrder = _unitOfWork.PurchaseOrders.GetById(id);
            getPurchaseOrder.Status = "Open";
            getPurchaseOrder.Date = getPurchaseOrder.DefaultDate;
            _unitOfWork.Complete();
            return getPurchaseOrder;
        }
        public PurchaseOrder AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            var lastId = _unitOfWork.PurchaseOrders.GetNextId();
            var newPurchaseOrder = new PurchaseOrder()
            {
                Name = "PO/"+lastId.ToString(),
                SupplierId = purchaseOrder.SupplierId,
                DefaultDate = purchaseOrder.Date,
                PurchaseOrderItems=purchaseOrder.PurchaseOrderItems,
                BeforeTax=purchaseOrder.BeforeTax,
                Description=purchaseOrder.Description,
                SubTotal=purchaseOrder.SubTotal,
                Discount=purchaseOrder.Discount,
                TaxAmount=purchaseOrder.TaxAmount,
                OtherCharge=purchaseOrder.OtherCharge,
                Total=purchaseOrder.Total
            };
            _unitOfWork.PurchaseOrders.Add(newPurchaseOrder);

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
            purchaseOrder.IsDelete = true;
            _unitOfWork.Complete();
        }

        public void UpdatePurchaseOrder(PurchaseOrder purchaseOrder, int Id)
        {
            var getPurchaseOrder = _unitOfWork.PurchaseOrders.GetById(Id);
            getPurchaseOrder.Description = purchaseOrder.Description;
            getPurchaseOrder.Date = purchaseOrder.Date;
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
