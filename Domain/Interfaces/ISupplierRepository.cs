using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Supplier getSupplierById(Supplier supplier);
    }
}
