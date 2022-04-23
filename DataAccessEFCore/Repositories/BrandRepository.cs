using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {

        public BrandRepository(ApplicationContext context) : base(context)
        {
        }

        public Brand GetBrandByName(string name)
        {
            return _context.Brands.FirstOrDefault(x => x.Name == name);
        }
    }
}
