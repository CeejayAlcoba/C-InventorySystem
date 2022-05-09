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

        public IActionResult AddPurchaseOrder([FromBody] PurchaseOrder purchaseOrder)
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
        [HttpPatch]
        [Route("/api/purchaseorder/id/{id}")]
        public IActionResult UpdatePurchaseOrder(int Id, [FromBody] PurchaseOrder purchaseOrder)
        {
            try
            {
                var getPurchaseOrder = _unitOfWork.PurchaseOrders.GetById(Id);
                _purchaseOrderService.UpdatePurchaseOrder(purchaseOrder, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/api/purchaseorder/id/{id}")]
        public IActionResult GetPurchaseOrder(int Id)
        {
            var purchaseOrder = _unitOfWork.PurchaseOrders.GetById(Id);
            return Ok(purchaseOrder);

        }
        [HttpDelete]
        [Route("/api/purchaseorder/id/{id}")]
        public IActionResult DeletePurchaseOrder(int Id)
        {
            try
            {
                _purchaseOrderService.DeletePurchaseOrder(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
