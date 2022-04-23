using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISalesDeliveryItemService
    {
        void UpdateSalesDeliveryItem(SalesDeliveryItem salesDeliveryItem, int Id);
        SalesDeliveryItem AddSalesDeliveryItem(SalesDeliveryItem salesDeliveryItem);
        void DeleteSalesDeliveryItem(int Id);

    }
}
