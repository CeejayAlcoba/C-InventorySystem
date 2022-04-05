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
        [Route("/api/supplier/id/{id}")]
        public IActionResult SupplierDelete(int Id)
        {
            _supplierService.DeleteSupplier(Id);
            return Ok();
        }
        [HttpPatch]
        [Route("/api/supplier/id/{id}")]
        public IActionResult UpdateSupplier(int Id, [FromBody] Supplier supplier)
        {
            var supplierId = _unitOfWork.Suppliers.GetById(Id);
            var getSupplier = _unitOfWork.Suppliers.GetSupplierByName(supplier.SupplierName);
            if (supplierId.SupplierName != supplier.SupplierName)
            {
                if (getSupplier == null)
                {
                    _supplierService.UpdateSupplier(supplier, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Product name is already exist");
                }

            }
            else
            {
                _supplierService.UpdateSupplier(supplier, Id);
                return Ok();
            }

        }
        [HttpGet]
        [Route("/api/supplier/id/{id}")]
        public IActionResult GetSupplier(int Id)
        {
            var supplier = _unitOfWork.Suppliers.GetById(Id);
            return Ok(supplier);
        }
        [HttpGet]
        public IActionResult SupplierList()
        {
            var getAllSupplier=_unitOfWork.Suppliers.GetAll();
            return Ok(getAllSupplier);
        }
    }
}
