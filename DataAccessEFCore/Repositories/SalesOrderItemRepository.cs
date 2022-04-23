using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class SalesOrderItemRepository : GenericRepository<SalesOrderItem>, ISalesOrderItemRepository
    {

        public SalesOrderItemRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
