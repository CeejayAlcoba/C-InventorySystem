using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;

namespace WebApi.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        public CustomerController(
            IAccountService accountService, 
            ICustomerService customerService, 
            IUnitOfWork unitOfWork, 
            IProductService productService)
        {
            _accountService = accountService;
            _productService = productService;
            _customerService = customerService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult CustomerList()
        { 
            var result = _unitOfWork.Customers.GetAll();

            return Ok(result);
        }
        [HttpPost]
        public IActionResult CustomerAdd([FromBody] Customer customer)
        {
            _customerService.AddCustomer(customer);
            return Ok(customer);
        }
        [HttpPatch]
        [Route("/api/customer/id/{id}")]
        public IActionResult UpdateCustomer(int Id, [FromBody] Customer customer)
        {
            var customerId = _unitOfWork.Customers.GetById(Id);
            var getCustomer = _unitOfWork.Customers.GetCustomerByName(customer.CustomerName);
            if (customerId.CustomerName != customer.CustomerName)
            {
                if (getCustomer == null)
                {
                    _customerService.UpdateCustomer(customer, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Customer name is already exist");
                }

            }
            else
            {
                _customerService.UpdateCustomer(customer, Id);
                return Ok();
            }

        }
        [HttpGet]
        [Route("/api/customer/id/{id}")]
        public IActionResult GetCustomer(int Id)
        {
            var customer = _unitOfWork.Customers.GetById(Id);

            return Ok(customer);
        }
        [HttpDelete]
        [Route("/api/customer/id/{id}")]
        public IActionResult CustomerDelete(int Id)
        {
            try
            {
                _customerService.DeleteCustomer(Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
          
        }
    }
}
