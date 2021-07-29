using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class CarriageDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int FreeSeats { get; set; }
    }
}
