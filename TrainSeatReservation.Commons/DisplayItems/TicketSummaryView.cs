using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Commons.DisplayItems
{
    public class TicketSummaryView
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime TripDate { get; set; }
        public int ArrivalTrainStationId { get; set; }
        public TrainStationDto ArrivalTrainStation { get; set; }
        public int DepartureTrainStationId { get; set; }
        public TrainStationDto DepartureTrainStation { get; set; }
        public double Price { get; set; }
        public int NormalSeats { get; set; }
        public ICollection<SeatDto> Seats { get; set; }

        public ICollection<DiscountView> TicketDiscounts { get; set; }
    }
}
