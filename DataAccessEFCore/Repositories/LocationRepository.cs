using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {

        public LocationRepository(ApplicationContext context) : base(context)
        {
        }

        public Location GetLocationByName(string name)
        {
            return _context.Locations.FirstOrDefault(x => x.Name == name);
        }
    }
}
