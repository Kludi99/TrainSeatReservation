using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Interfaces.Facades;

namespace TrainSeatReservation.Controllers
{
    public class SearchingListController : Controller
    {
        private readonly IStationFcd _stationFcd;
        private readonly IRouteFcd _routeFcd;
        private readonly ITrainFcd _trainFcd;
        private readonly IRouteStationFcd _routeStationFcd;
        private readonly ITrainStationFcd _trainStationFcd;

        public SearchingListController(IStationFcd stationFcd, IRouteFcd routeFcd, IRouteStationFcd routeStationFcd, ITrainStationFcd trainStationFcd, ITrainFcd trainFcd)
        {
            _stationFcd = stationFcd;
            _routeFcd = routeFcd;
            _routeStationFcd = routeStationFcd;
            _trainStationFcd = trainStationFcd;
            _trainFcd = trainFcd;
        }
        public IActionResult Index(DateTime date)
        {
            ViewBag.Routes = JsonConvert.DeserializeObject<List<RouteDto>>((string)TempData["routeList"]);
            ViewBag.RouteDetails = JsonConvert.DeserializeObject<List<RouteStationDto>>((string)TempData["routeStationsList"]);
            ViewBag.TrainStationDetails = JsonConvert.DeserializeObject<List<TrainStationDto>>((string)TempData["trainStationsList"]);
            ViewBag.Date = date.Date;
            return View();
        }
        public IActionResult ReserveSeat(int id, int firstStationId, int endStationId, string date)
        {
            var dateTime = Convert.ToDateTime(date);
            var train = _trainFcd.GetTrain(id);
            if (train == null)
            {
                return NotFound();
            }
            return View(train);
        }
    }
}
