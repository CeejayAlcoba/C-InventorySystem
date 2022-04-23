using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISalesChannelService
    {
        void UpdateSalesChannel(SalesChannel salesChannel, int Id);
        SalesChannel AddSalesChannel(SalesChannel salesChannel);
        void DeleteSalesChannel(int Id);

    }
}
