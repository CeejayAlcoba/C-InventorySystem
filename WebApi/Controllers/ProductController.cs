using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Contructs;
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
        public ProductController(IAccountService accountService, IUserService userService, IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var productList = _unitOfWork.Products.GetAll();
            return Ok(productList);
        }

    }
}
