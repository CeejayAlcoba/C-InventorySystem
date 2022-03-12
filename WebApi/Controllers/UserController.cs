using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IAccountService accountService,IUserService userService, IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("signup")]
        public IActionResult AddUser([FromBody]User user) 
        {
            var result = _unitOfWork.Users.GetUserByUsername(user.Username);
            if (result == null)
            {
                _userService.AddUser(user.Firstname, user.Lastname, user.Username, user.Password);
                return Ok();
            }

            return BadRequest("Username is already exist");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult AuthorizeUser([FromBody] User user)
        {

            var isValid = _accountService.ValidateUser(user.Username, user.Password);
            if (isValid != null)
            {
                var tokenString = _accountService.GenerateJwtToken(user.Username);
                return Ok(tokenString);
            }
            return BadRequest("Invalid Username and Password");

        }

    }
}
