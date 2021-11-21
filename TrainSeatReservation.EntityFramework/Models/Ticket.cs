using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int CarriageId { get; set; }
        public int? SecondCarriageId { get; set; }
        public int? ThirdCarriageId { get; set; }
        public ICollection<TicketDiscount> TicketDiscounts { get; set; }
        public double Price { get; set; }
        public bool IsPaid { get; set; }
        public bool? SendInformation { get; set; }
        public DateTime CreateDate { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public ICollection<SeatTicket> SeatTickets { get; set; }
        public ICollection<RouteTicket> RouteTickets { get; set; }
       // public int SeatId { get; set; }
    }
}
