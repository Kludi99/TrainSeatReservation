//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class DictionaryItemDto
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Słownik")]
        public int DictionaryId { get; set; }
        [DisplayName("Słownik")]
        public DictionaryDto Dictionary { get; set; }
    }
}
