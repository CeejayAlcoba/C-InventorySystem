using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class UomRepository : GenericRepository<Uom>, IUomRepository
    {

        public UomRepository(ApplicationContext context) : base(context)
        {
        }

        public Uom GetUomByName(string name)
        {
            return _context.Uoms.FirstOrDefault(x => x.Name == name);
        }
    }
}
