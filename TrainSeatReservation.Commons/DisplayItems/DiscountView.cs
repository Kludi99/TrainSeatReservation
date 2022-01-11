//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Commons.DisplayItems
{
    public class DiscountView
    {
        public int Count { get; set; }
        public int DiscountId { get; set; }
        public DiscountDto Discount { get; set; }
    }
}
