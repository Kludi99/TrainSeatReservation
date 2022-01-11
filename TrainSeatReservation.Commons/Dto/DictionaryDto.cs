//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class DictionaryDto
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
    }
}
