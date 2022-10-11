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
    [Route("api/purchasereturn")]
    [ApiController]
    [Authorize]
    public class PurchaseReturnController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPurchaseReturnService _purchaseReturnService;
        public PurchaseReturnController(IUnitOfWork unitOfWork, IPurchaseReturnService purchaseReturnService)
        {
            _purchaseReturnService = purchaseReturnService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public IActionResult PurchaseReturnList()
        {
            var purchaseReturns = _unitOfWork.PurchaseOrders.GetAllPurchase(true,true,"Returned",false);
            return Ok(purchaseReturns);
        }
        [HttpPost]

        public IActionResult AddPurchaseReturn(int id, [FromBody] PurchaseReturn purchaseReturn)
        {
            try
            {
                var addPurchaseReturn = _purchaseReturnService.AddPurchaseReturn(purchaseReturn);
                return Ok(addPurchaseReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpPatch]
        [Route("/api/purchasereturn/id/{id}")]
        public IActionResult UpdatePurchaseReturn(int id, [FromBody] PurchaseReturn purchaseReturn)
        {
            try
            {
                var getPurchaseReturn = _unitOfWork.PurchaseReturns.GetById(id);
                _purchaseReturnService.UpdatePurchaseReturn(purchaseReturn, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/api/purchasereturn/id/{id}")]
        public IActionResult GetPurchaseReturn(int Id)
        {
            var purchaseReturn = _unitOfWork.PurchaseReturns.GetById(Id);
            return Ok(purchaseReturn);

        }
        [HttpDelete]
        [Route("/api/purchasereturn/id/{id}")]
        public IActionResult DeletePurchaseReturn(int Id)
        {
            try
            {
                var uom = _unitOfWork.PurchaseReturns.GetById(Id);
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
        [HttpGet]
        [Route("/api/purchasereturn/quantity")]
        public IActionResult GetTotalQuantity()
        {
            var totalQuantity = _unitOfWork.PurchaseOrders.GetPurchaseOrderItemsTotalQuantity("Returned");
            return Ok(totalQuantity);
        }
    }
}
