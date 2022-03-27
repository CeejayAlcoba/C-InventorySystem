using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISaleService
    {
        Sale GetSale(int saleId);
        Sale AddSale(Sale sale);
        Sale UpdateSale(Sale sale);
        void DeleteSale(int saleId);
    }
}
