using Domain.Entities;
using Domain.Interfaces;
using Services.Contracts;

namespace Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PurchaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Purchase GetPurchase(int purchaseId)
        {
            return _unitOfWork.Purchases.GetPurchase(purchaseId);
        }
    }
}
