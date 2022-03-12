using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contructs;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApi.Auth;


namespace WebApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService _userService;
        private IAccountService _accountService;

        public AccountController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }



        

        [Authorize]
        [HttpGet(nameof(GetResult))]
        public IActionResult GetResult()
        {
            return Ok("API Validated");
        }
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class AuthorizeAttribute : Attribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var account = context.HttpContext.Items["User"];
                if (account == null)
                {
                    // not logged in
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                }
            }
        }

        [HttpPost]
        [Route("changepassword")]
        public IActionResult ChangePassword([FromQuery] string username, [FromQuery] string password, [FromQuery] string new_password, [FromQuery] string retype_password)
        {
            var isValid = _accountService.ValidateUser(username, password);
            if (isValid == null) return BadRequest("Invalid Password");
            else
            {
                if (new_password == retype_password)
                {

                    _accountService.ChangePassword(username, new_password);
                    return Ok();
                }
                return BadRequest("New Password doen't Match");
            }
        }
        [HttpPost]
        [Route("editusername")]
        public IActionResult EditUsername([FromQuery] string username, [FromQuery] string password, [FromQuery] string new_username)
        {
            var isValid = _accountService.ValidateUser(username, password);
            if (isValid != null)
            {
                _accountService.EditUsername(username, new_username);
                return Ok();
            }
            return BadRequest("Invalid Username and Password");

        }
        [HttpPost]
        [Route("changename")]
        public IActionResult ChangeName([FromQuery] string username,[FromQuery] string new_firstname, [FromQuery] string new_lastname)
        {
           _accountService.ChangeName(username, new_firstname, new_lastname);
           return Ok();
        }

    }
}
