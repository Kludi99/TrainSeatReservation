using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Infrastructure.Services
{
    public interface ITicketChangeService
    {
        List<TicketChangeDto> GetTicketChanges();
        TicketChangeDto GetTicketChange(int id);
        void AddTicketChange(TicketChangeDto TicketChange);
        void UpdateTicketChange(TicketChangeDto TicketChange);
        void DeleteTicketChange(int id);
        bool IsTicketChangeExists(int id);
    }
}
