using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISalesOrderItemService
    {
        void UpdateSalesOrderItem(SalesOrderItem salesOrderItem, int Id);
        SalesOrderItem AddSalesOrderItem(SalesOrderItem salesOrderItem);
        void DeleteSalesOrderItem(int Id);

    }
}
