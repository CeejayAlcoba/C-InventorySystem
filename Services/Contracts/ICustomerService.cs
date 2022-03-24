using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICustomerService
    {
        void UpdateCustomer(Customer customer);
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
