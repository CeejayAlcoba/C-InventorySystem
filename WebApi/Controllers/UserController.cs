﻿using Domain.Interfaces;
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
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        public UserController(IAccountService accountService,IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }
        [HttpPost]
        [Route("signup")]
        public IActionResult AddUser([FromQuery] string firstname, [FromQuery] string lastname, [FromQuery] string username, [FromQuery] string password)
        {
            var result = _accountService.ValidateUser(username, password);
            if (result == null)
            {
                _userService.AddUser(firstname, lastname, username, password);
                return Ok();
            }

            return BadRequest("Username is already exist");
        }
        [HttpGet]
        [Route("login")]
        public IActionResult AuthorizeUser([FromQuery] string username, [FromQuery] string password)
        {

            var isValid = _accountService.ValidateUser(username, password);
            if (isValid != null)
            {
                var tokenString = _accountService.GenerateJwtToken(username);
                return Ok(new { Token = tokenString, Message = "Success" });
            }
            return BadRequest("Invalid Username and Password");

        }

    }
}