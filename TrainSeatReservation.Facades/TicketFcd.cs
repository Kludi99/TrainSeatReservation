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
    public class TicketFcd : ITicketFcd
    {
        private readonly ITicketService _service;

        public TicketFcd(ITicketService service)
        {
            _service = service;
        }

        public List<TicketDto> GetTickets()
        {
            return _service.GetTickets();
        }
        public TicketDto GetTicket(int id)
        {
            return _service.GetTicket(id);
        }
        public TicketDto AddTicket(TicketDto Ticket)
        {
           return  _service.AddTicket(Ticket);
        }
        public void UpdateTicket(TicketDto Ticket)
        {
            _service.UpdateTicket(Ticket);
        }
        public void DeleteTicket(int id)
        {
            _service.DeleteTicket(id);
        }
        public bool IsTicketExists(int id)
        {
            return _service.IsTicketExists(id);
        }
        public List<TicketDto> GetTrainTicketsWithDate(DateTime date, int trainId)
        {
            return _service.GetTrainTicketsWithDate(date, trainId);
        }
    }
}
