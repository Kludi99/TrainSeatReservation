//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class StationDto
    {
        public int Id { get; set; }
        [DisplayName("Stacja")]
        public string Name { get; set; }
        [DisplayName("Miasto")]
        public string City { get; set; }
    }
}
