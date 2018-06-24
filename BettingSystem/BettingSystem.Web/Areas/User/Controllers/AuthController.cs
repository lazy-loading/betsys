using System.Threading.Tasks;
using BettingSystem.Web.Areas.User.Models;
using BettingSystem.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BettingSystem.Web.Areas.User.Controllers
{
    [Area("User")]
    public class AuthController : Controller
    {
        private readonly UserManager<BettingSystem.Models.User> _userManager;
        private readonly SignInManager<BettingSystem.Models.User> _signInManager;

        public AuthController(UserManager<BettingSystem.Models.User> userManager,
            SignInManager<BettingSystem.Models.User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

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
        public async Task<IActionResult> Register(UserRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var modelWithErrors
                    = new IndexViewModel {RegisterViewModel = model};
                return View("Index", modelWithErrors);
            }

            var user = new BettingSystem.Models.User
            {
                Email = model.EmailAddress,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}