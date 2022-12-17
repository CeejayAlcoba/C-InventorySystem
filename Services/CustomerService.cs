using Domain.Entities;
using Domain.Interfaces;
using Services.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly ISalesOrderService _salesOrderService;
        public CustomerService(IUnitOfWork unitOfWork,ICustomerRepository customerRepository,ISalesOrderService salesOrderService)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _salesOrderService = salesOrderService;
        }
       
        public void DeleteCustomer(int Id)
        {
            var customer = _unitOfWork.Customers.GetById(Id);
            var salesOrderList = _unitOfWork.SalesOrders.GetAll().Where(c => c.CustomerId == Id);
            if (customer.IsDelete == true)
            {
                customer.IsDelete = false;
            }
            else
            {
                customer.IsDelete = true;
                _salesOrderService.CancelSalesOrder(salesOrderList);
            }
            _unitOfWork.Complete();

        }
        public Customer AddCustomer(Customer customer)
        {
            var getItemByName = _customerRepository.GetCustomerByName(customer.Name);
            if (getItemByName == null || getItemByName.IsDelete == true)
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
            else return null;
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
