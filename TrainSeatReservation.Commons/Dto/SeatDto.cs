//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class SeatDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsFree { get; set; }
        public bool IsTravelDirection { get; set; }
        public DictionaryItemDto SeatType { get; set; }
        public int SeatTypeId { get; set; }
        public int CarriageId { get; set; }
        public CarriageDto Carriage { get; set; }
    }
}
