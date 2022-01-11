//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Infrastructure.Services
{
    public interface IRouteService
    {
        List<RouteDto> GetRoutes();
        RouteDto GetRoute(int id);
        void AddRoute(RouteDto route);
        void UpdateRoute(RouteDto route);
        void DeleteRoute(int id);
        bool IsRouteExists(int id);
    }
}
