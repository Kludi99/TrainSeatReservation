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
    public class RouteStationFcd : IRouteStationFcd
    {
        private readonly IRouteStationService _service;

        public RouteStationFcd(IRouteStationService service)
        {
            _service = service;
        }

        public List<RouteStationDto> GetRouteStations()
        {
            return _service.GetRouteStations();
        }
        public RouteStationDto GetRouteStation(int id)
        {
            return _service.GetRouteStation(id);
        }
        public void AddRouteStation(RouteStationDto routeStation)
        {
            _service.AddRouteStation(routeStation);
        }
        public void UpdateRouteStation(RouteStationDto routeStation)
        {
            _service.UpdateRouteStation(routeStation);
        }
        public void DeleteRouteStation(int id)
        {
            _service.DeleteRouteStation(id);
        }
        public bool IsRouteStationExists(int id)
        {
            return _service.IsRouteStationExists(id);
        }
    }
}
