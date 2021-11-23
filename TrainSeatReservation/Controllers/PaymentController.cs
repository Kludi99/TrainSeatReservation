using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PayPal.Api;
using RazorLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TrainSeatReservation.Commons;
using TrainSeatReservation.Commons.Configuration;
using TrainSeatReservation.Commons.DisplayItems;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Commons.EmailService;
using TrainSeatReservation.Interfaces.Facades;

namespace TrainSeatReservation.Controllers
{
    public class PaymentController : Controller
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
        private readonly ITicketChangeFcd _ticketChangeFcd;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private IConverter _converter;

        public PaymentController(UserManager<User> userManager, IStationFcd stationFcd, IRouteFcd routeFcd, IRouteStationFcd routeStationFcd,
            ITrainStationFcd trainStationFcd, ITrainFcd trainFcd, ITicketFcd ticketFcd, IDictionaryFcd dictionaryFcd, IDiscountFcd discountFcd,
            ITicketDiscountFcd ticketDiscountFcd, IRouteWithChangesFcd routeWithChangesFcd, ISeatFcd seatFcd, IPayPalConfiguration payPalConfiguration, 
            ISeatTicketFcd seatTicketFcd, IConverter converter, IEmailService emailService, ITicketChangeFcd ticketChangeFcd)
        {
            _stationFcd = stationFcd;
            _trainFcd = trainFcd;
            _ticketFcd = ticketFcd;
            _dictionaryFcd = dictionaryFcd;
            _discountFcd = discountFcd;
            _payPalConfiguration = payPalConfiguration;
            _userManager = userManager;
            _seatTicketFcd = seatTicketFcd;
            _converter = converter;//new SynchronizedConverter(new PdfTools());
            _emailService = emailService;
            _ticketChangeFcd = ticketChangeFcd;
            _ticketDiscountFcd = ticketDiscountFcd;
        }
        public async Task<IActionResult> Index(string paymentId, string token, string PayerId, bool? Cancel)
        {
            var parameters = HttpContext.Request.RouteValues;
            paymentId = parameters["paymentID"] as string;
            token = parameters["token"] as string;
            PayerId = parameters["PayerID"] as string;
            Cancel = parameters["Cancel"] as bool?;
            var ticketVal = HttpContext.Session.GetString("Ticket");
            var ticketDto = JsonConvert.DeserializeObject<TicketDto>(ticketVal);
            var ticketUpdatedDto = _ticketFcd.GetTicket(ticketDto.Id);
            ticketUpdatedDto.IsPaid = true;
             _ticketFcd.UpdateTicket(ticketUpdatedDto);
            var ticket = _ticketFcd.GetTicket(ticketDto.Id);
            var ticketTransitions = _ticketChangeFcd.GetTicketChanges().Where(x => x.TicketId == ticket.Id).ToList();
            var ticketDiscounts = _ticketDiscountFcd.GetTicketDiscounts(ticket.Id);
            var ticketDiscountsIds = ticketDiscounts.Select(x => x.DiscountId);
            var seatsTicket = _seatTicketFcd.GetSeatTickets().Where(x => x.TicketId == ticket.Id).GroupBy(x=> x.Seat.CarriageId).Select(grp => grp.ToList());
            var discounts = _discountFcd.GetDiscounts().Where(x => ticketDiscountsIds.Contains(x.Id)).ToList();
            foreach (var item in ticketDiscounts)
            {
                item.Discount = discounts.Single(x => x.Id == item.DiscountId);
            }
            //var firstseat = seatsTicket[0];
            ticket.SeatTicketsList = new List<List<SeatTicketDto>>();

            //ticket.SeatTicketsList.Add(seatsTicket.SelectMany(x => x).ToList());


            ticket.SeatTicketsList = seatsTicket;
            ticket.TicketChanges = ticketTransitions;
            ticket.TicketDiscounts = ticketDiscounts;
            //ticket.SeatTickets = seatsTicket;

            var attachment = await PrintPDFAsync(ticket);
            
            _emailService.SendEmailWithAttachment(attachment, ticket, "Bilety", "W załączniku znajdują się zakupione bilety");
            HttpContext.Session.Clear();
            return View(ticket);
        }
        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            var ticketSummaryVal = HttpContext.Session.GetString("TicketSummaryView");
            var ticketSummaryView = JsonConvert.DeserializeObject<TicketSummaryView>(ticketSummaryVal);
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
                    string baseURI = "https://localhost:44397/Payment";//Request.Url.Scheme + "://" + Request.Url.Authority + "/Home/PaymentWithPayPal?";
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

                    //paymentId=PAYID-MGFLR3Y8DP50336X93538151&token=EC-71J98950LA187920N&PayerID=42G7V6LWA3NSQ
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
            var ticketSummaryVal = HttpContext.Session.GetString("TicketSummaryView");
            var ticketSummaryView = JsonConvert.DeserializeObject<TicketSummaryView>(ticketSummaryVal);

            var price = ticketSummaryView.Price.ToString();
            price  = price.Replace(',', '.');
            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = "Bilety",
                currency = "PLN",
                price = price,//ticketSummaryView.Price.ToString(),
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
                tax = "0",
                shipping = "0",
                subtotal = price //ticketSummaryView.Price.ToString()
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "PLN",
                total = price, //ticketSummaryView.Price.ToString(), // Total must be equal to sum of tax, shipping and subtotal.  
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
        public IActionResult SuccessView()
        {
            var ticketVal = HttpContext.Session.GetString("Ticket");
            var ticketDto = JsonConvert.DeserializeObject<TicketDto>(ticketVal);
            ticketDto.IsPaid = true;
            var ticket = _ticketFcd.UpdateTicket(ticketDto);
            return View(ticket);
        }
        public IActionResult FailureView()
        {
            var ticketVal = HttpContext.Session.GetString("Ticket");
            var ticketDto = JsonConvert.DeserializeObject<TicketDto>(ticketVal);
             _ticketFcd.DeleteTicket(ticketDto.Id);
            HttpContext.Session.Clear();
            return View();
        }

        public async Task<byte[]> PrintPDFAsync(TicketDto ticket)
        {
            var engine = new RazorLightEngineBuilder()
                            .UseFileSystemProject(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                            .UseMemoryCachingProvider()
                            .Build();

            var model = ticket;
            string page = null;
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Views", "Payment", "PDF.cshtml");//Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), $"Views/Home/Index.cshtml");

                page = await engine.CompileRenderAsync(path, model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,

                },

                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = page,
                        UseExternalLinks = true,
                        UseLocalLinks = true,
                        WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                        LoadSettings =  new LoadSettings { JSDelay = 2000 }
                    }
                }
            };

            byte[] pdf = null;
            try
            {
                pdf = _converter.Convert(doc);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return pdf;
        }

    }
}
