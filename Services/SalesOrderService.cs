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
    public class SalesOrderService : ISalesOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public SalesOrder AddSalesOrder(SalesOrder salesOrder)
        {
            var lastId = _unitOfWork.SalesOrders.GetNextId();
            var newSalesOrder = new SalesOrder()
            {
                Name = "PO/" + lastId.ToString(),
                CustomerId = salesOrder.CustomerId,
                DefaultDate = salesOrder.Date,
                SalesChannelId=salesOrder.SalesChannelId,
                SalesOrderItem = salesOrder.SalesOrderItem,
                BeforeTax = salesOrder.BeforeTax,
                Description = salesOrder.Description,
                SubTotal = salesOrder.SubTotal,
                Discount = salesOrder.Discount,
                TaxAmount = salesOrder.TaxAmount,
                OtherCharge = salesOrder.OtherCharge,
                Total = salesOrder.Total
            };
            _unitOfWork.SalesOrders.Add(newSalesOrder);
            var orderedProductIds = salesOrder.SalesOrderItem
                .Select(x => x.ProductId);
            var orderedProducts = _unitOfWork.Products
                .Find(x => orderedProductIds.Contains(x.ProductId));

            orderedProducts.ToList()
                .ForEach(p => p.Quantity -=
                    salesOrder.SalesOrderItem.First(poi => poi.ProductId == p.ProductId).Quantity);

            _unitOfWork.Complete();

            return salesOrder;
        }

        public void DeleteSalesOrder(int Id)
        {
            var salesOrder = _unitOfWork.SalesOrders.GetById(Id);
            _unitOfWork.SalesOrders.Remove(salesOrder);
            _unitOfWork.Complete();
        }

        public void UpdateSalesOrder(SalesOrder salesOrder, int Id)
        {
            var getSalesOrder = _unitOfWork.SalesOrders.GetById(Id);
            getSalesOrder.Description = salesOrder.Description;
            getSalesOrder.Date = salesOrder.Date;
            getSalesOrder.CustomerId = salesOrder.CustomerId;
            getSalesOrder.SalesChannelId = salesOrder.SalesOrderId;
            _unitOfWork.Complete();
        }
        public SalesOrder CompleteSalesOrder(int id, DateTime date)
        {
            var getSalesOrder = _unitOfWork.SalesOrders.GetById(id);
            getSalesOrder.Status = "Completed";
            getSalesOrder.Date = date;
            _unitOfWork.Complete();
            return getSalesOrder;
        }
        public SalesOrder ReturnSalesOrder(int id, DateTime date)
        {
            var getSalesOrder = _unitOfWork.SalesOrders.GetById(id);
            getSalesOrder.Status = "Returned";
            getSalesOrder.Date = date;
            _unitOfWork.Complete();
            return getSalesOrder;
        }
        public SalesOrder CancelSalesOrder(int id, DateTime date)
        {
            var getSalesOrder = _unitOfWork.SalesOrders.GetById(id);
            getSalesOrder.Status = "Cancelled";
            getSalesOrder.Date = date;
            _unitOfWork.Complete();
            return getSalesOrder;
        }
        public SalesOrder ReOpenSalesOrder(int id)
        {
            var getSalesOrder = _unitOfWork.SalesOrders.GetById(id);
            getSalesOrder.Status = "Open";
            getSalesOrder.Date = getSalesOrder.DefaultDate;
            _unitOfWork.Complete();
            return getSalesOrder;
        }
    }
}
