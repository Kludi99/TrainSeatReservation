//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Areas.Administration.Models
{
    public class CarriageViewModel
    {
        public IEnumerable<CarriageDto> Carriages { get; set; }
        public int CarriagesPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Carriages.Count() / (double)CarriagesPerPage));
        }

        public IEnumerable<CarriageDto> PaginatedCarriages()
        {
            int start = (CurrentPage - 1) * CarriagesPerPage;
            return Carriages.OrderByDescending(x => x.Id).Skip(start).Take(CarriagesPerPage);
        }
    }
}
