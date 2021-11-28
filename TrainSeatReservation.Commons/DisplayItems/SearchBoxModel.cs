using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.DisplayItems
{
    public class SearchBoxModel
    {
        [Range(1, int.MaxValue)]
        public int FirstStationId { get; set; }
        [Range(1, int.MaxValue)]
        public int LastStationId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string NormalTicketsCount { get; set; }
        public string Dictionary { get; set; }
    }
}
