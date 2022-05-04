using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
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
    [Authorize]
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

            if (user.Password == user.ReTypePassword)
            {
                if (result == null) 
                {
                    _userService.AddUser(user);
                    return Ok();
                }
                return BadRequest("Username is already exist");
            }

            return BadRequest("Password doesn't  match");
        }

        [HttpPatch]
        [Route("/api/user/id/{id}")]
        public IActionResult UpdateUsername(int Id, [FromBody] User user)
        {
            var userId = _unitOfWork.Users.GetById(Id);
            var getUser = _unitOfWork.Users.GetUserByUsername(user.Username);
            if (userId.Username != user.Username)
            {
                if (getUser == null)
                {
                    _userService.UpdateUsername(user, Id);
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
        [HttpGet]
        [Route("user")]
        public IActionResult CurrentUser()
        {
            var currentUser = GetCurrentUser();
            if(currentUser!= null)
            return Ok(currentUser);
            return BadRequest();
        }
        [HttpGet]
        [Route("/api/user/id/{id}")]
        public IActionResult GetUser(int Id)
        {
            var user = _unitOfWork.Users.GetById(Id);
            if(user !=null)
            return Ok(user);
            return BadRequest("Invalid user");
        }
        [HttpGet]
        public IActionResult UsersList()
        {
            var usersList = _unitOfWork.Users.GetAll();
            return Ok(usersList);
        }
        [HttpDelete]
        [Route("/api/user/id/{id}")]
        public IActionResult DeleteUser(int Id)
        {
            _userService.DeleteUser(Id);
            return Ok();
        }
    }
}
