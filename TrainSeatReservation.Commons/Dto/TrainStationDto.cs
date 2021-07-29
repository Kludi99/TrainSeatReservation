using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class TrainStationDto
    {
        public int Id { get; set; }
        public int TrainId { get; set; }
        public int StationId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
