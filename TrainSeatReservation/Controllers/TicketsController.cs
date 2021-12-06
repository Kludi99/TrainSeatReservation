using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainSeatReservation.Commons;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Commons.EmailService;
using TrainSeatReservation.Data;
using TrainSeatReservation.EntityFramework.Models;
using TrainSeatReservation.Interfaces.Facades;
using TrainSeatReservation.Models;

namespace TrainSeatReservation.Controllers
{

    public class TicketsController : Controller
    {
        // private readonly ApplicationDbContext _context;
        private readonly ITicketFcd _ticketFcd;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public TicketsController(ITicketFcd ticketFcd, UserManager<User> userManager, IEmailService emailService)
        {
            _ticketFcd = ticketFcd;
            _userManager = userManager;
            _emailService = emailService;
        }

        // GET: Administration/Tickets
        public async Task<IActionResult> Index(int page = 1)
        {
            var user = await _userManager.GetUserAsync(User);
            var tickets = _ticketFcd.GetTickets().Where(x => x.UserId == user.Id);

            var ticketsView = new TicketViewModel
            {
                TicketsPerPage = 10,
                Tickets = tickets.OrderByDescending(x => x.TripDate),
                CurrentPage = page
            };
            return View(ticketsView);
        }

        public IActionResult Resign(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketFcd.GetTicket(id.Value);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Administration/Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketFcd.GetTicket(id.Value);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }
        [HttpPost]
        public async Task<IActionResult> Resign(TicketDto ticket)
        {
            _ticketFcd.DeleteTicket(ticket.Id);
            _emailService.SendEmailResignedTicket(ticket.Name, ticket.Surname, ticket.Email, ticket.Id);
            return RedirectToAction(nameof(Index));
        }
        // GET: Administration/Tickets/Create
        /*  public IActionResult Create()
          {
              ViewData["ArrivalTrainStationId"] = new SelectList(_context.TrainStations, "Id", "Id");
              ViewData["DepartureTrainStationId"] = new SelectList(_context.TrainStations, "Id", "Id");
              ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
              return View();
          }

          // POST: Administration/Tickets/Create
          // To protect from overposting attacks, enable the specific properties you want to bind to.
          // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Create([Bind("Id,UserId,Email,Name,Surname,TripDate,ArrivalTrainStationId,DepartureTrainStationId,Price")] Ticket ticket)
          {
              if (ModelState.IsValid)
              {
                  _context.Add(ticket);
                  await _context.SaveChangesAsync();
                  return RedirectToAction(nameof(Index));
              }
              ViewData["ArrivalTrainStationId"] = new SelectList(_context.TrainStations, "Id", "Id", ticket.ArrivalTrainStationId);
              ViewData["DepartureTrainStationId"] = new SelectList(_context.TrainStations, "Id", "Id", ticket.DepartureTrainStationId);
              ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ticket.UserId);
              return View(ticket);
          }*/

        // GET: Administration/Tickets/Edit/5
        /*   public async Task<IActionResult> Edit(int? id)
           {
               if (id == null)
               {
                   return NotFound();
               }

               var ticket = await _context.Tickets.FindAsync(id);
               if (ticket == null)
               {
                   return NotFound();
               }
               ViewData["ArrivalTrainStationId"] = new SelectList(_context.TrainStations, "Id", "Id", ticket.ArrivalTrainStationId);
               ViewData["DepartureTrainStationId"] = new SelectList(_context.TrainStations, "Id", "Id", ticket.DepartureTrainStationId);
               ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ticket.UserId);
               return View(ticket);
           }

           // POST: Administration/Tickets/Edit/5
           // To protect from overposting attacks, enable the specific properties you want to bind to.
           // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
           [HttpPost]
           [ValidateAntiForgeryToken]
           public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Email,Name,Surname,TripDate,ArrivalTrainStationId,DepartureTrainStationId,Price")] Ticket ticket)
           {
               if (id != ticket.Id)
               {
                   return NotFound();
               }

               if (ModelState.IsValid)
               {
                   try
                   {
                       _context.Update(ticket);
                       await _context.SaveChangesAsync();
                   }
                   catch (DbUpdateConcurrencyException)
                   {
                       if (!TicketExists(ticket.Id))
                       {
                           return NotFound();
                       }
                       else
                       {
                           throw;
                       }
                   }
                   return RedirectToAction(nameof(Index));
               }
               ViewData["ArrivalTrainStationId"] = new SelectList(_context.TrainStations, "Id", "Id", ticket.ArrivalTrainStationId);
               ViewData["DepartureTrainStationId"] = new SelectList(_context.TrainStations, "Id", "Id", ticket.DepartureTrainStationId);
               ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ticket.UserId);
               return View(ticket);
           }

           // GET: Administration/Tickets/Delete/5
          /* public async Task<IActionResult> Delete(int? id)
           {
               if (id == null)
               {
                   return NotFound();
               }

               var ticket = await _context.Tickets
                   .Include(t => t.ArrivalTrainStation)
                   .Include(t => t.DepartureTrainStation)
                   .Include(t => t.User)
                   .FirstOrDefaultAsync(m => m.Id == id);
               if (ticket == null)
               {
                   return NotFound();
               }

               return View(ticket);
           }

           // POST: Administration/Tickets/Delete/5
           [HttpPost, ActionName("Delete")]
           [ValidateAntiForgeryToken]
           public async Task<IActionResult> DeleteConfirmed(int id)
           {
               var ticket = await _context.Tickets.FindAsync(id);
               _context.Tickets.Remove(ticket);
               await _context.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
           }*/

        private bool TicketExists(int id)
        {
            return _ticketFcd.IsTicketExists(id);
        }
    }
}
