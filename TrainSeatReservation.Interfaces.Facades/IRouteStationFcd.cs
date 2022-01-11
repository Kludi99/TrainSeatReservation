//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Facades
{
    public interface IRouteStationFcd
    {
        List<RouteStationDto> GetRouteStations();
        RouteStationDto GetRouteStation(int id);
        void AddRouteStation(RouteStationDto routeStation);
        void UpdateRouteStation(RouteStationDto routeStation);
        void DeleteRouteStation(int id);
        bool IsRouteStationExists(int id);
    }
}
