﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Infrastructure.Services
{
    public interface ITrainStationService
    {
        List<TrainStationDto> GetTrainStations();
        TrainStationDto GetTrainStation(int id);
        void AddTrainStation(TrainStationDto trainStation);
        void UpdateTrainStation(TrainStationDto trainStation);
        void DeleteTrainStation(int id);
        bool IsTrainStationExists(int id);
    }
}
