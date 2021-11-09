using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class Carriage
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DictionaryItem Type { get; set; }
        public int TypeId { get; set; }
        public DictionaryItem CarriageClass { get; set; }
        public int CarriageClassId { get; set; }
       // public int Capacity { get; set; }
       // public int FreeSeats { get; set; }
        public bool IsActive { get; set; }
        public bool? EletricalOutlet { get; set; }
        public bool? CateringCar { get; set; }
        public bool? BicyclePlace { get; set; }
        public ICollection<TrainCarriage> TrainCarriages { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
