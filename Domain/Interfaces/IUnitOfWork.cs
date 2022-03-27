﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        ISupplierRepository Suppliers { get; }
        ICustomerRepository Customers { get; }

        IPurchaseRepository Purchases { get; }
        ISaleRepository Sales { get; }
        int Complete();
    }
}
