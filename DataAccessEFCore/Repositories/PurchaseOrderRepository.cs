using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>, IPurchaseOrderRepository
    {

        public PurchaseOrderRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
