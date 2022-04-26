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
    [Route("api/purchaseorder")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        public PurchaseOrderController(IUnitOfWork unitOfWork, IPurchaseOrderService purchaseOrderService, IPurchaseOrderRepository purchaseOrderRepository)
        {

            _purchaseOrderService = purchaseOrderService;
            _purchaseOrderRepository = purchaseOrderRepository;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public IActionResult PurchaseOrderList()
        {
            var purchaseOrders = _purchaseOrderRepository.GetAllPurchase(true,true);
            return Ok(purchaseOrders);
        }
        [HttpPost]
       
        public IActionResult AddPurchaseOrder(int id,[FromBody] PurchaseOrder purchaseOrder)
        {
            try
            {
                var addPurchaseOrder = _purchaseOrderService.AddPurchaseOrder(purchaseOrder);
                return Ok(addPurchaseOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }


        }
    }
}
