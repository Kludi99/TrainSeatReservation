using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class TicketDiscountDto
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int? DiscountId { get; set; }
        public DiscountDto Discount { get; set; }
        public int Count { get; set; }
    }
}
