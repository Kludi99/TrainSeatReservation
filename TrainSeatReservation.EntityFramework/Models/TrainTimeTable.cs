//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class TrainTimeTable
    {
        public int Id { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public DateTime StartingDateOfTimeTable { get; set; }
        public ICollection<TrainStation> TrainStations { get; set; }
    }
}
