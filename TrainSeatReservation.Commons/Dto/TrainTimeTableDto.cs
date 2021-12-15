using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class TrainTimeTableDto
    {
        public int Id { get; set; }
        [DisplayName("Godzina przyjazdu")]
        public TimeSpan? ArrivalTime { get; set; }
        [DisplayName("Godzina odjazdu")]
        public TimeSpan? DepartureTime { get; set; }
        public DateTime StartingDateOfTimeTable { get; set; }
    }
}
