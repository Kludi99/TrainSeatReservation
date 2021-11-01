using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Commons.DisplayItems
{
    public class TrainView
    {
        public StationDto StartStation { get; set; }
        public StationDto EndStation { get; set; }
        public int? Transits { get; set; }
        public RouteStationDto Route { get; set; }
        public TrainDto Train { get; set; }
        public RouteDto FirstRoute { get; set; }
        public double FreeSeats { get; set; }
        public TimeSpan TravelTime { get; set; }
        public double Price { get; set; }
        public List<RouteTransitView> RouteTransits { get; set; }
    }
}
