using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class CarriageSeatsDto
    {
        public int CarriageId { get; set; }
        public List<int> SeatsIds { get; set; }
    }
}
