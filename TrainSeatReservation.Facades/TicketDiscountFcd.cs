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
    public class TicketDiscountFcd : ITicketDiscountFcd
    {
        private readonly ITicketDiscountService _service;

        public TicketDiscountFcd(ITicketDiscountService service)
        {
            _service = service;
        }

        public List<TicketDiscountDto> GetAllTicketDiscounts()
        {
            return _service.GetAllTicketDiscounts();
        }
        public TicketDiscountDto GetTicketDiscount(int id)
        {
            return _service.GetTicketDiscount(id);
        }
        public TicketDiscountDto AddTicketDiscount(TicketDiscountDto ticketDiscount)
        {
            return _service.AddTicketDiscount(ticketDiscount);
        }
        public void UpdateTicketDiscount(TicketDiscountDto ticketDiscount)
        {
            _service.UpdateTicketDiscount(ticketDiscount);
        }
        public void DeleteTicketDiscount(int id)
        {
            _service.DeleteTicketDiscount(id);
        }
        public bool IsTicketDiscountExists(int id)
        {
            return _service.IsTicketDiscountExists(id);
        }
        public List<TicketDiscountDto> GetTicketDiscounts(int ticketId)
        {
            return _service.GetTicketDiscounts(ticketId);
        }
    }
}
