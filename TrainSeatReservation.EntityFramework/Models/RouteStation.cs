using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class RouteStation
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public int StartStationId { get; set; }
        public Station StartStation { get; set; }
        public int EndStationId { get; set; }
        public Station EndStation { get; set; }
        public Train Train { get; set; }
        public int TrainId { get; set; }
        public TrainTimeTable StartTrainTimeTable { get; set; }
        public int StartTrainTimeTableId { get; set; }
        public TrainTimeTable EndTrainTimeTable { get; set; }
        public int EndTrainTimeTableId { get; set; }
        public int Order { get; set; }
        public int Distance { get; set; }
        public double Price { get; set; }
    }
}
