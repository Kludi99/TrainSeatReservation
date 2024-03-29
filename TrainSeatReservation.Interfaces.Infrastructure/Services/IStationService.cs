﻿//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Interfaces.Infrastructure.Services
{
    public interface IStationService
    {
        List<StationDto> GetStations();
        StationDto GetStation(int id);
        void AddStation(StationDto station);
        void UpdateStation(StationDto station);
        void DeleteStation(int id);
        bool IsStationExists(int id);
        List<StationDto> FindStation(string prefix);
    }
}
