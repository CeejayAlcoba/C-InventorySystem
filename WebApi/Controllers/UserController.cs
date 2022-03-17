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

        [HttpPatch]
        [Authorize]
        public IActionResult UpdateUser()
        {
            var currentUser = GetCurrentUser();
            return Ok(currentUser);
        }
        [HttpPatch]
        [Authorize]
        [Route("username")]
        public IActionResult UpdateUsername([FromBody] User user)
        {
            if (user != null)
            {
                var currentUser = GetCurrentUser();
                _userService.UpdateUsername(user.Username, currentUser.Id);
                return Ok();
            }
            else return BadRequest("Fill the username");
        }
    }
}
