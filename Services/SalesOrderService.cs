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
            var newSalesOrder = new SalesOrder()
            {
                Description = salesOrder.Description,
                OrderDate = salesOrder.OrderDate,
                CustomerId=salesOrder.CustomerId,
                SalesChannelId = salesOrder.SalesOrderId
            };
            _unitOfWork.SalesOrders.Add(newSalesOrder);
            _unitOfWork.Complete();
            return newSalesOrder;
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
            getSalesOrder.OrderDate = salesOrder.OrderDate;
            getSalesOrder.CustomerId = salesOrder.CustomerId;
            getSalesOrder.SalesChannelId = salesOrder.SalesOrderId;
            _unitOfWork.Complete();
        }
    }
}
