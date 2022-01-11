//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Areas.Administration.Models
{
    public class RouteViewModel
    {
        public IEnumerable<RouteDto> Routes { get; set; }
        public int RoutesPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Routes.Count() / (double)RoutesPerPage));
        }

        public IEnumerable<RouteDto> PaginatedRoutes()
        {
            int start = (CurrentPage - 1) * RoutesPerPage;
            return Routes.OrderBy(x => x.Name).Skip(start).Take(RoutesPerPage);
        }
    }
}
