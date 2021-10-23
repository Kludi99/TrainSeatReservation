using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Commons.DisplayItems
{
    
    public class RouteTransitView
    {
        public RouteDto Route { get; set; }
        public TrainDto Train { get; set; }
        public TimeSpan TimeForTransit { get; set; }
        public StationDto Station { get; set; }
        public double FreeSeats { get; set; }
    }
}
