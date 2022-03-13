using Microsoft.AspNetCore.Mvc;
using Services.Contructs;

namespace WebApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class AccountController : ControllerBase
    {
        private IUserService _userService;
        private IAccountService _accountService;

        public AccountController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [Auth.Authorize]
        [HttpGet(nameof(GetResult))]
        public IActionResult GetResult()
        {
            return Ok("API Validated");
        }
    }
}
