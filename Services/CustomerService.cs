using Domain.Entities;
using Domain.Interfaces;
using Services.Contructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }
        public void AddCustomer(Customer customer)
        {
            var newCustomer = new Customer()
            {
                CustomerName = customer.CustomerName,
                Address = customer.Address,
                ContactNumber=customer.ContactNumber    
            };
            _unitOfWork.Customers.Add(newCustomer);
            _unitOfWork.Complete();
        }

        public void DeleteCustomer(Customer customer)
        {
            var getCustomerById = _unitOfWork.Customers.GetById(customer.CustomerId);
            _unitOfWork.Customers.Remove(getCustomerById);
            _unitOfWork.Complete();
        }

        public void UpdateCustomer(Customer customer)
        {
            var getCustomerById = _unitOfWork.Customers.GetById(customer.CustomerId);
            getCustomerById.CustomerName = customer.CustomerName;
            getCustomerById.Address = customer.Address;
            getCustomerById.ContactNumber = customer.ContactNumber;
            _unitOfWork.Complete();
        }
    }
}
