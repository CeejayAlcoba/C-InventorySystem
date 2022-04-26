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
        public SalesDeliveryItem AddSalesDeliveryItem(SalesDeliveryItem salesDeliveryItem)
        {
            var newSalesDeliveryItem = new SalesDeliveryItem()
            {

            };
            _unitOfWork.SalesDeliveryItems.Add(newSalesDeliveryItem);
            _unitOfWork.Complete();
            return newSalesDeliveryItem;
        }

        public void DeleteSalesDeliveryItem(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSalesDeliveryItem(SalesDeliveryItem salesDeliveryItem, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
