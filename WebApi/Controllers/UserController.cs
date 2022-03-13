using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi.Auth;

namespace WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class UserController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IAccountService accountService, IUserService userService, IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("signup")]
        public IActionResult AddUser([FromBody] User user)
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
        public IActionResult AuthorizeUser([FromBody]User user)
        {
            var validatedUser
                = _accountService.ValidateUser(user.Username, user.Password);

            if (validatedUser != null)
            {
                var tokenString = _accountService.GenerateJwtToken(validatedUser);
                return Ok(tokenString);
            }
            return BadRequest("Invalid Username and Password");
        }

        [HttpPatch]
        [Authorize]
        public IActionResult UpdateUser()
        {
            var userId = GetCurrentUser();     
            return Ok();
        }
    }
}
