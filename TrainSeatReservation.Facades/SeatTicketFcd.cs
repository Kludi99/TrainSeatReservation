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
    public class SeatTicketFcd : ISeatTicketFcd
    {
        private readonly ISeatTicketService _service;

        public SeatTicketFcd(ISeatTicketService service)
        {
            _service = service;
        }
        public List<SeatTicketDto> GetSeatTickets()
        {
            return _service.GetSeatTickets();
        }
        public SeatTicketDto GetSeatTicket(int id)
        {
            return _service.GetSeatTicket(id);
        }
        public void AddSeatTicket(SeatTicketDto seatTicket)
        {
            _service.AddSeatTicket(seatTicket);
        }
        public void UpdateSeatTicket(SeatTicketDto seatTicket)
        {
            _service.UpdateSeatTicket(seatTicket);
        }
        public void DeleteSeatTicket(int id)
        {
            _service.DeleteSeatTicket(id);
        }
        public bool IsSeatTicketExists(int id)
        {
            return _service.IsSeatTicketExists(id);
        }
    }
}
