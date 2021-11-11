using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Infrastructure.Services
{
    public interface IRouteTicketService
    {
        List<RouteTicketDto> GetRouteTickets();
        RouteTicketDto GetRouteTicket(int id);
        void AddRouteTicket(RouteTicketDto routeTicket);
        void UpdateRouteTicket(RouteTicketDto routeTicket);
        void DeleteRouteTicket(int id);
        bool IsRouteTicketExists(int id);
    }
}
