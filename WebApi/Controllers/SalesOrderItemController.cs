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
        [HttpPost]
        [Route("/api/salesorderitemService/{id}")]
        public IActionResult AddSalesOrderItem(int id, [FromBody] SalesOrderItem salesOrderItem)
        {
            try
            {
                var addSalesOrderItem = _salesOrderItemService.AddSalesOrderItem(salesOrderItem, id);
                return Ok(addSalesOrderItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpGet]

        public IActionResult SalesOrderItemList()
        {
            var salesOrderItems = _unitOfWork.SalesOrderItems.GetAll();
            return Ok(salesOrderItems);
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
        [Route("/api/salesorderitem/id/{id}")]
        public IActionResult GetSalesOrderItem(int Id)
        {
            var salesOrderItem = _unitOfWork.SalesOrderItems.GetById(Id);
            return Ok(salesOrderItem);

        }
        [HttpDelete]
        [Route("/api/salesorderitem/id/{id}")]
        public IActionResult DeleteSalesOrderItem(int Id)
        {
            try
            {
                _salesOrderItemService.DeleteSalesOrderItem(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
