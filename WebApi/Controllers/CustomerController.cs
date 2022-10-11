using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Auth;

namespace WebApi.Controllers
{
    [Route("api/customer")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerService _customerService;
        public CustomerController(IUnitOfWork unitOfWork, ICustomerService customerService)
        {
            _customerService = customerService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult CustomerList()
        {
            var customer = _unitOfWork.Customers.GetAll();
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            var getCustomer = _customerService.AddCustomer(customer);
            if (getCustomer != null)
            {
                return Ok(getCustomer);
            }
            return BadRequest("Name is already exist");

        }
        [HttpPatch]
        [Route("/api/customer/id/{id}")]
        public IActionResult UpdateCustomer(int Id, [FromBody] Customer customer)
        {
            var customerId = _unitOfWork.Customers.GetById(Id);
            var getCustomer = _unitOfWork.Customers.GetCustomerByName(customer.Name);
            if (customerId.Name != customer.Name)
            {
                if (getCustomer == null)
                {
                    _customerService.UpdateCustomer(customer, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Name is already exist");
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
        public IActionResult DeleteCustomer(int Id)
        {
            try
            {
                var uom = _unitOfWork.Customers.GetById(Id);
                if (uom.IsDelete == true)
                {
                    uom.IsDelete = false;
                    _unitOfWork.Complete();
                }
                else
                {
                    uom.IsDelete = true;
                    _unitOfWork.Complete();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
