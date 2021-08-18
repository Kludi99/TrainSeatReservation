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
    public class CarriageFcd : ICarriageFcd
    {
        private readonly ICarriageService _service;

        public CarriageFcd(ICarriageService service)
        {
            _service = service;
        }

        public List<CarriageDto> GetCarriages()
        {
            return _service.GetCarriages();
        }
        public CarriageDto GetCarriage(int id)
        {
            return _service.GetCarriage(id);
        }
        public void AddCarriage(CarriageDto carriage)
        {
            _service.AddCarriage(carriage);
        }
        public void UpdateCarriage(CarriageDto carriage)
        {
            _service.UpdateCarriage(carriage);
        }
        public void DeleteCarriage(int id)
        {
            _service.DeleteCarriage(id);
        }
        public bool IsCarriageExists(int id)
        {
            return _service.IsCarriageExists(id);
        }
    }
}
