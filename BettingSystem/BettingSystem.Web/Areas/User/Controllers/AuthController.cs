using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BettingSystem.Web.Areas.User.Controllers
{
    [Area("User")]
    public class AuthController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index() => View();

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}