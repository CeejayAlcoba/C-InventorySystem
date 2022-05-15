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
        SalesOrder GetSalesOrder(int salesOrderId,
            bool includeCustomer, 
            bool includeSalesChannel, 
            bool includeSalesOrderItem,
            string status,
            bool isDelete);
        IEnumerable GetAllSalesOrder(bool includeCustomer, 
            bool includeSalesChannel, 
            bool includeSalesOrderItem,
            string status,
            bool isDelete);
        double GetSalesOrderItemsTotalQuantity(string status);
        IEnumerable GetDailySales(
               bool includeCustomer = false,
               bool includeSalesOrderItem = false,
               bool isDelete = false
               );
        int GetNextId();
    }
}
