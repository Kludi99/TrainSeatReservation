using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.DisplayItems;
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
        private readonly IDiscountFcd _discountFcd;

        public RouteController(IStationFcd stationFcd, IRouteFcd routeFcd, IRouteStationFcd routeStationFcd,ITrainStationFcd trainStationFcd, IRouteWithChangesFcd routeWithChangesFcd, IDiscountFcd discountFcd)
        {
            _stationFcd = stationFcd;
            _routeFcd = routeFcd;
            _routeStationFcd = routeStationFcd;
            _trainStationFcd = trainStationFcd;
            _routeWithChangesFcd = routeWithChangesFcd;
            _discountFcd = discountFcd;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int firstStationId, int lastStationId, string date, string timeValue, string normalPriceTickets, string firstDiscountId, string firstDiscountCounter, string dictionary) 
        {
            var time = TimeSpan.Parse(timeValue);
           // var dict = JsonConvert.DeserializeObject<List<SearchingView>>(dictionary);
            var normalTickets = 0;
            if (normalPriceTickets != null)
                normalTickets = int.Parse(normalPriceTickets);
         
                return RedirectToAction("Index", controllerName: "SearchingList", new { firstStationId = firstStationId, lastStationId = lastStationId, time = time, date = Convert.ToDateTime(date), normalTickets = normalTickets, discounts = dictionary });

            
         
           // return RedirectToAction("Index", controllerName: "SearchingList",new {firstStationId = firstStationId, lastStationId = lastStationId, time =time, date = Convert.ToDateTime(date), normalTickets =normalTickets }); 
        }

        private List<SelectListItem> GetSelectDiscountList()
        {
            var discountList = _discountFcd.GetDiscounts();
            var selectList = new List<SelectListItem>();
            foreach (var item in discountList)
            {
                var listItem = new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                };
                selectList.Add(listItem);
            }
            return selectList;
        }
    }
}
