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
    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBrandService _brandService;
        public BrandController(IUnitOfWork unitOfWork, IBrandService brandService)
        {
            
            _brandService = brandService;
           
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult BrandList()
        {
            var brands = _unitOfWork.Brands.GetAll();
            return Ok(brands);
        }
        [HttpPost]
        public IActionResult AddBrand([FromBody] Brand brand)
        {
            var getBrand = _brandService.AddBrand(brand);
            if (getBrand != null)
            {
                return Ok(getBrand);
            }
            return BadRequest("Name is already exist");

        }
        [HttpPatch]
        [Route("/api/brand/id/{id}")]
        public IActionResult UpdateBrand(int Id, [FromBody] Brand brand)
        {
            var brandId = _unitOfWork.Brands.GetById(Id);
            var getBrand = _unitOfWork.Brands.GetBrandByName(brand.Name);
            if (brandId.Name != getBrand.Name)
            {
                if (getBrand == null)
                {
                    _brandService.UpdateBrand(brand, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Name is already exist");
                }

            }
            else
            {
                _brandService.UpdateBrand(brand, Id);
                return Ok();
            }

        }
        [HttpGet]
        [Route("/api/brand/id/{id}")]
        public IActionResult GetBrand(int Id)
        {
            var brand = _unitOfWork.Brands.GetById(Id);
            return Ok(brand);

        }
        [HttpDelete]
        [Route("/api/brand/id/{id}")]
        public IActionResult DeleteBrand(int Id)
        {
            try
            {
                _brandService.DeleteBrand(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
