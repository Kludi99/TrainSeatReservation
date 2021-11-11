using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class RouteTicket
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public DateTime TripDate { get; set; }
    }
}
