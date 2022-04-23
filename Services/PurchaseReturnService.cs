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
    public class PurchaseReturnService : IPurchaseReturnService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseReturnService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public PurchaseReturn AddPurchaseReturn(PurchaseReturn purchaseReturn)
        {
            throw new NotImplementedException();
        }

        public void DeletePurchaseReturn(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePurchaseReturn(PurchaseReturn purchaseReturn, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
