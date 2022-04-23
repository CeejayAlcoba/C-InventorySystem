using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISupplierService
    {
        void UpdateSupplier(Supplier supplier, int Id);
        Supplier AddSupplier(Supplier supplier);
        void DeleteSupplier(int Id);

    }
}
