using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface  ISupplierService
    {
        void UpdateSupplier(Supplier supplier);
        void AddSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
    }
}
