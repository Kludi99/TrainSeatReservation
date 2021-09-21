using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.Interfaces.Facades;
using TrainSeatReservation.Models;

namespace TrainSeatReservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStationFcd _stationFcd;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IStationFcd stationFcd)
        {
            _logger = logger;
            _stationFcd = stationFcd;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult StationsList(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                return Json(null, System.Web.Mvc.JsonRequestBehavior.AllowGet);
            }
            else
            {
                var stations = _stationFcd.GetStations();
                var stationNames = stations.Where(x => x.Name.Contains(prefix)).Select(x => new { Id = x.Id, Name = x.Name }).ToList();

                return Json(new { data = stationNames }/*, System.Web.Mvc.JsonRequestBehavior.AllowGet*/);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
