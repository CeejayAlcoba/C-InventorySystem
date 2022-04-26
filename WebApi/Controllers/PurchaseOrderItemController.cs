using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/purchaseorderitem")]
    [ApiController]
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
    }
}
