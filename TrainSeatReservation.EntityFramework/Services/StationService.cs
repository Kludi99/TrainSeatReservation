using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Data;
using TrainSeatReservation.EntityFramework.Models;
using TrainSeatReservation.Interfaces.Infrastructure.Services;

namespace TrainSeatReservation.EntityFramework.Services
{
    public class StationService : IStationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public StationService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<StationService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<StationDto> GetStations()
        {
            _logger.LogInformation("Executing GetStations service method");
            return GetStationsQuery().ToList();
        }
        public StationDto GetStation(int id)
        {
            _logger.LogInformation("Executing GetStation service method");
            return GetStationDto(id);
        }
        public void AddStation(StationDto station)
        {
            _logger.LogInformation("Executing AddStation service method");

            var entity = GetStationEntity(station);
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateStation(StationDto station)
        {
            _logger.LogInformation("Executing UpdateStation service method");

            var entity = GetStationEntity(station);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void DeleteStation(int id)
        {
            _logger.LogInformation("Executing DeleteStation service method");

            var entity = _context.Stations.SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
        public List<StationDto> FindStation(string prefix)
        {
            var entities = _context.Stations.Where(x => x.Name.Contains(prefix));
            var stations = _mapper.Map<StationDto[]>(entities);
            return stations.ToList();
        }
        public bool IsStationExists(int id)
        {
            if (_context.Stations.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private StationDto GetStationDto(int id)
        {
            var station = _context.Stations
                .Include(x => x.RouteStations)
                .Include(x => x.TrainStations)
                .AsNoTracking().SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<StationDto>(station);
            }
            catch
            {
                return null;
            }
        }

        private Station GetStationEntity(StationDto station)
        {
            try
            {
                return _mapper.Map<Station>(station);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<StationDto> GetStationsQuery()
        {
            var stations = _context.Stations
                .Include(x => x.RouteStations)
                .Include(x => x.TrainStations);
            try
            {
                return _mapper.Map<StationDto[]>(stations);
            }
            catch
            {
                return Array.Empty<StationDto>();
            }
        }
        #endregion
    }
}
