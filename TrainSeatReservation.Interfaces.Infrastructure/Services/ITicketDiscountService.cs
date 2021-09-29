using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Infrastructure.Services
{
    public interface ITicketDiscountService
    {
        List<TicketDiscountDto> GetAllTicketDiscounts();
        List<TicketDiscountDto> GetTicketDiscounts(int ticketId);
        TicketDiscountDto GetTicketDiscount(int id);
        TicketDiscountDto AddTicketDiscount(TicketDiscountDto ticketDiscount);
        void UpdateTicketDiscount(TicketDiscountDto ticketDiscount);
        void DeleteTicketDiscount(int id);
        bool IsTicketDiscountExists(int id);
    }
}
