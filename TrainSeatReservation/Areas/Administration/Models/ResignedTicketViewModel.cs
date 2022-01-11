//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Areas.Administration.Models
{
    public class ResignedTicketViewModel
    {
        public IEnumerable<TicketResignedDto> Tickets { get; set; }
        public int TicketsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Tickets.Count() / (double)TicketsPerPage));
        }
        public IEnumerable<TicketResignedDto> PaginatedTickets()
        {
            int start = (CurrentPage - 1) * TicketsPerPage;
            return Tickets.OrderByDescending(x => x.TripDate).Skip(start).Take(TicketsPerPage);
        }
    }
}
