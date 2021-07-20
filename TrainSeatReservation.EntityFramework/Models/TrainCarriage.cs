using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class TrainCarriage
    {
        public int Id { get; set; }
        public int CarriageId { get; set; }
        public Carriage Carriage { get; set; }

        public int TrainId { get; set; }
        public Train Train { get; set; }
    }
}
