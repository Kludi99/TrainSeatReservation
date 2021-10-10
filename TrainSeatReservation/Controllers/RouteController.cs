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
    public class RouteController : Controller
    {
        private readonly IStationFcd _stationFcd;
        private readonly IRouteFcd _routeFcd;
        private readonly IRouteStationFcd _routeStationFcd;
        private readonly ITrainStationFcd _trainStationFcd;
        private readonly IRouteWithChangesFcd _routeWithChangesFcd;

        public RouteController(IStationFcd stationFcd, IRouteFcd routeFcd, IRouteStationFcd routeStationFcd,ITrainStationFcd trainStationFcd, IRouteWithChangesFcd routeWithChangesFcd)
        {
            _stationFcd = stationFcd;
            _routeFcd = routeFcd;
            _routeStationFcd = routeStationFcd;
            _trainStationFcd = trainStationFcd;
            _routeWithChangesFcd = routeWithChangesFcd;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int firstStationId, int lastStationId, DateTime datePickerValue, DateTime datepicker, string date, string timeValue) //TODO: Search routes with that stations
        {
            _routeWithChangesFcd.GetRoutes(firstStationId, lastStationId);


            // trains without intercharges
            var routes = _routeFcd.GetRoutes();
            var trainStations = _trainStationFcd.GetTrainStations();
            var routeList = new List<RouteDto>();
            var routeStations = new List<RouteStationDto>();
            TrainStationDto startTrainStation = null; 
            TrainStationDto endTrainStation = null;
            var trainStationList = new List<TrainStationDto>();
            var time = TimeSpan.Parse(timeValue);
            foreach (var item in routes)
            {
                if (item.RouteStations.Any(x => x.StartStationId == firstStationId) && item.RouteStations.Any(x => x.EndStationId == lastStationId))
                {
                    var first = item.RouteStations.FirstOrDefault(x => x.StartStationId == firstStationId);
                    var last = item.RouteStations.FirstOrDefault(x => x.EndStationId == lastStationId);
                    var firstTime = _trainStationFcd.GetTrainsFromStation(firstStationId).Where(x => x.RouteId == first.RouteId).Select(x => x.TrainTimeTable).FirstOrDefault();
                    if(first.Order< last.Order && firstTime.DepartureTime > time)
                    {
                        startTrainStation = trainStations.FirstOrDefault(x => x.TrainId == item.TrainId && x.StationId == firstStationId);
                        endTrainStation = trainStations.FirstOrDefault(x => x.TrainId == item.TrainId && x.StationId == lastStationId);
                       // routeStations = new List<RouteStationDto>();
                        var routeStationsList = _routeStationFcd.GetRouteStations().Where(x => x.RouteId == item.Id && first.Order <= x.Order && last.Order >= x.Order);
                        routeList.Add(item);
                        var kilometers = 0;
                        var fullPrice = 0.0;
                        foreach (var routeStation in routeStationsList)
                        {
                            kilometers += routeStation.Distance;
                            fullPrice += routeStation.Price;
                        }
                        var routeStationDto = new RouteStationDto
                        {
                            Distance = kilometers,
                            Price = fullPrice,
                            StartStation = first.StartStation,
                            EndStation = last.EndStation,
                            RouteId = first.RouteId
                        };
                        routeStations.Add(routeStationDto);
                        trainStationList.Add(startTrainStation);
                        trainStationList.Add(endTrainStation);
                      /*  var trainStationDto = new TrainStationDto
                        {
                            Train = item.Train,
                            TrainId = item.TrainId,
                            Station = startTrainStation.Station,
                            StationId = startTrainStation.StationId,
                            ArrivalDate = startTrainStation.
                        }*/

                    }
                }
            }
            TempData["routeList"] = JsonConvert.SerializeObject(routeList);
            TempData["routeStationsList"] = JsonConvert.SerializeObject(routeStations);
            TempData["trainStationsList"] = JsonConvert.SerializeObject(trainStationList);
            return RedirectToAction("Index", controllerName: "SearchingList", new { date = Convert.ToDateTime(date) }); 
        }
    }
}
