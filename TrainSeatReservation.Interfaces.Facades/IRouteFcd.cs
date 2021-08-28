using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Facades
{
    public interface IRouteFcd
    {
        List<RouteDto> GetRoutes();
        RouteDto GetRoute(int id);
        void AddRoute(RouteDto route);
        void UpdateRoute(RouteDto route);
        void DeleteRoute(int id);
        bool IsRouteExists(int id);
    }
}
