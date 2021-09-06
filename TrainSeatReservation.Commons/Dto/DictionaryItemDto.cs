using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class DictionaryItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DictionaryId { get; set; }
        public DictionaryDto Dictionary { get; set; }
    }
}
