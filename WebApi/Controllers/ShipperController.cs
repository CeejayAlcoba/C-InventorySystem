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
    [Route("api/shipper")]
    [ApiController]
    [Authorize]
    public class ShipperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShipperService _shipperService;
        public ShipperController(IUnitOfWork unitOfWork, IShipperService shipperService)
        {
            _shipperService = shipperService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult ShipperList()
        {
            var shippers = _unitOfWork.Shippers.GetAll();
            return Ok(shippers);
        }
        [HttpPost]
        public IActionResult AddShipper([FromBody] Shipper shipper)
        {
            var getShipper = _shipperService.AddShipper(shipper);
            if (getShipper != null)
            {
                return Ok(getShipper);
            }
            return BadRequest("Name is already exist");

        }
        [HttpPatch]
        [Route("/api/shipper/id/{id}")]
        public IActionResult UpdateShipper(int Id, [FromBody] Shipper shipper)
        {
            var shipperId = _unitOfWork.Shippers.GetById(Id);
            var getShipper = _unitOfWork.Shippers.GetShipperByName(shipper.Name);
            if (shipperId.Name != shipper.Name)
            {
                if (getShipper == null)
                {
                    _shipperService.UpdateShipper(shipper, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Name is already exist");
                }

            }
            else
            {
                _shipperService.UpdateShipper(shipper, Id);
                return Ok();
            }

        }
        [HttpGet]
        [Route("/api/shipper/id/{id}")]
        public IActionResult GetShipper(int Id)
        {
            var shipper = _unitOfWork.Shippers.GetById(Id);
            return Ok(shipper);

        }
        [HttpDelete]
        [Route("/api/shipper/id/{id}")]
        public IActionResult DeleteShipper(int Id)
        {
            try
            {
                var uom = _unitOfWork.Shippers.GetById(Id);
                if (uom.IsDelete == true)
                {
                    uom.IsDelete = false;
                    _unitOfWork.Complete();
                }
                else
                {
                    uom.IsDelete = true;
                    _unitOfWork.Complete();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
