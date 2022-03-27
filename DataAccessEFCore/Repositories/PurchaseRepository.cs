using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessEFCore.Repositories
{
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(ApplicationContext context) : base(context)
        {
        }

        public Purchase GetPurchase(
            int purchaseId, 
            bool includeSupplier = false, 
            bool includeProduct = false)
        {
            var query = _context.Purchases.AsQueryable();

            if (includeSupplier)
                query = query.Include(x => x.Supplier);

            if (includeProduct)
                query = query.Include(x => x.Product);

            return query.FirstOrDefault(x => x.PurchaseId == purchaseId);
        }
    }
}
