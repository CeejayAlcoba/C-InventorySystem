using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class PurchaseReceiptRepository : GenericRepository<PurchaseReceipt>, IPurchaseReceiptRepository
    {

        public PurchaseReceiptRepository(ApplicationContext context) : base(context)
        {
        }
        public double GetTotalQuantity()
        {
            var purchaseReciepts = GetAll();
            var TotalQuantity = purchaseReciepts.Select(c => c.Total).Sum();
            return TotalQuantity;
        }

    }
}
