using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPurchaseRepository : IGenericRepository<Purchase>
    {
        Purchase GetPurchase(int purchaseId, bool includeSupplier = false, bool includeProduct = false);
        IEnumerable GetAllPurchase(bool includeSupplier = false, bool includeProduct = false);
    }
}
