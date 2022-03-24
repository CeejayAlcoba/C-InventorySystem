using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

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
        [HttpPut]
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
