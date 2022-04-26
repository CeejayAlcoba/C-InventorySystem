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
    public class SalesDeliveryService : ISalesDeliveryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesDeliveryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public SalesDelivery AddSalesDelivery(SalesDelivery salesDelivery)
        {
            var newSalesDelivery = new SalesDelivery()
            {
                Description = salesDelivery.Description,
                DeliveryDate = salesDelivery.DeliveryDate,
                SalesOrderId = salesDelivery.SalesOrderId,
                ShipperId = salesDelivery.ShipperId,
                Location = salesDelivery.Location,
                Total = salesDelivery.Total
            };
            _unitOfWork.SalesDeliveries.Add(newSalesDelivery);
            _unitOfWork.Complete();
            return newSalesDelivery;
        }

        public void DeleteSalesDelivery(int Id)
        {
            var salesDelivery = _unitOfWork.SalesDeliveries.GetById(Id);
            _unitOfWork.SalesDeliveries.Remove(salesDelivery);
            _unitOfWork.Complete();
        }

        public void UpdateSalesDelivery(SalesDelivery salesDelivery, int Id)
        {
            var getSalesDelivery = _unitOfWork.SalesDeliveries.GetById(Id);
            getSalesDelivery.Description = salesDelivery.Description;
            getSalesDelivery.DeliveryDate = salesDelivery.DeliveryDate;
            getSalesDelivery.SalesOrderId = salesDelivery.SalesOrderId;
            getSalesDelivery.ShipperId = salesDelivery.ShipperId;
            getSalesDelivery.Location = salesDelivery.Location;
            getSalesDelivery.Total = salesDelivery.Total;
            _unitOfWork.Complete();
        }
    }
}
