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
    public class StationFcd : IStationFcd
    {
        private readonly IStationService _service;

        public StationFcd(IStationService service)
        {
            _service = service;
        }

        public List<StationDto> GetStations()
        {
            return _service.GetStations();
        }
        public StationDto GetStation(int id)
        {
            return _service.GetStation(id);
        }
        public void AddStation(StationDto station)
        {
            _service.AddStation(station);
        }
        public void UpdateStation(StationDto station)
        {
            _service.UpdateStation(station);
        }
        public void DeleteStation(int id)
        {
            _service.DeleteStation(id);
        }
        public bool IsStationExists(int id)
        {
            return _service.IsStationExists(id);
        }
    }
}
