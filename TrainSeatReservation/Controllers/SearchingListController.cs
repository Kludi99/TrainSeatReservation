using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Configuration;
using TrainSeatReservation.Commons.DisplayItems;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Interfaces.Facades;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;
using TrainSeatReservation.Commons;
using Microsoft.AspNetCore.Identity;

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
        private readonly ISeatFcd _seatFcd;
        private readonly IPayPalConfiguration _payPalConfiguration;
        private readonly ISeatTicketFcd _seatTicketFcd;
        private readonly IRouteTicketFcd _routeTicketFcd;
        private readonly UserManager<User> _userManager;

        public SearchingListController(UserManager<User> userManager, IStationFcd stationFcd, IRouteFcd routeFcd, IRouteStationFcd routeStationFcd,
            ITrainStationFcd trainStationFcd, ITrainFcd trainFcd, ITicketFcd ticketFcd, IDictionaryFcd dictionaryFcd, IDiscountFcd discountFcd, 
            ITicketDiscountFcd ticketDiscountFcd, IRouteWithChangesFcd routeWithChangesFcd, ISeatFcd seatFcd, IPayPalConfiguration payPalConfiguration, ISeatTicketFcd seatTicketFcd,
            IRouteTicketFcd routeTicketFcd)
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
            _seatFcd = seatFcd;
            _payPalConfiguration = payPalConfiguration;
            _userManager = userManager;
            _seatTicketFcd = seatTicketFcd;
            _routeTicketFcd = routeTicketFcd;
        }
        public IActionResult Index(int firstStationId, int lastStationId, TimeSpan time, DateTime date, int? normalTickets, string discounts)
        {
            var routeView = new RouteView();
            var newDate = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds);
            routeView = _routeWithChangesFcd.GetRoutes(firstStationId, lastStationId, time, date);
            routeView.Date = date;
            routeView.NormalTicketsCount = normalTickets.Value;
            //routeView.DiscountCount = discountCounter;
            //routeView.DiscountTypeId = discountType;
            routeView.Discounts = new List<SearchingView>();
            if (discounts != null)
            {
                var discountsList = JsonConvert.DeserializeObject<List<SearchingView>>(discounts);
                routeView.Discounts = discountsList;

            }

            foreach (var item in routeView.Trains)
            {
                double price = 0;
                foreach (var discount in routeView.Discounts)
                {
                    var disc = _discountFcd.GetDiscount(discount.DiscountTypeId);
                    price += item.Price * (((100.0 -disc.Value)/100.0)) * discount.DiscountCount;
                }
                if(routeView.NormalTicketsCount > 0)
                {
                    price += item.Price * routeView.NormalTicketsCount;
                }
                item.Price = price;
            }

            var parameters = HttpContext.Request.RouteValues;
             HttpContext.Session.SetString("RouteView", JsonConvert.SerializeObject(routeView)); 
            if(parameters["RouteView"] != null)
            {
                parameters["RouteView"] = routeView;
            }
            else
            {
                parameters.Add("RouteView", routeView);
            }
            return View(routeView);
        }
        public IActionResult AddOptionalItems(int id, int firstStationId, int endStationId, string date, int routeId, int normalTickets, List<RouteTransitView> transits)
        {
            var parameters = HttpContext.Request.RouteValues;
            var routeVal = HttpContext.Session.GetString("RouteView");
            var routeView = JsonConvert.DeserializeObject<RouteView>(routeVal);
            var trainView = routeView.Trains.Where(x => x.Train.Id == id).FirstOrDefault();
            var train = _trainFcd.GetTrain(id);
            var reservedSeats = new List<int>();
            if(trainView.Transits == 0)
            {
                train.TrainCarriages = GetSeats(routeView.Date, trainView.Route, trainView.Route, trainView.Train);
            }
            else
            {

            }
            //reservedSeats = /*GetSeats(routeView.Date, trainView.Route);*/_seatTicketFcd.GetSeatTickets().Where(x => x.Ticket.DepartureTrainStation.RouteId == trainView.Route.RouteId && x.Ticket.TripDate.Date == routeView.Date.Date).Select(x => x.SeatId).ToList();
           /* if(reservedSeats.Count >0)
            {
                 foreach (var item in train.TrainCarriages)
            {
                 item.Carriage.Seats.Where(x => reservedSeats.Contains(x.Id)).ToList().ForEach(c =>  c.IsFree = false );
              
            }
            }*/
           
            if (train == null)
            {
                return NotFound();
            }
            ViewBag.SeatsCount = normalTickets;
            if (routeView.Discounts.Count >0)
            {
                foreach (var item in routeView.Discounts)
                {
                    ViewBag.SeatsCount += item.DiscountCount;
                }
            }
            var trains = new List<TrainDto>();
            trains.Add(train);
            if(trainView.Transits >0)
            {
                foreach (var item in trainView.RouteTransits)
                {
                    var nextTrain = _trainFcd.GetTrain(item.Train.Id);
                    /*TODO: Dodać sprawdzenie dla przesiadek*/
                  /*  foreach (var carriage in nextTrain.TrainCarriages)
                    {
                        carriage.Carriage.Seats.Where(x => reservedSeats.Contains(x.Id)).ToList().ForEach(c => c.IsFree = false);
  
                    }*/
                    trains.Add(nextTrain);
                }
            }

            ViewBag.Transits = trainView.Transits;
            HttpContext.Session.SetString("TrainView", JsonConvert.SerializeObject(trainView));
            return View(trains);
        }
        public IActionResult PersonalData(int carriageId, string seats, bool allow)//przy przesiadkach moze byc kilka wagonów
        {
            var parameters = HttpContext.Request.RouteValues;
            var seatSession = HttpContext.Session.GetString("Seats");
            if (seatSession == null)
            {
                var seatsArr = seats.Split(',');
                var seatsIds = Array.ConvertAll(seatsArr, int.Parse);
                /*foreach (var item in seatsIds)
                {*/
                    var selectedSeats = _seatFcd.GetSeatsInCarriage(carriageId).Where(x => seatsIds.Contains(x.Number));
                // }
              //  foreach (var item in selectedSeats)
              //  {
              //      item.IsFree = false;
              //      _seatFcd.UpdateSeat(item);
              //  }
                
                var url = Request.Path;
                ViewBag.ReturnUrl = url;
                ViewBag.PhoneAllow = allow;
                var routeVal = HttpContext.Session.GetString("RouteView");
                var routeView = JsonConvert.DeserializeObject<RouteView>(routeVal);
                var trainVal = HttpContext.Session.GetString("TrainView");
                var trainView = JsonConvert.DeserializeObject<TrainView>(trainVal);

                var time = trainView.Route.StartTrainTimeTable.DepartureTime.ToString();
                var date = routeView.Date.Date;
                var dateTime = date.Day+ "." + date.Month + "." + date.Year + " " + time;
                var ticketDto = new TicketDto()
                {
                    TripDate = Convert.ToDateTime(dateTime),
                    ArrivalTrainStationId = trainView.EndStation.Id,
                    DepartureTrainStationId = trainView.StartStation.Id,
                    Price = trainView.Price,
                    IsPaid = false,
                    SendInformation = allow,
                    CarriageId = carriageId

                };
                var ticket = _ticketFcd.AddTicket(ticketDto);

                foreach (var item in selectedSeats)
                {
                    _seatTicketFcd.AddSeatTicket(new SeatTicketDto
                    {
                        SeatId = item.Id,
                        TicketId = ticket.Id,
                        IsFree = false
                    });
                }
                var routesIds = new List<int>();
                routesIds.Add(trainView.Route.RouteId);
                if(trainView.RouteTransits != null)
                {
                    foreach (var item in trainView.RouteTransits)
                    {
                        routesIds.Add(item.Route.Id);
                    }
                }
                
                foreach (var item in routesIds)
                {
                    _routeTicketFcd.AddRouteTicket(new RouteTicketDto
                    {
                        TicketId = ticket.Id,
                        RouteId = item,
                        TripDate = ticket.TripDate
                    }); 
                }

                var seatsView = new SeatsView()
                {
                    Seats = seatsIds.ToList(),
                    CarriageId = carriageId
                };
                //parameters.Add("Seats", seatsView);
                HttpContext.Session.SetString("Seats", JsonConvert.SerializeObject(seatsView));
                HttpContext.Session.SetString("Ticket", JsonConvert.SerializeObject(ticket));
            }
            return View();
        }
        public async Task<IActionResult> Summary(User user, string phone)
        {
            var routeVal = HttpContext.Session.GetString("RouteView");
            var routeView = JsonConvert.DeserializeObject<RouteView>(routeVal);
            var trainVal = HttpContext.Session.GetString("TrainView");
            var trainView = JsonConvert.DeserializeObject<TrainView>(trainVal);
            var ticketVal = HttpContext.Session.GetString("Ticket");
            var ticketDto = JsonConvert.DeserializeObject<TicketDto>(ticketVal);

            var seatsVal = HttpContext.Session.GetString("Seats");
            var seatsDto = JsonConvert.DeserializeObject<SeatsView>(seatsVal);

            var currentUser = await _userManager.GetUserAsync(User);

            ticketDto.Name = user.Name;
            ticketDto.Surname = user.Surname;
            ticketDto.Email = user.Email;
            ticketDto.UserId = currentUser != null ? currentUser.Id : null;
            ticketDto.PhoneNumber = user.PhoneNumber;

            var ticket = _ticketFcd.UpdateTicket(ticketDto);
            var discounts = new List<TicketDiscountDto>();
            var discountsView = new List<DiscountView>();
            foreach (var item in routeView.Discounts)
            {
                var disc = _discountFcd.GetDiscount(item.DiscountTypeId);

                var ticketDiscount = new TicketDiscountDto
                {
                    TicketId = ticket.Id,
                    DiscountId = disc.Id,
                    Count = item.DiscountCount
                };
                discounts.Add(_ticketDiscountFcd.AddTicketDiscount(ticketDiscount));

                var discountView = new DiscountView
                {
                    Discount = disc,
                    DiscountId = disc.Id,
                    Count = item.DiscountCount
                };
                discountsView.Add(discountView);
                
            }
            ticket.TicketDiscounts = discounts;

            var ticketWithStations = _ticketFcd.GetTicket(ticket.Id);
            var ticketView = new TicketSummaryView 
            {
                ArrivalTrainStation = ticketWithStations.ArrivalTrainStation,
                DepartureTrainStation = ticketWithStations.DepartureTrainStation,
                Email = ticket.Email,
                Name = ticket.Name,
                Surname = ticket.Surname,
                PhoneNumber = user.PhoneNumber,
                Price = ticket.Price,
                TripDate = ticket.TripDate,
                TicketDiscounts = discountsView,
                Seats = seatsDto,
                NormalSeats = seatsDto.Seats.Count - discountsView.Sum(x => x.Count)
            };
            ViewBag.SeatsNum = string.Join(";", ticketView.Seats.Seats);
            HttpContext.Session.SetString("TicketSummaryView", JsonConvert.SerializeObject(ticketView));
            return View(ticketView);

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

        private List<TrainCarriageDto> GetSeats(DateTime date, RouteStationDto firstRoute, RouteStationDto lastRoute,TrainDto trainDto)
        {
            var train = _trainFcd.GetTrain(trainDto.Id);
            var tickets = _ticketFcd.GetTrainTicketsWithDate(date, trainDto.Id);
            double freeSeats = 0;
            double capacity = 0;
            var occupiedSeats = 0;
            var reservedSeats = _seatTicketFcd.GetSeatTickets().Where(x => x.Ticket.DepartureTrainStation.RouteId == firstRoute.RouteId && x.Ticket.TripDate.Date == date.Date).Select(x => x.SeatId).ToList();
            if (reservedSeats.Count > 0)
            {
               /* foreach (var item in train.TrainCarriages)
                {
                    item.Carriage.Seats.Where(x => reservedSeats.Contains(x.Id)).ToList().ForEach(c => c.IsFree = false);
                    // seats.Select(x => { x.IsFree = false; return x; }).ToList();
                }*/
                foreach (var item in tickets)
                {
                    foreach (var carriage in train.TrainCarriages)
                    {
                        if ((item.DepartureTrainStation.TrainTimeTable.DepartureTime < firstRoute.StartTrainTimeTable.DepartureTime && item.ArrivalTrainStation.TrainTimeTable.ArrivalTime < lastRoute.EndTrainTimeTable.ArrivalTime && !(item.ArrivalTrainStation.TrainTimeTable.ArrivalTime < firstRoute.StartTrainTimeTable.DepartureTime))
                    || (item.DepartureTrainStation.TrainTimeTable.DepartureTime >= firstRoute.StartTrainTimeTable.DepartureTime && item.ArrivalTrainStation.TrainTimeTable.ArrivalTime <= lastRoute.EndTrainTimeTable.ArrivalTime)
                    || (item.DepartureTrainStation.TrainTimeTable.DepartureTime > firstRoute.StartTrainTimeTable.DepartureTime && item.ArrivalTrainStation.TrainTimeTable.ArrivalTime > lastRoute.EndTrainTimeTable.ArrivalTime) && !(item.ArrivalTrainStation.TrainTimeTable.ArrivalTime > firstRoute.StartTrainTimeTable.DepartureTime))
                        {
                            // occupiedSeats += item.SeatTickets.Count;
                            carriage.Carriage.Seats.Where(x => reservedSeats.Contains(x.Id)).ToList().ForEach(c => c.IsFree = false);
                        }
                    }

                }
                foreach (var item in train.TrainCarriages)
                {
                    capacity += item.Carriage.Capacity;
                }
                freeSeats = capacity - occupiedSeats;

                //Math.Round((freeSeats / capacity * 100), 2); ;
            }
            return train.TrainCarriages.ToList();
        }
    }
}
