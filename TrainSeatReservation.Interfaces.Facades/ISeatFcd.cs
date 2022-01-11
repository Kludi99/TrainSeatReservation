//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Facades
{
    public interface ISeatFcd
    {

        List<SeatDto> GetSeats();
        List<SeatDto> GetSeatsInCarriage(int carriageId);
        SeatDto GetSeat(int id);
        void AddSeat(SeatDto seat);
        void UpdateSeat(SeatDto seat);
        void DeleteSeat(int id);
        bool IsSeatExists(int id);
    }
}
