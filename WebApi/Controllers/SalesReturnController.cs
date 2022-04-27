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
    [Route("api/salesreturn")]
    [ApiController]
    public class SalesReturnController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISalesReturnService _salesReturnService;
        public SalesReturnController(IUnitOfWork unitOfWork, ISalesReturnService salesReturnService)
        {

            _salesReturnService = salesReturnService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public IActionResult SalesReturnList()
        {
            var salesReturns = _unitOfWork.SalesReturns.GetAll();
            return Ok(salesReturns);
        }
        [HttpPost]

        public IActionResult AddSalesReturn(int id, [FromBody] SalesReturn salesReturn)
        {
            try
            {
                var addSalesReturn = _salesReturnService.AddSalesReturn(salesReturn);
                return Ok(addSalesReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
        [HttpPatch]
        [Route("/api/salesreturn/id/{id}")]
        public IActionResult UpdateSalesReturn(int id, [FromBody] SalesReturn salesReturn)
        {
            try
            {
                _salesReturnService.UpdateSalesReturn(salesReturn, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/api/salesreturn/id/{id}")]
        public IActionResult GetSalesReturn(int Id)
        {
            var salesReturn = _unitOfWork.SalesReturns.GetById(Id);
            return Ok(salesReturn);

        }
        [HttpDelete]
        [Route("/api/salesreturn/id/{id}")]
        public IActionResult DeleteSalesReturn(int Id)
        {
            try
            {
                _salesReturnService.DeleteSalesReturn(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
