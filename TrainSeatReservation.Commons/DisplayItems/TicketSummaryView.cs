using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Imię")]
        public string Name { get; set; }
        [DisplayName("Nazwisko")]
        public string Surname { get; set; }
        [DisplayName("Data podróży")]
        public DateTime TripDate { get; set; }
        [DisplayName("Telefon")]
        public string PhoneNumber { get; set; }
        public int ArrivalTrainStationId { get; set; }
        [DisplayName("Stacja początkowa")]
        public TrainStationDto ArrivalTrainStation { get; set; }
        public int DepartureTrainStationId { get; set; }
        [DisplayName("Stacja końcowa")]
        public TrainStationDto DepartureTrainStation { get; set; }
        [DisplayName("Cena")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [DisplayName("Bilety normalne")]
        public int NormalSeats { get; set; }
        [DisplayName("Siedzenia")]
        public List<SeatsView> Seats { get; set; }
        public ICollection<SeatsView> SeatsView { get; set; }

        public ICollection<DiscountView> TicketDiscounts { get; set; }
    }
}
