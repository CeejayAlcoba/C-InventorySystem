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
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public PurchaseOrder AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            throw new NotImplementedException();
        }

        public void DeletePurchaseOrder(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePurchaseOrder(PurchaseOrder purchaseOrder, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
