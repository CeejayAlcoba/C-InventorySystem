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
            throw new NotImplementedException();
        }

        public void DeleteSalesReturn(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSalesReturn(SalesReturn salesReturn, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
