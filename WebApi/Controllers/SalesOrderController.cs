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
    [Route("api/salesorder")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISalesOrderService _salesOrderService;
        private readonly ISalesOrderRepository _salesOrderRepository;
        public SalesOrderController(IUnitOfWork unitOfWork, ISalesOrderService salesOrderService, ISalesOrderRepository salesOrderRepository)
        {

            _salesOrderService = salesOrderService;
            _salesOrderRepository = salesOrderRepository;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public IActionResult SalesOrderList()
        {
            var salesOrders = _salesOrderRepository.GetAllSalesOrder(true, true,true, "", false);
            return Ok();
        }
        [HttpPost]

        public IActionResult AddSalesOrder(int id, [FromBody] SalesOrder salesOrder)
        {
            try
            {
                var addSalesOrder = _salesOrderService.AddSalesOrder(salesOrder);
                return Ok(addSalesOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpPatch]
        [Route("/api/salesorder/id/{id}")]
        public IActionResult UpdateSalesOrder(int Id, [FromBody] SalesOrder salesOrder)
        {
            try
            {
                var getSalesOrder = _unitOfWork.SalesOrders.GetById(Id);
                _salesOrderService.UpdateSalesOrder(salesOrder, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/api/salesorder/id/{id}")]
        public IActionResult GetSalesOrder(int Id)
        {
            var salesOrder = _unitOfWork.SalesOrders.GetById(Id);
            return Ok(salesOrder);

        }
        [HttpDelete]
        [Route("/api/salesorder/id/{id}")]
        public IActionResult DeleteSalesOrder(int Id)
        {
            try
            {
                _salesOrderService.DeleteSalesOrder(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPatch]
        [Route("/api/salesorder/complete/{id}/{date}")]
        public IActionResult CompleteSalesOrder(int Id, DateTime Date)
        {
            try
            {
                var order = _salesOrderService.CompleteSalesOrder(Id, Date);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpPatch]
        [Route("/api/salesorder/return/{id}/{date}")]
        public IActionResult ReturnSalesOrder(int Id, DateTime Date)
        {
            try
            {
                var order = _salesOrderService.ReturnSalesOrder(Id, Date);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpPatch]
        [Route("/api/salesorder/cancel/{id}/{date}")]
        public IActionResult CancelSalesOrder(int Id, DateTime Date)
        {
            try
            {
                var order = _salesOrderService.CancelSalesOrder(Id, Date);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpPatch]
        [Route("/api/salesorder/reopen/{id}")]
        public IActionResult ReopenSalesOrder(int Id)
        {
            try
            {
                var order = _salesOrderService.ReOpenSalesOrder(Id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/api/salesorder/dailysales")]
        public IActionResult GetDailySales()
        {
            var dailySales = _unitOfWork.SalesOrders.GetDailySales(true, true, false);
            return Ok(dailySales);
        }
    }
}
