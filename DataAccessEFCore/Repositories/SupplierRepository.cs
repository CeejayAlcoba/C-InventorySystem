using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {

        public SupplierRepository(ApplicationContext context) : base(context)
        {
        }

        public Supplier GetSupplierByName(string name)
        {
            return _context.Suppliers.FirstOrDefault(x => x.Name == name);
        }
    }
}
