using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class RouteStationDto
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public RouteDto Route { get; set; }
        public int StartStationId { get; set; }
        public StationDto StartStation { get; set; }
        public int EndStationId { get; set; }
        public StationDto EndStation { get; set; }
        public int Order { get; set; }
        public int Distance { get; set; }
        public double Price { get; set; }
    }
}
