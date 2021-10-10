using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class RouteStationDto
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public RouteDto Route { get; set; }
        public int StartStationId { get; set; }
        public StationDto StartStation { get; set; }
        public int EndStationId { get; set; }
        public StationDto EndStation { get; set; }
        public TrainDto Train { get; set; }
        public int TrainId { get; set; }
        public TrainTimeTableDto StartTrainTimeTable { get; set; }
        public int StartTrainTimeTableId { get; set; }
        public TrainTimeTableDto EndTrainTimeTable { get; set; }
        public int EndTrainTimeTableId { get; set; }
        public int Order { get; set; }
        public int Distance { get; set; }
        public double Price { get; set; }
        public TimeSpan Time
        {
            get
            {

                return (TimeSpan)(EndTrainTimeTable.ArrivalTime - StartTrainTimeTable.DepartureTime);
            }
        }
    }
}
