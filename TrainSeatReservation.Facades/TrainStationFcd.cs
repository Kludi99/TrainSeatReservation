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
    public class TrainStationFcd : ITrainStationFcd
    {
        private readonly ITrainStationService _service;

        public TrainStationFcd(ITrainStationService service)
        {
            _service = service;
        }

        public List<TrainStationDto> GetTrainStations()
        {
            return _service.GetTrainStations();
        }
        public List<TrainStationDto> GetTrainsFromStation(int stationId)
        {
            return _service.GetTrainsFromStation(stationId);
        }
        public TrainStationDto GetTrainStation(int id)
        {
            return _service.GetTrainStation(id);
        }
        public void AddTrainStation(TrainStationDto trainStation)
        {
            _service.AddTrainStation(trainStation);
        }
        public void UpdateTrainStation(TrainStationDto trainStation)
        {
            _service.UpdateTrainStation(trainStation);
        }
        public void DeleteTrainStation(int id)
        {
            _service.DeleteTrainStation(id);
        }
        public bool IsTrainStationExists(int id)
        {
            return _service.IsTrainStationExists(id);
        }
    }
}
