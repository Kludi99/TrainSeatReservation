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
        public string Number { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int FreeSeats { get; set; }
        public ICollection<TrainCarriage> TrainCarriages { get; set; }
    }
}
