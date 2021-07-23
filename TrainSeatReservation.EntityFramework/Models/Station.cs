using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}
