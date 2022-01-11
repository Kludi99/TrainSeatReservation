//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Facades
{
    public interface ICarriageFcd
    {
        List<CarriageDto> GetCarriages();
        CarriageDto GetCarriage(int id);
        void AddCarriage(CarriageDto carriage);
        void UpdateCarriage(CarriageDto carriage);
        void DeleteCarriage(int id);
        bool IsCarriageExists(int id);
    }
}
