using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    [JsonObject(IsReference = true)]
    public class RouteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TrainDto Train { get; set; }
        public int TrainId { get; set; }
        [JsonIgnore]
       
        public ICollection<RouteStationDto> RouteStations { get; set; }
    }
}
