//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class TicketChangeDto
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public TicketDto Ticket { get; set; }
        public DateTime TransitionDate { get; set; }
        public StationDto Station { get; set; }
        public int StationId { get; set; }
        public int Order { get; set; }

    }
}
