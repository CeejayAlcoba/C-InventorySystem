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
       
        public void DeleteCustomer(int Id)
        {
            var customer = _unitOfWork.Customers.GetById(Id);
            _unitOfWork.Customers.Remove(customer);
            _unitOfWork.Complete();

        }
        public Customer AddCustomer(Customer customer)
        {
            var getCustomer = _unitOfWork.Customers.GetCustomerByName(customer.Name);
            if (getCustomer == null)
            {
                var newCustomer = new Customer()
                {
                    Name = customer.Name,
                    Description = customer.Description,
                    Street = customer.Street,
                    City = customer.City,
                    State = customer.State,
                    Phone = customer.Phone,
                    Email = customer.Email
                };
                _unitOfWork.Customers.Add(newCustomer);
                _unitOfWork.Complete();
                return newCustomer;
            }
            return null;


        }

        public void UpdateCustomer(Customer customer, int Id)
        {
            var getCustomer = _unitOfWork.Customers.GetById(Id);
            getCustomer.Name = customer.Name;
            getCustomer.Description = customer.Description;
            getCustomer.Street = customer.Street;
            getCustomer.City = customer.City;
            getCustomer.State = customer.State;
            getCustomer.Phone = customer.Phone;
            getCustomer.Email = customer.Email;
            _unitOfWork.Complete();

        }
    }
}
