using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Facades
{
    public interface ITicketFcd
    {
        List<TicketDto> GetTickets();
        List<TicketResignedDto> GetResignedTickets();
        List<TicketDto> GetTrainTicketsWithDate(DateTime date, int trainId);
        TicketDto GetTicket(int id);
        TicketDto AddTicket(TicketDto ticket);
        TicketDto UpdateTicket(TicketDto ticket);
        void DeleteTicket(int id);
        bool IsTicketExists(int id);
    }
}
