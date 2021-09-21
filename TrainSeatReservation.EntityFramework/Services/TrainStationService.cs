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
    public class TrainStationService : ITrainStationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TrainStationService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<TrainStationService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<TrainStationDto> GetTrainStations()
        {
            _logger.LogInformation("Executing GetTrainStations service method");
            return GetTrainStationsQuery().ToList();
        }
        public TrainStationDto GetTrainStation(int id)
        {
            _logger.LogInformation("Executing GetTrainStation service method");
            return GetTrainStationDto(id);
        }
        public void AddTrainStation(TrainStationDto trainStation)
        {
            _logger.LogInformation("Executing AddTrainStation service method");

            var entity = GetTrainStationEntity(trainStation);
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateTrainStation(TrainStationDto trainStation)
        {
            _logger.LogInformation("Executing UpdateTrainStation service method");

            var entity = GetTrainStationEntity(trainStation);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void DeleteTrainStation(int id)
        {
            _logger.LogInformation("Executing DeleteTrainStation service method");

            var entity = _context.TrainStations
                .Include(t => t.Station)
                .Include(t => t.Train)
                .Include(t => t.TrainTimeTable)
                .SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
        public bool IsTrainStationExists(int id)
        {
            if (_context.TrainStations.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private TrainStationDto GetTrainStationDto(int id)
        {
            var trainStation = _context.TrainStations
                .Include(t => t.Station)
                .Include(t => t.Train)
                .Include(t => t.TrainTimeTable)
                .AsNoTracking().SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<TrainStationDto>(trainStation);
            }
            catch
            {
                return null;
            }
        }

        private TrainStation GetTrainStationEntity(TrainStationDto trainStation)
        {
            try
            {
                return _mapper.Map<TrainStation>(trainStation);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<TrainStationDto> GetTrainStationsQuery()
        {
            var trainStations = _context.TrainStations
                .Include(t => t.Station)
                .Include(t => t.Train)
                .Include(t => t.TrainTimeTable);
            try
            {
                return _mapper.Map<TrainStationDto[]>(trainStations);
            }
            catch
            {
                return Array.Empty<TrainStationDto>();
            }
        }
        #endregion
    }
}
