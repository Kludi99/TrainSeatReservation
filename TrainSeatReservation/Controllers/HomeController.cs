//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.Commons;
using TrainSeatReservation.Commons.EmailService;
using TrainSeatReservation.Interfaces.Facades;
using TrainSeatReservation.Models;

namespace TrainSeatReservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStationFcd _stationFcd;
        private readonly ILogger<HomeController> _logger;
        private readonly IDiscountFcd _discountFcd;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, IStationFcd stationFcd, IDiscountFcd discountFcd, UserManager<User> userManager, IEmailService emailService)
        {
            _logger = logger;
            _stationFcd = stationFcd;
            _discountFcd = discountFcd;
            _userManager = userManager;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            ViewBag.Discount = GetSelectDiscountList();
            return View();
        }
        public async Task<IActionResult> Contact()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }
        [HttpPost]
        public IActionResult SendEmail(User user, string subject, string content)
        {
            _emailService.SendEmail(user.Name, user.Surname, user.Email, subject, content);
            return RedirectToAction(nameof(Index));
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
                var stationNames = stations.Where(x => x.Name.Contains(prefix, StringComparison.CurrentCultureIgnoreCase)).Select(x => new { Id = x.Id, Name = x.Name }).ToList();

                return Json(new { data = stationNames }/*, System.Web.Mvc.JsonRequestBehavior.AllowGet*/);
            }
        }

        public IActionResult Info()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
