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
        [HttpGet]
        [Route("/api/purchaseorderitem/{id}")]
        public IActionResult PurchaseOrderItemList(int id)
        {
            try
            {
                var purchaseOrderItems = _unitOfWork.PurchaseOrderItems.GetPurchaseOrderItemById(id);
                return Ok(purchaseOrderItems);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
       
        
    }
}
