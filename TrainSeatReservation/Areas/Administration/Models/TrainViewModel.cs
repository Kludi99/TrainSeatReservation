//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Areas.Administration.Models
{
    public class TrainViewModel
    {
        public IEnumerable<TrainDto> Trains { get; set; }
        public int TrainsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Trains.Count() / (double)TrainsPerPage));
        }

        public IEnumerable<TrainDto> PaginatedTrains()
        {
            int start = (CurrentPage - 1) * TrainsPerPage;
            return Trains.OrderBy(x => x.Name).Skip(start).Take(TrainsPerPage);
        }
    }
}
