//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class TicketResigned
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime TripDate { get; set; }
        public int ArrivalTrainStationId { get; set; }
        [ForeignKey("ArrivalTrainStationId")]
        public TrainStation ArrivalTrainStation { get; set; }
        public int DepartureTrainStationId { get; set; }
        [ForeignKey("DepartureTrainStationId")]
        public TrainStation DepartureTrainStation { get; set; }

        public int ArrivalStationId { get; set; }
        [ForeignKey("ArrivalStationId")]
        public Station ArrivalStation { get; set; }
        public int DepartureStationId { get; set; }
        [ForeignKey("DepartureStationId")]
        public Station DepartureStation { get; set; }
       
    }
}
