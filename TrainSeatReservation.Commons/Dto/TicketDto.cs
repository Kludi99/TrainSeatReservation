using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime TripDate { get; set; }
        public int ArrivalTrainStationId { get; set; }
        public int DepartureTrainStationId { get; set; }
        public double Price { get; set; }
        public SeatDto Seat { get; set; }
        public int SeatId { get; set; }
    }
}
