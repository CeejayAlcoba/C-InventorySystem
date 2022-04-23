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
            throw new NotImplementedException();
        }

        public void DeleteSalesDelivery(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSalesDelivery(SalesDelivery salesDelivery, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
