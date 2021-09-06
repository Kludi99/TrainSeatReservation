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
        public int Number { get; set; }
        public DictionaryItemDto Type { get; set; }
        public int TypeId { get; set; }
        public DictionaryItemDto CarriageClass { get; set; }
        public int CarriageClassId { get; set; }
        public int Capacity { get
            {
                return Seats.Count();
            }
        }
        public int FreeSeats { get; set; }
        public bool IsActive { get; set; }
        public ICollection<SeatDto> Seats { get; set; }
    }
}
