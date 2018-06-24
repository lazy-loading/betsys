using System.Threading.Tasks;
using BettingSystem.Web.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BettingSystem.Web.Areas.User.Controllers
{
    [Area("User")]
    public class AuthController : Controller
    {
        private readonly SignInManager<BettingSystem.Models.User> _signInManager;
        private readonly UserManager<BettingSystem.Models.User> _userManager;

        public AuthController(SignInManager<BettingSystem.Models.User> signInManager,
            UserManager<BettingSystem.Models.User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [AllowAnonymous]
        public IActionResult Index() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel model, string returnUrl = "/")
        {
            if (!ModelState.IsValid) return BadRequest();
            
            var result = await _signInManager.PasswordSignInAsync(model.EmailAddress, model.Password, false, false);

            if (result.Succeeded) return Redirect(returnUrl);

            return View(nameof(Index), model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegistrationViewModel model, string returnUrl = "/")
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new BettingSystem.Models.User
            {
                UserName = model.EmailAddress,
                Email = model.EmailAddress
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded) return Redirect(returnUrl);

            return View(nameof(Index), model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}