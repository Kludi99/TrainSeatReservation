//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Facades
{
    public interface ISeatTicketFcd
    {
        List<SeatTicketDto> GetSeatTickets();
        SeatTicketDto GetSeatTicket(int id);
        void AddSeatTicket(SeatTicketDto seatTicket);
        void UpdateSeatTicket(SeatTicketDto seatTicket);
        void DeleteSeatTicket(int id);
        bool IsSeatTicketExists(int id);
    }
}
