using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/producthistory")]
    [ApiController]
    public class ProductHistoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductHistoryController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAllProductHistory()
        {

            try
            {
                var productHistory = _unitOfWork.ProductHistories.GetProductHistory(true, true, true, true);
                return Ok(productHistory);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
