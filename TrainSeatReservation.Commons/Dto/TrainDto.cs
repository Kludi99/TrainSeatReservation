using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Dto
{
    public class TrainDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public DictionaryItemDto Type { get; set; }
        public int TypeId { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public RouteDto Route { get; set; }
        public ICollection<TrainCarriageDto> TrainCarriages { get; set; }
    }
}
