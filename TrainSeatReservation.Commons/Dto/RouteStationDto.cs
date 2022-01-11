//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Trasa")]
        public int RouteId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        [DisplayName("Trasa")]
        public RouteDto Route { get; set; }
        [DisplayName("Stacja początkowa")]
        public int StartStationId { get; set; }
        [DisplayName("Stacja początkowa")]
        public StationDto StartStation { get; set; }
        [DisplayName("Stacja końcowa")]
        public int EndStationId { get; set; }
        [DisplayName("Stacja końcowa")]
        public StationDto EndStation { get; set; }
        [DisplayName("Pociąg")]
        public TrainDto Train { get; set; }
        [DisplayName("Pociąg")]
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
