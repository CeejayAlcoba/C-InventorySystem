using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class SalesDeliveryRepository : GenericRepository<SalesDelivery>, ISalesDeliveryRepository
    {

        public SalesDeliveryRepository(ApplicationContext context) : base(context)
        {
        }

        public double GetTotalQuantity()
        {
            var salesDeliveries = GetAll();
            var totalQuantity = salesDeliveries.Select(c => c.Total).Sum();
            return totalQuantity;
        }
    }
}
