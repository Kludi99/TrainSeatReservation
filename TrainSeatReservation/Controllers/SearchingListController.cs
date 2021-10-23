using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.DisplayItems;
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
        private readonly ITicketFcd _ticketFcd;
        private readonly IDictionaryFcd _dictionaryFcd;
        private readonly IDiscountFcd _discountFcd;
        private readonly ITicketDiscountFcd _ticketDiscountFcd;
        private readonly IRouteWithChangesFcd _routeWithChangesFcd;

        public SearchingListController(IStationFcd stationFcd, IRouteFcd routeFcd, IRouteStationFcd routeStationFcd, ITrainStationFcd trainStationFcd, ITrainFcd trainFcd, ITicketFcd ticketFcd, IDictionaryFcd dictionaryFcd, IDiscountFcd discountFcd, ITicketDiscountFcd ticketDiscountFcd, IRouteWithChangesFcd routeWithChangesFcd)
        {
            _stationFcd = stationFcd;
            _routeFcd = routeFcd;
            _routeStationFcd = routeStationFcd;
            _trainStationFcd = trainStationFcd;
            _trainFcd = trainFcd;
            _ticketFcd = ticketFcd;
            _dictionaryFcd = dictionaryFcd;
            _discountFcd = discountFcd;
            _ticketDiscountFcd = ticketDiscountFcd;
            _routeWithChangesFcd = routeWithChangesFcd;
        }
        public IActionResult Index(int firstStationId, int lastStationId, TimeSpan time, DateTime date, int? discountType, int? discountCounter, int? normalTickets)
        {
            var routeView = new RouteView();
            routeView = _routeWithChangesFcd.GetRoutes(firstStationId, lastStationId, time, date);
            routeView.Date = date;
            routeView.NormalTicketsCount = normalTickets.Value;
            routeView.DiscountCount = discountCounter;
            routeView.DiscountTypeId = discountType;
            return View(routeView);
        }
        public IActionResult AddOptionalItems(int id, int firstStationId, int endStationId, string date, int routeId, int normalTickets, int? discountTypeId, int? discountCounter, List<RouteTransitView> transits)
        {
            var train = _trainFcd.GetTrain(id);

            if (train == null)
            {
                return NotFound();
            }
            ViewBag.SeatsCount = normalTickets;
            if (discountCounter.HasValue)
                ViewBag.SeatsCount += discountCounter.Value;
            return View(train);
        }
        public IActionResult PersonalData()
        {
            return View();
        }
        [HttpPost]
        [ActionName("AddPassengers")]
        public IActionResult AddPassengers(TicketDto ticket, int normalPriceTickets, int? firstDiscountTickets, int? firstDiscountType, int? secondDiscountTickets, int? secondDiscountType, int? thirdDiscountTickets, int? thirdDiscountType )
        {
            var firstDiscount = 0;
            var secondDiscount = 0;
            var thirdDiscount = 0;
            var discountType = new DiscountDto();
            var ticketDto = _ticketFcd.AddTicket(ticket);
            if (firstDiscountTickets.HasValue)
                firstDiscount = firstDiscountTickets.Value;
            if (secondDiscountTickets.HasValue)
                secondDiscount = secondDiscountTickets.Value;
            if (thirdDiscountTickets.HasValue)
                thirdDiscount = thirdDiscountTickets.Value;
            var seats = normalPriceTickets + firstDiscount + secondDiscount + thirdDiscount;
            if (firstDiscountType.HasValue)
            {
                var discount = _discountFcd.GetDiscount(firstDiscountType.Value);
                var ticketDiscount = new TicketDiscountDto
                {
                    Count = firstDiscountTickets.Value,
                    DiscountId = discount.Id,
                    TicketId = ticketDto.Id
                };
                var ticketDiscountDto = _ticketDiscountFcd.AddTicketDiscount(ticketDiscount);
                ticketDto.TicketDiscounts.Add(ticketDiscountDto);
            }
            if (secondDiscountType.HasValue)
            {
                var discount = _discountFcd.GetDiscount(secondDiscountType.Value);
                var ticketDiscount = new TicketDiscountDto
                {
                    Count = secondDiscountTickets.Value,
                    DiscountId = discount.Id,
                    TicketId = ticketDto.Id
                };
                var ticketDiscountDto = _ticketDiscountFcd.AddTicketDiscount(ticketDiscount);
                ticketDto.TicketDiscounts.Add(ticketDiscountDto);
            }
            if (thirdDiscountType.HasValue)
            {
                var discount = _discountFcd.GetDiscount(thirdDiscountType.Value);
                var ticketDiscount = new TicketDiscountDto
                {
                    Count = thirdDiscountTickets.Value,
                    DiscountId = discount.Id,
                    TicketId = ticketDto.Id
                };
                var ticketDiscountDto = _ticketDiscountFcd.AddTicketDiscount(ticketDiscount);
                ticketDto.TicketDiscounts.Add(ticketDiscountDto);
            }
            return RedirectToAction("ReserveSeat", new { ticket = ticketDto, seats = seats});
        }
        public IActionResult ReserveSeat(TicketDto ticket, int seats)
        {
            ViewBag.CarriageType = GetSelectList(2);
            ViewBag.CarriageClass = GetSelectList(3);
            ViewBag.SeatType = GetSelectList(4);
            ViewBag.SeatsCount = seats;
            return View(ticket);
        }
        [HttpPost]
        public IActionResult ReserveSeat(TicketDto ticket)
        {
            return null;
        }

        private IQueryable<DictionaryItemDto> CarriageAndSeatTypeDropdown(int dictionaryId)
        {
            //var currentUser = _userManager.GetUserAsync(User).Result;
            var query = _dictionaryFcd.GetDictionaryItems(dictionaryId).AsQueryable();

            return query;
        }
        private List<SelectListItem> GetSelectList(int dictionaryId)
        {
            var addressess = CarriageAndSeatTypeDropdown(dictionaryId);
            var selectList = new List<SelectListItem>();
            foreach (var item in addressess)
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
