using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class ShipperRepository : GenericRepository<Shipper>, IShipperRepository
    {

        public ShipperRepository(ApplicationContext context) : base(context)
        {
        }

        public Shipper GetShipperByName(string name)
        {
            return _context.Shippers.FirstOrDefault(x => x.Name == name);
        }
    }
}
