using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPurchaseOrderItemRepository : IGenericRepository<PurchaseOrderItem>
    {
        IEnumerable GetPurchaseOrderItemById(int Id);
    }
}
