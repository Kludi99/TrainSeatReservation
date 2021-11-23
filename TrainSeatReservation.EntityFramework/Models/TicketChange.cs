using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class TicketChange
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime TransitionDate { get; set; }
        public Station Station { get; set; }
        public int StationId { get; set; }
        public int Order { get; set; }

    }
}
