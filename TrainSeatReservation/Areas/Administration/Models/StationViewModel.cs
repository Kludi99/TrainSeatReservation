using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Areas.Administration.Models
{
    public class StationViewModel
    {
        public IEnumerable<StationDto> Stations { get; set; }
        public int StationsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Stations.Count() / (double)StationsPerPage));
        }

        public IEnumerable<StationDto> PaginatedStations()
        {
            int start = (CurrentPage - 1) * StationsPerPage;
            return Stations.OrderBy(x => x.Name).Skip(start).Take(StationsPerPage);
        }
    }
}
