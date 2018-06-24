using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingSystem.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BettingSystem.Web.Areas.Admin.Controllers
{
    [Area(nameof(BettingSystem.Web.Areas.Admin))]
    public class ImportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportUpcomingEvents(UpcomingEventsImportViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}