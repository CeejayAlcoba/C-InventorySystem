using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISalesOrderItemRepository : IGenericRepository<SalesOrderItem>
    {
        IEnumerable GetSsalesOrderItemById(int Id);
    }
    
}
