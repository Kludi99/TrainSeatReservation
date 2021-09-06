﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class TrainStation
    {
        public int Id { get; set; }
        public int TrainId { get; set; }
        public Train Train { get; set; }
        public int StationId { get; set; }
        public Station Station { get; set; }
       /* public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }*/
        public TrainTimeTable TrainTimeTable { get; set; }
        public int TrainTimeTableId { get; set; }
    }
}
