﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Contracts;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        public ProductController(IAccountService accountService, IUserService userService, IUnitOfWork unitOfWork, IProductService productService)
        {
            _accountService = accountService;
            _productService = productService;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var productList = _unitOfWork.Products.GetAll();
            return Ok(productList);
        }
        [HttpPost]
        public IActionResult ProductAdd([FromBody] Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }
        [HttpPatch]
        [Route("/api/user/id/{id}")]
        public IActionResult UpdateProduct(int Id, [FromBody] Product product)
        {
            var prodcutId = _unitOfWork.Products.GetById(Id);
            var getProduct = _unitOfWork.Products.GetProductByName(product.ProductName);
            if (prodcutId.ProductName != product.ProductName)
            {
                if (getProduct == null)
                {
                    _productService.UpdateProduct(product, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Username is already exist");
                }

            }
            else
            {
                _userService.UpdateUsername(user, Id);
                return Ok();
            }

        }
        [HttpDelete]
        public IActionResult ProductDelete([FromBody] Product product)
        {
            _productService.DeleteProduct(product);
            return Ok();
        }

    }
}
