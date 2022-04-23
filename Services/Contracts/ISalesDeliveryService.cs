using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISalesDeliveryService
    {
        void UpdateSalesDelivery(SalesDelivery salesDelivery, int Id);
        SalesDelivery AddSalesDelivery(SalesDelivery salesDelivery);
        void DeleteSalesDelivery(int Id);

    }
}
