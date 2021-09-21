using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.EntityFramework.Models
{
    public class Train
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public DictionaryItem Type { get; set; }
        public int TypeId { get; set; }
        public bool IsActive { get; set; }
        public Route Route { get; set; }
        public ICollection<TrainCarriage> TrainCarriages { get; set; }
    }
}
