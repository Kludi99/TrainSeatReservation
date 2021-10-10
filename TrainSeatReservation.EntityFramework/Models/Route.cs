using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Train Train { get; set; }
        public int TrainId { get; set; }
        public ICollection<RouteStation> RouteStations { get; set; }
        public ICollection<TrainStation> TrainStations { get; set; }
    }
}
