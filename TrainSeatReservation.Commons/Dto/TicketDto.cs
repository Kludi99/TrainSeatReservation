using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    [BindProperties]
    public class TicketDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
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

        [DisplayName("Cena")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public bool? SendInformation { get; set; }
        public bool IsPaid { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public int CarriageId { get; set; }
        public CarriageDto Carriage { get; set; }
        public int? SecondCarriageId { get; set; }
        public CarriageDto SecondCarriage { get; set; }
        public int? ThirdCarriageId { get; set; }
        public CarriageDto ThirdCarriage { get; set; }
        public DateTime CreateDate { get; set; }
        [DisplayName("Wybrane siedzenia")]
        public ICollection<SeatTicketDto> SeatTickets { get; set; }
        [DisplayName("Zniżki")]
        public ICollection<TicketDiscountDto> TicketDiscounts { get; set; }
        public ICollection<TicketChangeDto> TicketChanges { get; set; }
        public IEnumerable<List<SeatTicketDto>> SeatTicketsList { get; set; }
        // public int SeatId { get; set; }
    }
}
