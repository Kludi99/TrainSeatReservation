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
    public class TrainFcd: ITrainFcd
    {
        private readonly ITrainService _service;

        public TrainFcd(ITrainService service)
        {
            _service = service;
        }

        public List<TrainDto> GetTrains()
        {
           return _service.GetTrains();
        }
        public TrainDto GetTrain(int id)
        {
            return _service.GetTrain(id);
        }
        public void AddTrain(TrainDto train)
        {
            _service.AddTrain(train);
        }
        public void AddTrainWithCarriages(TrainDto train, int compartmentless, int compartmental)
        {
            _service.AddTrainWithCarriages(train, compartmentless, compartmental);
        }
        public void UpdateTrain(TrainDto train)
        {
            _service.UpdateTrain(train);
        }
        public void DeleteTrain(int id)
        {
            _service.DeleteTrain(id);
        }
        public bool IsTrainExists(int id)
        {
            return _service.IsTrainExists(id);
        }
    }
}
