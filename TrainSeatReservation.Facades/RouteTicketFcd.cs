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
    public class RouteTicketFcd: IRouteTicketFcd
    {
        private readonly IRouteTicketService _service;

        public RouteTicketFcd(IRouteTicketService service)
        {
            _service = service;
        }

        public List<RouteTicketDto> GetRouteTickets()
        {
            return _service.GetRouteTickets();
        }
        public RouteTicketDto GetRouteTicket(int id)
        {
            return _service.GetRouteTicket(id);
        }
        public void AddRouteTicket(RouteTicketDto RouteTicket)
        {
            _service.AddRouteTicket(RouteTicket);
        }
        public void UpdateRouteTicket(RouteTicketDto RouteTicket)
        {
            _service.UpdateRouteTicket(RouteTicket);
        }
        public void DeleteRouteTicket(int id)
        {
            _service.DeleteRouteTicket(id);
        }
        public bool IsRouteTicketExists(int id)
        {
            return _service.IsRouteTicketExists(id);
        }
    }
}

