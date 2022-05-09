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
    [Route("api/colour")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IColourService _colourService;
        public ColourController(IUnitOfWork unitOfWork, IColourService colourService)
        {
            _colourService = colourService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult ColourList()
        {
            var colours = _unitOfWork.Colours.GetAll();
            return Ok(colours);
        }
        [HttpPost]
        public IActionResult AddColour([FromBody] Colour colour)
        {
            var getColour = _colourService.AddColour(colour);
            if (getColour != null)
            {
                return Ok(getColour);
            }
            return BadRequest("Name is already exist");

        }
        [HttpPatch]
        [Route("/api/colour/id/{id}")]
        public IActionResult UpdateColour(int Id, [FromBody] Colour colour)
        {
            var colourId = _unitOfWork.Colours.GetById(Id);
            var getColour = _unitOfWork.Colours.GetColourByName(colour.Name);
            if (colourId.Name != colour.Name)
            {
                if (getColour == null)
                {
                    _colourService.UpdateColour(colour, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Name is already exist");
                }

            }
            else
            {
                _colourService.UpdateColour(colour, Id);
                return Ok();
            }

        }
        [HttpGet]
        [Route("/api/colour/id/{id}")]
        public IActionResult GetColour(int Id)
        {
            var colour = _unitOfWork.Colours.GetById(Id);
            return Ok(colour);

        }
        [HttpDelete]
        [Route("/api/colour/id/{id}")]
        public IActionResult DeleteColour(int Id)
        {
            try
            {
                _colourService.DeleteColour(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
