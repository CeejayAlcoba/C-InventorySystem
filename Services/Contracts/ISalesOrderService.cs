using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISalesOrderService
    {
        void UpdateSalesOrder(SalesOrder salesOrder, int Id);
        SalesOrder AddSalesOrder(SalesOrder salesOrder);
        void DeleteSalesOrder(int Id);

    }
}
