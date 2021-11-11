using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class RouteTicketDto
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public TicketDto Ticket { get; set; }
        public int RouteId { get; set; }
        public RouteDto Route { get; set; }
        public DateTime TripDate { get; set; }
    }
}
