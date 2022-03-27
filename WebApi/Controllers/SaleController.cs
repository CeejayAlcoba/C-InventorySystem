using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace WebApi.Controllers
{
    [Route("api/sale")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly IUnitOfWork _unitOfWork;

        public SaleController(
            ISaleService saleService,
            IUnitOfWork unitOfWork)
        {
            _saleService = saleService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("/api/sale/{id}")]
        public IActionResult GetSale(int id)
        {
            var result = _saleService.GetSale(id);

            return Ok(result);
        }
        [HttpGet]
        public IActionResult SaleList()
        {
            var result = _unitOfWork.Sales.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddSale([FromBody] Sale sale)
        {
            try
            {
                _saleService.AddSale(sale);
                return Ok();
            }
            catch
            {
                return BadRequest(error: 415);
            }

        }
        [HttpPatch]
        public IActionResult UpdateSale([FromBody] Sale sale)
        {
            try
            {
                var result = _saleService.UpdateSale(sale);
                return Ok(result);
            }
            catch
            {
                return BadRequest(error: 415);
            }

        }
        [HttpDelete]
        public IActionResult DeleteSale([FromBody] int purchaseId)
        {
            _saleService.DeleteSale(purchaseId);
            return Ok();
        }
    }
}
