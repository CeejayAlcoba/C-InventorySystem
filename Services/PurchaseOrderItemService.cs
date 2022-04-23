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
    public class PurchaseOrderItemService : IPurchaseOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public PurchaseOrderItem AddPurchaseOrderItem(PurchaseOrderItem purchaseOrderItem)
        {
            throw new NotImplementedException();
        }

        public void DeletePurchaseOrderItem(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePurchaseOrderItem(PurchaseOrderItem purchaseOrderItem, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
