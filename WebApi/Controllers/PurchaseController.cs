using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/purchase")]
    [ApiController]
    public class PurchaseController : BaseController
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseController(
            IPurchaseService purchaseService,
            IUnitOfWork unitOfWork)
        {
            _purchaseService = purchaseService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("/api/purchase/{id}")]
        public IActionResult GetPurchase(int id)
        {
            var result = _purchaseService.GetPurchase(id);

            return Ok(result);
        }
        [HttpGet]
        public IActionResult PurchaseList()
        {
            var result = _unitOfWork.Purchases.GetAllPurchase(true,true);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddPurchase([FromBody] Purchase purchase)
        {
            try
            {
                _purchaseService.AddPurchase(purchase);
                return Ok();
            }
            catch
            {
                return BadRequest(error: 415);
            }
            
        }
        //[HttpPatch]
        //[Route("/api/purchase/id/{id}")]
        //public IActionResult UpdatePurchase(int Id, [FromBody] Purchase purchase)
        //{
        //    var result = _unitOfWork.Purchases.

        //}
        [HttpDelete]
        [Route("/api/purchase/id/{id}")]
        public IActionResult DeletePurchse(int Id)
        {
            try
            {
                _purchaseService.DeletePurchase(Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
