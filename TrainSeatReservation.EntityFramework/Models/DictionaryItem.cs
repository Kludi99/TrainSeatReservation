//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class DictionaryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary Dictionary { get; set; }
        public int DictionaryId { get; set; }

        public ICollection<Train> Trains { get; set; }
    }
}
