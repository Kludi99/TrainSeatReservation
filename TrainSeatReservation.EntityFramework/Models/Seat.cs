using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsFree { get; set; }
        public DictionaryItem SeatType { get; set; }
        public bool IsTravelDirection { get; set; }
        public int SeatTypeId { get; set; }
        public int CarriageId { get; set; }
        public Carriage Carriage { get; set; }
    }
}
