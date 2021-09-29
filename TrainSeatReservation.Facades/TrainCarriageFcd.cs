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
    public class TrainCarriageFcd :ITrainCarriageFcd
    {
        private readonly ITrainCarriageService _service;

        public TrainCarriageFcd(ITrainCarriageService service)
        {
            _service = service;
        }

        public List<TrainCarriageDto> GetTrainCarriages()
        {
            return _service.GetTrainCarriages();
        }
        public TrainCarriageDto GetTrainCarriage(int id)
        {
            return _service.GetTrainCarriage(id);
        }
        public void AddTrainCarriage(TrainCarriageDto trainCarriage)
        {
            _service.AddTrainCarriage(trainCarriage);
        }
        public void UpdateTrainCarriage(TrainCarriageDto trainCarriage)
        {
            _service.UpdateTrainCarriage(trainCarriage);
        }
        public void DeleteTrainCarriage(int id)
        {
            _service.DeleteTrainCarriage(id);
        }
        public bool IsTrainCarriageExists(int id)
        {
            return _service.IsTrainCarriageExists(id);
        }
    }
}
