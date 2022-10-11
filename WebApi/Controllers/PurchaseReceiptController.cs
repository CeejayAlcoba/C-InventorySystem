﻿using Domain.Entities;
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
    [Route("api/purchasereceipt")]
    [ApiController]
    [Authorize]
    public class PurchaseReceiptController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPurchaseReceiptService _purchaseReceiptService;
        public PurchaseReceiptController(IUnitOfWork unitOfWork, IPurchaseReceiptService purchaseReceiptService)
        {
            _purchaseReceiptService = purchaseReceiptService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public IActionResult PurchaseReceiptList()
        {
            var purchaseReceipts = _unitOfWork.PurchaseOrders.GetAllPurchase(true, true, "Completed", false);
            return Ok(purchaseReceipts);
        }
        [HttpPost]

        public IActionResult AddPurchaseReceipt(int id, [FromBody] PurchaseReceipt purchaseReceipt)
        {
            try
            {
                var addPurchaseReceipt = _purchaseReceiptService.AddPurchaseReceipt(purchaseReceipt);
                return Ok(addPurchaseReceipt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpPatch]
        [Route("/api/purchasereceipt/id/{id}")]
        public IActionResult UpdatePurchaseReceipt(int id, [FromBody] PurchaseReceipt purchaseReceipt)
        {
            try
            {
                var getPurchaseReceipt = _unitOfWork.PurchaseReceipts.GetById(id);
                _purchaseReceiptService.UpdatePurchaseReceipt(purchaseReceipt, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/api/purchasereceipt/id/{id}")]
        public IActionResult GetPurchaseReceipt(int Id)
        {
            var purchaseReceipt = _unitOfWork.PurchaseOrders.GetPurchaseById(Id, true, true);
            return Ok(purchaseReceipt);

        }
        [HttpDelete]
        [Route("/api/purchasereceipt/id/{id}")]
        public IActionResult DeletePurchaseReceipt(int Id)
        {
            try
            {
                var uom = _unitOfWork.PurchaseReceipts.GetById(Id);
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
        [Route("/api/purchasereceipt/quantity")]
        public IActionResult GetTotalQuantity()
        {
            var quantity = _unitOfWork.PurchaseOrders.GetPurchaseOrderItemsTotalQuantity("Completed");
            return Ok(quantity);
        }
    }
}
