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
        

    }
}
