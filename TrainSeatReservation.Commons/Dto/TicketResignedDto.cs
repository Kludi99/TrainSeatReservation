using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class TicketResignedDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime TripDate { get; set; }
        public int ArrivalTrainStationId { get; set; }     
        public TrainStationDto ArrivalTrainStation { get; set; }
        public int DepartureTrainStationId { get; set; }
        public TrainStationDto DepartureTrainStation { get; set; }
        public int ArrivalStationId { get; set; }
        public StationDto ArrivalStation { get; set; }
        public int DepartureStationId { get; set; }
        public StationDto DepartureStation { get; set; }
    }
}
