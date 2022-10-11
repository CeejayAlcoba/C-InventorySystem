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
            return BadRequest("Name is already exist");

        }
        [HttpPatch]
        [Route("/api/supplier/id/{id}")]
        public IActionResult UpdateSupplier(int Id, [FromBody] Supplier supplier)
        {
            var supplierId = _unitOfWork.Suppliers.GetById(Id);
            var getSupplier = _unitOfWork.Suppliers.GetSupplierByName(supplier.Name);
            if (supplierId.Name != supplier.Name)
            {
                if (getSupplier == null)
                {
                    _supplierService.UpdateSupplier(supplier, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Name is already exist");
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
            var getSupplier = _unitOfWork.Suppliers.GetById(Id);
            return Ok(getSupplier);

        }
        [HttpDelete]
        [Route("/api/supplier/id/{id}")]
        public IActionResult DeleteSupplier(int Id)
        {
            try
            {
                var uom = _unitOfWork.Suppliers.GetById(Id);
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
