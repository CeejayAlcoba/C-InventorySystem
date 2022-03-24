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

        public PurchaseController(
            IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        } 

        [HttpGet]
        [Route("/api/purchase/{id}")]
        public IActionResult GetPurchase(int id)
        {
            var result = _purchaseService.GetPurchase(id);

            return Ok(result);
        }
    }
}
