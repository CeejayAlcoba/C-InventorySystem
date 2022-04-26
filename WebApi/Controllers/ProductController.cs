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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        public ProductController(IUnitOfWork unitOfWork, IProductService productService)
        {

            _productService = productService;

            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _unitOfWork.Products.GetAll();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            try
            {
                var addProduct = _productService.AddProduct(product);
                return Ok(addProduct);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);

            }
          

        }
        [HttpPatch]
        [Route("/api/product/id/{id}")]
        public IActionResult UpdateProduct(int Id, [FromBody] Product product)
        {
            try
            {
                var getProduct = _unitOfWork.Products.GetById(Id);
                _productService.UpdateProduct(product,Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/api/product/id/{id}")]
        public IActionResult GetProduct(int Id)
        {
            var product = _unitOfWork.Products.GetById(Id);
            return Ok(product);

        }
        [HttpDelete]
        [Route("/api/product/id/{id}")]
        public IActionResult DeleteProduct(int Id)
        {
            try
            {
                _productService.DeleteProduct(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }   
    }
}
