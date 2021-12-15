using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class CarriageDto
    {
        public int Id { get; set; }
        [DisplayName("Numer")]
        public int Number { get; set; }
        [DisplayName("Typ")]
        public DictionaryItemDto Type { get; set; }
        [DisplayName("Typ")]
        public int TypeId { get; set; }
        [DisplayName("Klasa")]
        public DictionaryItemDto CarriageClass { get; set; }
        [DisplayName("Klasa")]
        public int CarriageClassId { get; set; }
        [DisplayName("Gniazdka")]
        public bool EletricalOutlet { get; set; }
        [DisplayName("Wagon restauracyjny")]
        public bool CateringCar { get; set; }
        [DisplayName("Miejsce na rowery")]
        public bool BicyclePlace { get; set; }
        [DisplayName("Ilość siedzeń")]
        public int Capacity { get
            {
                return Seats.Count();
            }
        }
        [DisplayName("Dostępne siedzenia")]
        public int FreeSeats { get; set; }
        public bool IsActive { get; set; }
        public ICollection<SeatDto> Seats { get; set; }
    }
}
