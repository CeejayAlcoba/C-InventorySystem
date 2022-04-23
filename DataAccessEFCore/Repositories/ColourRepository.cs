using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class ColourRepository : GenericRepository<Colour>, IColourRepository
    {

        public ColourRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
