﻿//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class TrainCarriageDto
    {
        public int Id { get; set; }
        public int CarriageId { get; set; }
        public int TrainId { get; set; }
        public CarriageDto Carriage { get; set; }
        public TrainDto Train { get; set; }
    }
}
