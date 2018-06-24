using System.Collections.Generic;
using System.IO;
using BettingSystem.Imports;
using BettingSystem.Models;
using BettingSystem.Services;
using BettingSystem.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BettingSystem.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [AllowAnonymous]
    public class ImportsController : Controller
    {
        readonly IEventService _mEventService;

        public ImportsController(IEventService eventService)
        {
            _mEventService = eventService;
        }

        public IActionResult Index() => View();

        public IActionResult ImportUpcomingEvents(UpcomingEventsImportViewModel vm)
        {
            using (var textReader = new StreamReader(vm.XmlFile.OpenReadStream()))
            {
                string xml = textReader.ReadToEnd();
                IEnumerable<SportEvent> events = XmlConverter.FromXml(xml);
                _mEventService.Create(events);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ImportUpdateEvents(UpdateEventsImportViewModel vm)
        {
            using (var textReader = new StreamReader(vm.XmlFile.OpenReadStream()))
            {
                string xml = textReader.ReadToEnd();
                IEnumerable<SportEvent> events = XmlConverter.FromXml(xml);
                _mEventService.Update(events);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}