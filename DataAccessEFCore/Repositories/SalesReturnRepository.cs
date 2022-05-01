using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class SalesReturnRepository : GenericRepository<SalesReturn>, ISalesReturnRepository
    {

        public SalesReturnRepository(ApplicationContext context) : base(context)
        {
        }
        public double GetTotalQuantity()
        {
            var salesReturns = GetAll();
            var totalQuantity = salesReturns.Select(c => c.Total).Sum();
            return totalQuantity;
        }
    }
}
