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
            throw new NotImplementedException();
        }

        public void DeleteSalesOrder(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSalesOrder(SalesOrder salesOrder, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
