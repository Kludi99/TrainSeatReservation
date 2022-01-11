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
    public class SeatFcd : ISeatFcd
    {
        private readonly ISeatService _service;

        public SeatFcd(ISeatService service)
        {
            _service = service;
        }

        public List<SeatDto> GetSeats()
        {
            return _service.GetSeats();
        }
        public List<SeatDto> GetSeatsInCarriage(int carriageId)
        {
            return _service.GetSeatsInCarriage(carriageId);
        }
        public SeatDto GetSeat(int id)
        {
            return _service.GetSeat(id);
        }
        public void AddSeat(SeatDto seat)
        {
            _service.AddSeat(seat);
        }
        public void UpdateSeat(SeatDto seat)
        {
            _service.UpdateSeat(seat);
        }
        public void DeleteSeat(int id)
        {
            _service.DeleteSeat(id);
        }
        public bool IsSeatExists(int id)
        {
            return _service.IsSeatExists(id);
        }
    }
}
