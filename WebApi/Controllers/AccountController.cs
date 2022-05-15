using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using WebApi.Auth;

namespace WebApi.Controllers
{
    [Route("api/account")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private IUserService _userService;
        private IUnitOfWork _unitofWork;
        private IAccountService _accountService;

        public AccountController(IUserService userService, IAccountService accountService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _accountService = accountService;
            _unitofWork = unitOfWork;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult AuthorizeUser([FromBody] User user)
        {
            var validatedUser = _accountService.ValidateUser(user.Username, user.Password);

            if (validatedUser != null && validatedUser.IsDelete==false)
            {
                var getUser = _unitofWork.Users.GetUserByUsername(user.Username);
                var tokenString = _accountService.GenerateJwtToken(getUser);
                return Ok(tokenString);
            }
            return BadRequest("Invalid Username and Password");
        }   
        [Auth.Authorize]
        [HttpGet(nameof(GetResult))]
        public IActionResult GetResult()
        {
            return Ok("API Validated");
        }
    }
}
