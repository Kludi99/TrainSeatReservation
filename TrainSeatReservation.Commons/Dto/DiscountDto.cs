using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class DiscountDto
    {
        public int Id { get; set; }
        [DisplayName("Zniżka")]
        public string Name { get; set; }
        [DisplayName("Wartość")]
        public int Value { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
    }
}
