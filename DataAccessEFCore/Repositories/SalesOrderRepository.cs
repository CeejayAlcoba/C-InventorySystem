using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class SalesOrderRepository : GenericRepository<SalesOrder>, ISalesOrderRepository
    {

        public SalesOrderRepository(ApplicationContext context) : base(context)
        {
        }

    }
}

