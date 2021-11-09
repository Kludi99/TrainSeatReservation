using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Infrastructure.Services
{
    public interface ITicketService
    {
        List<TicketDto> GetTickets();
        List<TicketDto> GetTrainTicketsWithDate(DateTime date, int trainId);
        TicketDto GetTicket(int id);
        TicketDto AddTicket(TicketDto ticket);
        TicketDto UpdateTicket(TicketDto ticket);
        void DeleteTicket(int id);
        bool IsTicketExists(int id);
        
    }
}
