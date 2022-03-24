﻿using Domain.Entities;
using Domain.Interfaces;
using Services.Contracts;
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

        public void UpdateCustomer(Customer newCustomer)
        {
            var customer = _unitOfWork.Customers.GetById(newCustomer.CustomerId);
            customer.CustomerName = newCustomer.CustomerName;
            customer.Address = newCustomer.Address;
            customer.ContactNumber = newCustomer.ContactNumber;

            _unitOfWork.Complete();
        }
    }
}
