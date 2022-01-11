//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Interfaces.Facades;
using TrainSeatReservation.Interfaces.Infrastructure.Services;

namespace TrainSeatReservation.Facades
{
    public class RouteFcd: IRouteFcd
    {
        private readonly IRouteService _service;

        public RouteFcd(IRouteService service)
        {
            _service = service;
        }

        public List<RouteDto> GetRoutes()
        {
            return _service.GetRoutes();
        }
        public RouteDto GetRoute(int id)
        {
            return _service.GetRoute(id);
        }
        public void AddRoute(RouteDto route)
        {
            _service.AddRoute(route);
        }
        public void UpdateRoute(RouteDto route)
        {
            _service.UpdateRoute(route);
        }
        public void DeleteRoute(int id)
        {
            _service.DeleteRoute(id);
        }
        public bool IsRouteExists(int id)
        {
            return _service.IsRouteExists(id);
        }
    }
}
