using Microsoft.AspNetCore.Mvc;

namespace TokenManager.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get()
            => Content("Token Manager API");
    }
}