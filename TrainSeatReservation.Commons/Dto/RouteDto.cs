//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    [JsonObject(IsReference = true)]
    public class RouteDto
    {
        public int Id { get; set; }
        [DisplayName("Trasa")]
        public string Name { get; set; }
        [DisplayName("Pociąg")]
        public TrainDto Train { get; set; }
        [DisplayName("Pociąg")]
        public int TrainId { get; set; }
        [JsonIgnore]
       
        public ICollection<RouteStationDto> RouteStations { get; set; }
    }
}
