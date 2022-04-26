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
            var newPurchaseOrder = new PurchaseOrder()
            {
                Description = purchaseOrder.Description,
                OrderDate = purchaseOrder.OrderDate,
                SupplierId = purchaseOrder.SupplierId,
                SubTotal = purchaseOrder.SubTotal,
                Discount = purchaseOrder.Discount,
                BeforeTax = purchaseOrder.BeforeTax,
                TaxAmount = purchaseOrder.TaxAmount,
                OtherCharge = purchaseOrder.OtherCharge,
                Total = purchaseOrder.Total
            };
            _unitOfWork.PurchaseOrders.Add(newPurchaseOrder);
            _unitOfWork.Complete();
            return newPurchaseOrder;
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
