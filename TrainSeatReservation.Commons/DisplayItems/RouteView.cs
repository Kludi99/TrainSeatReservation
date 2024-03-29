﻿//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Commons.DisplayItems
{
    public class RouteView
    {
        public List<TrainView> Trains { get; set; }
        public DateTime Date { get; set; }
        public int NormalTicketsCount { get; set; }
        public int? DiscountTypeId { get; set; }
        public int? DiscountCount { get; set; }
        public List<SearchingView> Discounts { get; set; }
    }
}
