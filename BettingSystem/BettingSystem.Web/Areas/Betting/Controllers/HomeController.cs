using Microsoft.AspNetCore.Mvc;

namespace BettingSystem.Web.Areas.Betting.Controllers
{
    [Area("Betting")]
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}