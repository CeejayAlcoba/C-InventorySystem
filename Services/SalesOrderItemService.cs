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
        public SalesOrderItem AddSalesOrderItem(SalesOrderItem salesOrderItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteSalesOrderItem(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSalesOrderItem(SalesOrderItem salesOrderItem, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
