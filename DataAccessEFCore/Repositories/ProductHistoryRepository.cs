using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class ProductHistoryRepository : GenericRepository<ProductHistory>, IProductHistoryRepository
    {

        public ProductHistoryRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
