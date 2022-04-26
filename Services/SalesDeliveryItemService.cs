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
    public class SalesDeliveryItemService : ISalesDeliveryItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesDeliveryItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public SalesDeliveryItem AddSalesDeliveryItem(SalesDeliveryItem salesDeliveryItem, int salesDeliveryId)
        {
            var newSalesDeliveryItem = new SalesDeliveryItem()
            {
                SalesDeliveryId= salesDeliveryId,
                ProductId = salesDeliveryItem.ProductId,
                Quantity = salesDeliveryItem.Quantity
            };
            _unitOfWork.SalesDeliveryItems.Add(newSalesDeliveryItem);
            _unitOfWork.Complete();
            return newSalesDeliveryItem;
        }

        public void DeleteSalesDeliveryItem(int Id)
        {
            var salesDeliveryItem = _unitOfWork.SalesDeliveryItems.GetById(Id);
            _unitOfWork.SalesDeliveryItems.Remove(salesDeliveryItem);
            _unitOfWork.Complete();
        }

        public void UpdateSalesDeliveryItem(SalesDeliveryItem salesDeliveryItem, int Id)
        {
            var getSalesDeliveryItem = _unitOfWork.SalesDeliveryItems.GetById(Id);
            getSalesDeliveryItem.ProductId = salesDeliveryItem.ProductId;
            getSalesDeliveryItem.Quantity = salesDeliveryItem.Quantity;
            _unitOfWork.Complete();
        }
    }
}
