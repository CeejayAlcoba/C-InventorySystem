﻿using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class SalesChannelRepository : GenericRepository<SalesChannel>, ISalesChannelRepository
    {

        public SalesChannelRepository(ApplicationContext context) : base(context)
        {
        }

        public SalesChannel GetSalesChannelByName(string name)
        {
             return _context.SalesChannels.FirstOrDefault(x => x.Name == name);
        }
    }
}
