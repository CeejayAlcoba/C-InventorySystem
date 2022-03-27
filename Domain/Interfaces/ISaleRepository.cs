using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Sale GetPurchase(int saleId, bool includeCustomer = false, bool includeProduct = false);

    }
}
