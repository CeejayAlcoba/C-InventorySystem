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
    [Route("api/salesdelivery")]
    [ApiController]
    public class SalesDeliveryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISalesDeliveryService _salesDeliveryService;
        public SalesDeliveryController(IUnitOfWork unitOfWork, ISalesDeliveryService salesDeliveryService)
        {

            _salesDeliveryService = salesDeliveryService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public IActionResult SalesDeliveryList()
        {
            var salesDeliveries = _unitOfWork.SalesDeliveries.GetAll();
            return Ok(salesDeliveries);
        }
        [HttpPost]

        public IActionResult AddSalesDelivery(int id, [FromBody] SalesDelivery salesDelivery)
        {
            try
            {
                var addSalesDelivery = _salesDeliveryService.AddSalesDelivery(salesDelivery);
                return Ok(addSalesDelivery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpPatch]
        [Route("/api/salesdelivery/id/{id}")]
        public IActionResult UpdateSalesDelivery(int id, [FromBody] SalesDelivery salesDelivery)
        {
            try
            {
                var getSalesDelivery = _unitOfWork.SalesDeliveries.GetById(id);
                _salesDeliveryService.UpdateSalesDelivery(salesDelivery, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/api/salesdelivery/id/{id}")]
        public IActionResult GetSalesDelivery(int Id)
        {
            var salesDelivery = _unitOfWork.SalesDeliveries.GetById(Id);
            return Ok(salesDelivery);

        }
        [HttpDelete]
        [Route("/api/salesdelivery/id/{id}")]
        public IActionResult DeleteSalesDelivery(int Id)
        {
            try
            {
                _salesDeliveryService.DeleteSalesDelivery(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
