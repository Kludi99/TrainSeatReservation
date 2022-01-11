//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.Areas.Administration.Models;
using TrainSeatReservation.Interfaces.Facades;

namespace TrainSeatReservation.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class TicketResignedController : Controller
    {
        private readonly ITicketFcd _ticketFcd;

        public TicketResignedController(ITicketFcd ticketFcd)
        {
            _ticketFcd = ticketFcd;
        }
        public IActionResult Index(int page = 1)
        {
            var tickets = _ticketFcd.GetResignedTickets();

            var ticketsView = new ResignedTicketViewModel
            {
                TicketsPerPage = 10,
                Tickets = tickets.OrderByDescending(x => x.TripDate),
                CurrentPage = page
            };
            return View(ticketsView);
        }
    }
}
