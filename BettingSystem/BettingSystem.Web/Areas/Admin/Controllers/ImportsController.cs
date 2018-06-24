using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BettingSystem.Imports;
using BettingSystem.Models;
using BettingSystem.Services;
using BettingSystem.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BettingSystem.Web.Areas.Admin.Controllers
{
    [Area(nameof(BettingSystem.Web.Areas.Admin))]
    [AllowAnonymous]
    public class ImportsController : Controller
    {
        readonly IEventService mEventService;

        public ImportsController(IEventService eventService)
        {
            mEventService = eventService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportUpcomingEvents(UpcomingEventsImportViewModel vm)
        {
            using (var textReader = new StreamReader(vm.XmlFile.OpenReadStream()))
            {
                string xml = textReader.ReadToEnd();
                IEnumerable<SportEvent> events = XmlConverter.FromXml(xml);
                mEventService.Create(events);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ImportUpdateEvents(UpdateEventsImportViewModel vm)
        {
            using (var textReader = new StreamReader(vm.XmlFile.OpenReadStream()))
            {
                string xml = textReader.ReadToEnd();
                IEnumerable<SportEvent> events = XmlConverter.FromXml(xml);
                mEventService.Update(events);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}