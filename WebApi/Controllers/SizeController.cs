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
    [Route("api/size")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISizeService _sizeService;
        public SizeController(IUnitOfWork unitOfWork, ISizeService sizeService)
        {
            _sizeService = sizeService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult SizesList()
        {
            var sizes = _unitOfWork.Sizes.GetAll();
            return Ok(sizes);
        }
        [HttpPost]
        public IActionResult AddSizes([FromBody] Size size)
        {
            var getSize = _sizeService.AddSize(size);
            if (getSize != null)
            {
                return Ok(getSize);
            }
            return BadRequest("Name is already exist");

        }
        [HttpPatch]
        [Route("/api/size/id/{id}")]
        public IActionResult UpdateSize(int Id, [FromBody] Size size)
        {
            var sizeId = _unitOfWork.Sizes.GetById(Id);
            var getSize = _unitOfWork.Sizes.GetSizeByName(size.Name);
            if (sizeId.Name != getSize.Name)
            {
                if (getSize == null)
                {
                    _sizeService.UpdateSize(size, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Name is already exist");
                }

            }
            else
            {
                _sizeService.UpdateSize(size, Id);
                return Ok();
            }

        }
        [HttpGet]
        [Route("/api/size/id/{id}")]
        public IActionResult GetSize(int Id)
        {
            var getSize = _unitOfWork.Sizes.GetById(Id);
            return Ok(getSize);

        }
        [HttpDelete]
        [Route("/api/size/id/{id}")]
        public IActionResult DeleteSize(int Id)
        {
            try
            {
                _sizeService.DeleteSize(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
