//Program powstał na Wydziale Informatyki Politechniki Białostockiej
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
        public TrainDto Train { get; set; }
        public int StationId { get; set; }
        public StationDto Station { get; set; }
        public int RouteId { get; set; }
        public RouteDto Route { get; set; }
        public TrainTimeTableDto TrainTimeTable { get; set; }
        public int TrainTimeTableId { get; set; }
    }
}
