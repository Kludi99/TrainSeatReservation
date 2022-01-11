//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class Dictionary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DictionaryItem> DictionaryItems { get; set; }
    }
}
