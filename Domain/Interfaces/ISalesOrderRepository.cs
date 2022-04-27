using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISalesOrderRepository : IGenericRepository<SalesOrder>
    {
        SalesOrder GetSalesOrder(int salesOrderId, bool includeCustomer, bool includeSalesChannel, bool includeSalesOrderItem);
        IEnumerable GetAllSalesOrder(bool includeCustomer, bool includeSalesChannel, bool includeSalesOrderItem);
    }
}
