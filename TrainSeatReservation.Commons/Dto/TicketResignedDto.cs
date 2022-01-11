//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Imię")]
        public string Name { get; set; }
        [DisplayName("Nazwisko")]
        public string Surname { get; set; }
        [DisplayName("Data podróży")]
        public DateTime TripDate { get; set; }
        public int ArrivalTrainStationId { get; set; }
        [DisplayName("Stacja końcowa")]
        public TrainStationDto ArrivalTrainStation { get; set; }
        public int DepartureTrainStationId { get; set; }
        [DisplayName("Stacja początkowa")]
        public TrainStationDto DepartureTrainStation { get; set; }

        public int ArrivalStationId { get; set; }
        [DisplayName("Stacja końcowa")]
        public StationDto ArrivalStation { get; set; }
        public int DepartureStationId { get; set; }
        [DisplayName("Stacja początkowa")]
        public StationDto DepartureStation { get; set; }
    }
}
