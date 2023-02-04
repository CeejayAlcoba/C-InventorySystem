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
    [Route("api/supplier")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierService _supplierService;
        public SupplierController(IUnitOfWork unitOfWork, ISupplierService supplierService)
        {
            _supplierService = supplierService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult SupplierList()
        {
            var suppliers = _unitOfWork.Suppliers.GetAll();
            return Ok(suppliers);
        }
        [HttpPost]
        public IActionResult AddSupplier([FromBody] Supplier supplier)
        {
            var getSupplier = _supplierService.AddSupplier(supplier);
            if (getSupplier != null)
            {
                return Ok(getSupplier);
            }
            return BadRequest("Name already exists");

        }
        [HttpPatch]
        [Route("/api/supplier/id/{id}")]
        public IActionResult UpdateSupplier(int Id, [FromBody] Supplier supplier)
        {
            try
            {
                var updateSupplier=_supplierService.UpdateSupplier(supplier, Id);
                if (updateSupplier != null)
                {
                    return Ok(updateSupplier);
                }
                else return BadRequest("Supplier Name already exists.");
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet]
        [Route("/api/supplier/id/{id}")]
        public IActionResult GetSupplier(int Id)
        {
            var getSupplier = _unitOfWork.Suppliers.GetById(Id);
            return Ok(getSupplier);

        }
        [HttpDelete]
        [Route("/api/supplier/id/{id}")]
        public IActionResult DeleteSupplier(int Id)
        {
            try
            {
                _supplierService.DeleteSupplier(Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
