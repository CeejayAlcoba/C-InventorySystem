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
                Name = "SO/" + lastId.ToString(),
                CustomerId = salesOrder.CustomerId,
                Date = salesOrder.Date,
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
            var soldProductIds = salesOrder.SalesOrderItem
                .Select(x => x.ProductId);
            var soldProducts = _unitOfWork.Products
                .Find(x => soldProductIds.Contains(x.ProductId));

            soldProducts.ToList()
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
            var getSalesOrder = _unitOfWork.SalesOrders.GetSalesOrderById(id, true, true, true);
            if (getSalesOrder.Status == "Open")
            {
                getSalesOrder.Status = "Completed";
                getSalesOrder.Date = date;
                var poi = getSalesOrder.SalesOrderItem;
                foreach (var product in poi)
                {
                    var total = product.Total;
                    var newProductHistory = new ProductHistory()
                    {
                        Name = getSalesOrder.Name,
                        SalesOrderId = getSalesOrder.SalesOrderId,
                        ProductId = product.ProductId,
                        IsActive = true,
                        Transac = "-" + total.ToString(),
                        Date = getSalesOrder.Date,
                    };
                    _unitOfWork.ProductHistories.Add(newProductHistory);
                }
                    _unitOfWork.Complete();
                return getSalesOrder;
            }
            else return null;
            
        }
        
        public SalesOrder ReturnSalesOrder(int id, DateTime date,string returnReason)
        {
            var salesOrder = _unitOfWork.SalesOrders.GetSalesOrderById(id, true, true, true);
            var product = _unitOfWork.ProductHistories.GetAll();
            var productHistory = product.Where(c => c.SalesOrderId == salesOrder.SalesOrderId);
      
            if (salesOrder.Status == "Completed")
            {
                salesOrder.Reason = returnReason;
                salesOrder.Status = "Returned";
                salesOrder.Date = date;

                var orderedProductIds = salesOrder.SalesOrderItem
                    .Select(x => x.ProductId);
                var orderedProducts = _unitOfWork.Products
                    .Find(x => orderedProductIds.Contains(x.ProductId));
                orderedProducts.ToList()
                    .ForEach(p => p.Quantity +=
                        salesOrder.SalesOrderItem.First(poi => poi.ProductId == p.ProductId).Quantity);

                foreach (var item in productHistory)
                {
                    item.IsActive = false;
                }
                _unitOfWork.Complete();
                return salesOrder;
            }
            else
                return null;
            
        }
        public SalesOrder CancelSalesOrder(int id, DateTime date)
        {
            var salesOrder = _unitOfWork.SalesOrders.GetSalesOrderById(id, true, true, true);
            if (salesOrder.Status == "Open")
            {
                salesOrder.Status = "Cancelled";
                salesOrder.Date = date;
                var orderedProductIds = salesOrder.SalesOrderItem
                    .Select(x => x.ProductId);
                var orderedProducts = _unitOfWork.Products
                    .Find(x => orderedProductIds.Contains(x.ProductId));
                orderedProducts.ToList()
                    .ForEach(p => p.Quantity +=
                        salesOrder.SalesOrderItem.First(poi => poi.ProductId == p.ProductId).Quantity);
                _unitOfWork.Complete();
                return salesOrder;
            }
            else
                return null;
            
        }
        public SalesOrder ReOpenSalesOrder(int id)
        {
            var product = _unitOfWork.ProductHistories.GetAll();
            var salesOrder = _unitOfWork.SalesOrders.GetSalesOrderById(id, true, true, true);
            var productHistory = product.Where(c => c.SalesOrderId == salesOrder.SalesOrderId);
            if (salesOrder.Status != "Open")
            {
                if (salesOrder.Status == "Cancelled" || salesOrder.Status == "Returned")
                {
                    var purchasedProductIds = salesOrder.SalesOrderItem
                .Select(x => x.ProductId);
                    var purchasedProducts = _unitOfWork.Products
                        .Find(x => purchasedProductIds.Contains(x.ProductId));

                    purchasedProducts.ToList()
                        .ForEach(p => p.Quantity -=
                            salesOrder.SalesOrderItem.First(poi => poi.ProductId == p.ProductId).Quantity);
                }
                foreach (var item in productHistory)
                {
                    item.IsActive = false;
                }
                salesOrder.Reason = null;
                salesOrder.Status = "Open";
                salesOrder.Date = salesOrder.DefaultDate;
                _unitOfWork.Complete();
                return salesOrder;
            }
            else return null;
            
        }
    }
}
