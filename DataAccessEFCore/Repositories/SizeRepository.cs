using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class SizeRepository : GenericRepository<Size>, ISizeRepository
    {

        public SizeRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
