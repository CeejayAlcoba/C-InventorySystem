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
    public class SalesReturnService : ISalesReturnService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesReturnService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public SalesReturn AddSalesReturn(SalesReturn salesReturn)
        {
            var newSalesReturn = new SalesReturn()
            {
                Description = salesReturn.Description,
                ReturnDate = salesReturn.ReturnDate,
                SalesOrderId = salesReturn.SalesOrderId,
                Location = salesReturn.Location,
                Total = salesReturn.Total
            };
            _unitOfWork.SalesReturns.Add(newSalesReturn);
            _unitOfWork.Complete();
            return newSalesReturn;

        }

        public void DeleteSalesReturn(int Id)
        {
            var salesReturn = _unitOfWork.SalesReturns.GetById(Id);
            _unitOfWork.SalesReturns.Remove(salesReturn);
            _unitOfWork.Complete();
        }

        public void UpdateSalesReturn(SalesReturn salesReturn, int Id)
        {
            var getSalesReturn = _unitOfWork.SalesReturns.GetById(Id);
            getSalesReturn.Description = salesReturn.Description;
            getSalesReturn.ReturnDate = salesReturn.ReturnDate;
            getSalesReturn.SalesOrderId = salesReturn.SalesOrderId;
            getSalesReturn.Location = salesReturn.Location;
            getSalesReturn.Total = salesReturn.Total;
            _unitOfWork.Complete();
        }
    }
}
