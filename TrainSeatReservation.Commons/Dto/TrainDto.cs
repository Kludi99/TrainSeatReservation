//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Numer")]
        public string Number { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Typ")]
        public DictionaryItemDto Type { get; set; }
        [DisplayName("Typ")]
        public int TypeId { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public RouteDto Route { get; set; }
        public ICollection<TrainCarriageDto> TrainCarriages { get; set; }
    }
}
