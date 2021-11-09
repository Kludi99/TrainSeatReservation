using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class SeatTicketDto
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public TicketDto Ticket { get; set; }
        public int SeatId { get; set; }
        public SeatDto Seat { get; set; }
        public bool IsFree { get; set; }
    }
}
