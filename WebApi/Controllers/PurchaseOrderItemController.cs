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
    [Route("api/purchaseorderitem")]
    [ApiController]
    [Authorize]
    public class PurchaseOrderItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPurchaseOrderItemService _purchaseOrderItemService;
        public PurchaseOrderItemController(IUnitOfWork unitOfWork, IPurchaseOrderItemService purchaseOrderItemService)
        {

            _purchaseOrderItemService = purchaseOrderItemService;

            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("/api/purchaseorderitem/{id}")]
        public IActionResult AddPurchaseOrderItem(int id,[FromBody] PurchaseOrderItem purchaseOrderItem)
        {
            try
            {
                var addPurchaseOrderItem = _purchaseOrderItemService.AddPurchaseOrderItem(purchaseOrderItem,id);
                return Ok(addPurchaseOrderItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpGet]

        public IActionResult PurchaseOrderItemList()
        {
            var purchaseOrderItems = _unitOfWork.PurchaseOrderItems.GetAll();
            return Ok(purchaseOrderItems);
        }
       
        [HttpPatch]
        [Route("/api/purchaseorderitem/id/{id}")]
        public IActionResult UpdatePurchaseOrderItem(int Id, [FromBody] PurchaseOrderItem purchaseOrderItem)
        {
            try
            {
                var getPurchaseOrderItem = _unitOfWork.PurchaseOrderItems.GetById(Id);
                _purchaseOrderItemService.UpdatePurchaseOrderItem(purchaseOrderItem, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/api/purchaseorderitem/id/{id}")]
        public IActionResult GetPurchaseOrderItem(int Id)
        {
            var purchaseOrderItem = _unitOfWork.PurchaseOrderItems.GetById(Id);
            return Ok(purchaseOrderItem);

        }
        [HttpDelete]
        [Route("/api/purchaseorderitem/id/{id}")]
        public IActionResult DeletePurchaseOrderItem(int Id)
        {
            try
            {
                _purchaseOrderItemService.DeletePurchaseOrderItem(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
