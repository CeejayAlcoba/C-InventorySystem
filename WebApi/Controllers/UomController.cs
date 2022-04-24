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
    [Route("api/uom")]
    [ApiController]
    public class UomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUomService _uomService;
        public UomController(IUnitOfWork unitOfWork, IUomService uomService)
        {
            _uomService = uomService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult UomList()
        {
            var uoms = _unitOfWork.Uoms.GetAll();
            return Ok(uoms);
        }
        [HttpPost]
        public IActionResult AddUom([FromBody] Uom uom)
        {
            var getUom = _uomService.AddUom(uom);
            if (getUom != null)
            {
                return Ok(getUom);
            }
            return BadRequest("Name is already exist");

        }
        [HttpPatch]
        [Route("/api/uom/id/{id}")]
        public IActionResult UpdateUom(int Id, [FromBody] Uom uom)
        {
            var uomId = _unitOfWork.Uoms.GetById(Id);
            var getUom = _unitOfWork.Uoms.GetUomByName(uom.Name);
            if (uomId.Name != getUom.Name)
            {
                if (getUom == null)
                {
                    _uomService.UpdateUom(uom, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Name is already exist");
                }

            }
            else
            {
                _uomService.UpdateUom(uom, Id);
                return Ok();
            }

        }
        [HttpGet]
        [Route("/api/uom/id/{id}")]
        public IActionResult GetUom(int Id)
        {
            var getUom = _unitOfWork.Uoms.GetById(Id);
            return Ok(getUom);

        }
        [HttpDelete]
        [Route("/api/uom/id/{id}")]
        public IActionResult DeleteUom(int Id)
        {
            try
            {
                _uomService.DeleteUom(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
