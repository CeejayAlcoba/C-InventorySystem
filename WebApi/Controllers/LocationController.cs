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
    [Route("api/location")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILocationService _locationService;
        public LocationController(IUnitOfWork unitOfWork, ILocationService locationService)
        {
            _locationService = locationService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult LocationList()
        {
            var locations = _unitOfWork.Locations.GetAll();
            return Ok(locations);
        }
        [HttpPost]
        public IActionResult AddLocation([FromBody] Location location)
        {
            var getLocation = _locationService.AddLocation(location);
            if (getLocation != null)
            {
                return Ok(getLocation);
            }
            return BadRequest("Name already exists");

        }
        [HttpPatch]
        [Route("/api/location/id/{id}")]
        public IActionResult UpdateLocation(int Id, [FromBody] Location location)
        {
            var locationId = _unitOfWork.Locations.GetById(Id);
            var getLocation = _unitOfWork.Locations.GetLocationByName(location.Name);
            if (locationId.Name != location.Name)
            {
                if (getLocation == null)
                {
                    _locationService.UpdateLocation(location, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Name already exists");
                }

            }
            else
            {
                _locationService.UpdateLocation(location, Id);
                return Ok();
            }

        }
        [HttpGet]
        [Route("/api/location/id/{id}")]
        public IActionResult GetLocation(int Id)
        {
            var location = _unitOfWork.Locations.GetById(Id);
            return Ok(location);

        }
        [HttpDelete]
        [Route("/api/location/id/{id}")]
        public IActionResult DeleteLocation(int Id)
        {
            try
            {
                var uom = _unitOfWork.Locations.GetById(Id);
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
