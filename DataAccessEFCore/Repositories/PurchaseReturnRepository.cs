using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class PurchaseReturnRepository : GenericRepository<PurchaseReturn>, IPurchaseReturnRepository
    {

        public PurchaseReturnRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
