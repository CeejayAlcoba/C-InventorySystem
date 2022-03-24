using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ISupplierService _supplierService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        public SupplierController(IAccountService accountService, ISupplierService supplierService, IUnitOfWork unitOfWork, IProductService productService)
        {
            _accountService = accountService;
            _productService = productService;
            _supplierService = supplierService;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult SupplierAdd([FromBody] Supplier supplier)
        {
            _supplierService.AddSupplier(supplier);
            return Ok();

        }
        [HttpDelete]
        public IActionResult SupplierDelete([FromBody] Supplier supplier)
        {
            _supplierService.DeleteSupplier(supplier);
            return Ok();
        }
        [HttpPatch]
        public IActionResult SupplierUpdate([FromBody] Supplier supplier)
        {
            _supplierService.UpdateSupplier(supplier);
            return Ok();
        }
        [HttpGet]
        public IActionResult SupplierList([FromBody] Supplier supplier)
        {
            var getAllSupplier=_unitOfWork.Suppliers.GetAll();
            return Ok(getAllSupplier);
        }
    }
}
