using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Contructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public CustomerController(IAccountService accountService, ICustomerService customerService, IUnitOfWork unitOfWork, IProductService productService)
        {
            _accountService = accountService;
            _productService = productService;
            _customerService = customerService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult CustomerList()
        { 
            var getAllCustomer = _unitOfWork.Customers.GetAll();
            return Ok(getAllCustomer);
        }
        [HttpPost]
        public IActionResult CustomerAdd([FromBody] Customer customer)
        {
            _customerService.AddCustomer(customer);
            return Ok();
        }
        [HttpPatch]
        public IActionResult CustomerUpdate([FromBody] Customer customer)
        {
            _customerService.UpdateCustomer(customer);
            return Ok();
        }
        [HttpDelete]
        public IActionResult CustomerDelete([FromBody] Customer customer)
        {
            _customerService.DeleteCustomer(customer);
            return Ok();
        }
    }
}
