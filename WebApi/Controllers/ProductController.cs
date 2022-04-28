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
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;
        public ProductController(IUnitOfWork unitOfWork, IProductService productService, IProductRepository productRepository)
        {

            _productService = productService;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _productRepository.GetAllProduct(true, true, true, true, true);
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
            var product = _productRepository.GetProduct(Id, true, true, true, true, true);
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
