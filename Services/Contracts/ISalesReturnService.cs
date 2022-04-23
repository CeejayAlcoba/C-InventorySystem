using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISalesReturnService
    {
        void UpdateSalesReturn(SalesReturn salesReturn, int Id);
        SalesReturn AddSalesReturn(SalesReturn salesReturn);
        void DeleteSalesReturn(int Id);

    }
}
