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
        private readonly UserManager<User> _userManager;

        public SearchingListController(UserManager<User> userManager, IStationFcd stationFcd, IRouteFcd routeFcd, IRouteStationFcd routeStationFcd, ITrainStationFcd trainStationFcd, ITrainFcd trainFcd, ITicketFcd ticketFcd, IDictionaryFcd dictionaryFcd, IDiscountFcd discountFcd, ITicketDiscountFcd ticketDiscountFcd, IRouteWithChangesFcd routeWithChangesFcd, ISeatFcd seatFcd, IPayPalConfiguration payPalConfiguration)
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
        }
        public IActionResult Index(int firstStationId, int lastStationId, TimeSpan time, DateTime date, int? normalTickets, string discounts)
        {
            var routeView = new RouteView();
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
            var trainView = routeView.Trains.Where(x => x.Route.Id == routeId).FirstOrDefault();
            var train = _trainFcd.GetTrain(id);

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
                

            HttpContext.Session.SetString("TrainView", JsonConvert.SerializeObject(trainView));
            return View(train);
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
                    var selectedSeats = _seatFcd.GetSeatsInCarriage(carriageId).Where(x => seatsIds.Contains(x.Id));
                // }
                foreach (var item in selectedSeats)
                {
                    item.IsFree = false;
                    _seatFcd.UpdateSeat(item);
                }
                
                var url = Request.Path;
                ViewBag.ReturnUrl = url;
                
                var routeVal = HttpContext.Session.GetString("RouteView");
                var routeView = JsonConvert.DeserializeObject<RouteView>(routeVal);
                var trainVal = HttpContext.Session.GetString("TrainView");
                var trainView = JsonConvert.DeserializeObject<TrainView>(trainVal);
               // var parameters = HttpContext.Request.RouteValues;

                var seatsView = new SeatsView()
                {
                    Seats = seatsIds.ToList(),
                    CarriageId = carriageId
                };
                //parameters.Add("Seats", seatsView);
                HttpContext.Session.SetString("Seats", JsonConvert.SerializeObject(seatsView));
            }
            return View();
        }
        public async Task<IActionResult> Summary(User user)
        {
            var routeVal = HttpContext.Session.GetString("RouteView");
            var routeView = JsonConvert.DeserializeObject<RouteView>(routeVal);
            var trainVal = HttpContext.Session.GetString("TrainView");
            var trainView = JsonConvert.DeserializeObject<TrainView>(trainVal);

            var currentUser = await _userManager.GetUserAsync(User);
            var ticketDto = new TicketDto()
            {
                TripDate = routeView.Date,
                ArrivalTrainStationId = trainView.EndStation.Id,
                DepartureTrainStationId = trainView.StartStation.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Price = trainView.Price,
                UserId = currentUser != null ? currentUser.Id : null,

            };
            var ticket = _ticketFcd.AddTicket(ticketDto);
            var discounts = new List<TicketDiscountDto>();
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
                
            }
            ticket.TicketDiscounts = discounts;
            var ticketView = new TicketSummaryView /*TODO: change model from ticketDto to TicketSummaryView*/
            {

            };
            return View(ticket);

        }


        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            
            //getting the apiContext  
            APIContext apiContext = PayPalConfiguration.GetAPIContext(_payPalConfiguration);
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal  
                //Payer Id will be returned when payment proceeds or click to pay  
                var parameters = HttpContext.Request.RouteValues;
                string payerId = parameters["PayerID"] as string;
               
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  

                    //dodać widok w którym zwrócą się dane z zakupu 
                    string baseURI = "https://localhost:44397/";//Request.Url.Scheme + "://" + Request.Url.Authority + "/Home/PaymentWithPayPal?";
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = this.CreatePayment(apiContext, baseURI /*+ "guid=" + guid*/);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    //HttpSessionState.Add(guid, createdPayment.id);
                    parameters.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment  
                   
                    var g = parameters["guid"];
                    var guid = g;//HttpContext.Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, /*HttpContext.Session[guid]*/guid as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("FailureView");
            }
            //on successful payment, show success page to user.  
            return View("SuccessView");
        }
        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = "Item Name comes here",
                currency = "PLN",
                price = "0.01",
                quantity = "1",
                sku = "sku"
            });
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "0.01",
                shipping = "0.01",
                subtotal = "0.01"
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "PLN",
                total = "0.03", // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = "Transaction description",
                invoice_number = "your generated invoice number", //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
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
