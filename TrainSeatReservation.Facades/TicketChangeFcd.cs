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
    public class TicketChangeFcd : ITicketChangeFcd
    {
        private readonly ITicketChangeService _service;

        public TicketChangeFcd(ITicketChangeService service)
        {
            _service = service;
        }

        public List<TicketChangeDto> GetTicketChanges()
        {
            return _service.GetTicketChanges();
        }
        public TicketChangeDto GetTicketChange(int id)
        {
            return _service.GetTicketChange(id);
        }
        public void AddTicketChange(TicketChangeDto TicketChange)
        {
            _service.AddTicketChange(TicketChange);
        }
        public void UpdateTicketChange(TicketChangeDto TicketChange)
        {
            _service.UpdateTicketChange(TicketChange);
        }
        public void DeleteTicketChange(int id)
        {
            _service.DeleteTicketChange(id);
        }
        public bool IsTicketChangeExists(int id)
        {
            return _service.IsTicketChangeExists(id);
        }
    }
}
