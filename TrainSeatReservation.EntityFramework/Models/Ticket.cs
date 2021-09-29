using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class Ticket
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
        public ICollection<TicketDiscount> TicketDiscounts { get; set; }
        public double Price { get; set; }
        public ICollection<Seat> Seats { get; set; }
       // public int SeatId { get; set; }
    }
}
