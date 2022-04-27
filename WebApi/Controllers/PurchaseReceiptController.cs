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
    [Route("api/purchasereciept")]
    [ApiController]
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
            var purchaseReceipts = _unitOfWork.PurchaseReceipts.GetAll();
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
            var purchaseReceipt = _unitOfWork.PurchaseReceipts.GetById(Id);
            return Ok(purchaseReceipt);

        }
        [HttpDelete]
        [Route("/api/purchasereceipt/id/{id}")]
        public IActionResult DeletePurchaseReceipt(int Id)
        {
            try
            {
                _purchaseReceiptService.DeletePurchaseReceipt(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
