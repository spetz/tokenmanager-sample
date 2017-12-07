using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenManager.Api.Models;
using TokenManager.Api.Services;

namespace TokenManager.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("account")]
        public IActionResult Get([FromBody] SignUp request)
            => Content($"Hello {User.Identity.Name}");

        [HttpPost("sign-up")]
        [AllowAnonymous]
        public IActionResult SignUp([FromBody] SignUp request)
        {
            _accountService.SignUp(request.Username, request.Password);
            
            return NoContent();
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public IActionResult SignIn([FromBody] SignIn request)
            => Ok(_accountService.SignIn(request.Username, request.Password));

        [HttpPost("tokens/{token}/refresh")]
        [AllowAnonymous]
        public IActionResult RefreshAccessToken(string token)
            => Ok(_accountService.RefreshAccessToken(token));

        [HttpPost("tokens/{token}/revoke")]
        public IActionResult RevokeRefreshToken(string token)
        {
            _accountService.RevokeRefreshToken(token);

            return NoContent();
        }
    }
}