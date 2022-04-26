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
    public class SalesOrderItemService : ISalesOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesOrderItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public SalesOrderItem AddSalesOrderItem(SalesOrderItem salesOrderItem,int salesOrderId)
        {

            var newSalesOrderItem = new SalesOrderItem()
            {
                SalesOrderId=salesOrderId,
                ProductId = salesOrderItem.ProductId,
                Price = salesOrderItem.Price,
                Quantity=salesOrderItem.Quantity,
                DiscountAmount=salesOrderItem.DiscountAmount,
                SubTotal=salesOrderItem.SubTotal,
                BeforeTax= salesOrderItem.BeforeTax,
                TaxAmount=salesOrderItem.TaxAmount,
                Total = salesOrderItem.Total
            };
            _unitOfWork.SalesOrderItems.Add(newSalesOrderItem);
            _unitOfWork.Complete();
            return newSalesOrderItem;
        }

        public void DeleteSalesOrderItem(int Id)
        {
            var salesOrderItem = _unitOfWork.SalesOrderItems.GetById(Id);
            _unitOfWork.SalesOrderItems.Remove(salesOrderItem);
            _unitOfWork.Complete();
        }

        public void UpdateSalesOrderItem(SalesOrderItem salesOrderItem, int Id)
        {
            var getSalesOrderItem = _unitOfWork.SalesOrderItems.GetById(Id);
            getSalesOrderItem.ProductId = salesOrderItem.ProductId;
            getSalesOrderItem.Price = salesOrderItem.Price;
            getSalesOrderItem.Quantity = salesOrderItem.Quantity;
            getSalesOrderItem.DiscountAmount = salesOrderItem.DiscountAmount;
            getSalesOrderItem.SubTotal = salesOrderItem.SubTotal;
            getSalesOrderItem.BeforeTax = salesOrderItem.BeforeTax;
            getSalesOrderItem.TaxAmount = salesOrderItem.TaxAmount;
            getSalesOrderItem.Total = salesOrderItem.Total;
            _unitOfWork.Complete();
        }
    }
}
