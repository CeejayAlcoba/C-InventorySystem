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
            var purchaseOrders = _purchaseOrderRepository.GetAllPurchase(true,true,"",false);
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
        [Route("/api/purchaseorder/complete/{id}/{date}")]
        public IActionResult CompletePurchaseOrder(int Id, DateTime Date)
        {
            try
            {
                var order = _purchaseOrderService.CompletePurchaseOrder(Id, Date);
                if (order != null)
                {
                    return Ok(order);
                }
                else return BadRequest();
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpPatch]
        [Route("/api/purchaseorder/return/{id}/{date}")]
        public IActionResult ReturnPurchaseOrder(int Id, DateTime Date)
        {
            try
            {
                var order = _purchaseOrderService.ReturnPurchaseOrder(Id, Date);
                if (order != null)
                {
                    return Ok(order);
                }
                else return BadRequest();
            }

            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpPatch]
        [Route("/api/purchaseorder/cancel/{id}/{date}")]
        public IActionResult CancelPurchaseOrder(int Id, DateTime Date)
        {
            try
            {
                var order = _purchaseOrderService.CancelPurchaseOrder(Id, Date);
                if (order != null)
                {
                    return Ok(order);
                }
                else return BadRequest();
            }

            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpPatch]
        [Route("/api/purchaseorder/reopen/{id}")]
        public IActionResult ReopenPurchaseOrder(int Id)
        {
            try
            {
                var order = _purchaseOrderService.ReOpenPurchaseOrder(Id);
                if (order != null)
                {
                    return Ok(order);
                }
                else return BadRequest();
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
            var purchaseReceipt = _unitOfWork.PurchaseOrders.GetPurchaseById(Id, true, true);
            return Ok(purchaseReceipt);

        }
        [HttpGet]
        [Route("/api/purchaseorder/deleted")]
        public IActionResult GetPurchaseOrderDeletedList(int Id)
        {
            var purchaseOrder = _unitOfWork.PurchaseOrders.GetAllPurchase(true, true, "Open", true);
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
        [HttpGet]
        [Route("/api/purchaseorder/open")]
        public IActionResult GetPurchaseOrderOpenList()
        {
            var purchaseOrder = _unitOfWork.PurchaseOrders.GetAllPurchase(true, true, "Open", false);
            return Ok(purchaseOrder);
        }
        [HttpGet]
        [Route("/api/purchaseorder/completed")]
        public IActionResult GetPurchaseOrderCompletedList()
        {
            var purchaseOrder = _unitOfWork.PurchaseOrders.GetAllPurchase(true, true, "Completed", false);
            return Ok(purchaseOrder);
        }
        [HttpGet]
        [Route("/api/purchaseorder/returned")]
        public IActionResult GetPurchaseReturnedOpenList()
        {
            var purchaseOrder = _unitOfWork.PurchaseOrders.GetAllPurchase(true, true, "Returned", false);
            return Ok(purchaseOrder);
        }
        [HttpGet]
        [Route("/api/purchaseorder/dailypurchases")]
        public IActionResult GetDailyPurchases()
        {
                var dailyPurchases = _unitOfWork.PurchaseOrders.GetDailyPurchase(true, true, false);
                return Ok(dailyPurchases);           
        }
    }
}
