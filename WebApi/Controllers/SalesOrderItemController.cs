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
    [Route("api/salesorderitem")]
    [ApiController]
    [Authorize]
    public class SalesOrderItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISalesOrderItemService _salesOrderItemService;
        public SalesOrderItemController(IUnitOfWork unitOfWork, ISalesOrderItemService salesOrderItemService)
        {

            _salesOrderItemService = salesOrderItemService;

            _unitOfWork = unitOfWork;
        }
        [HttpPatch]
        [Route("/api/salesorderitem/id/{id}")]
        public IActionResult UpdateSalesOrderItem(int Id, [FromBody] SalesOrderItem salesOrderItem)
        {
            try
            {
                var getSalesOrderItem = _unitOfWork.SalesOrderItems.GetById(Id);
                _salesOrderItemService.UpdateSalesOrderItem(salesOrderItem, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/api/salesorderitem/{id}")]
        public IActionResult GetSalesOrderItem(int Id)
        {
            var salesOrderItem = _unitOfWork.SalesOrderItems.GetSsalesOrderItemById(Id);
            return Ok(salesOrderItem);

        }
       
    }
}
