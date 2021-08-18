using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Data;
using TrainSeatReservation.EntityFramework.Models;
using TrainSeatReservation.Interfaces.Infrastructure.Services;

namespace TrainSeatReservation.EntityFramework.Services
{
    public class TrainService: ITrainService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TrainService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<TrainService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<TrainDto> GetTrains()
        {
            _logger.LogInformation("Executing GetTrains service method");
            return GetTrainsQuery().ToList();
        }
        public TrainDto GetTrain(int id)
        {
            _logger.LogInformation("Executing GetTrain service method");
            return GetTrainDto(id);
        }
        public void AddTrain(TrainDto train)
        {
            _logger.LogInformation("Executing AddTrain service method");

            var entity = GetTrainEntity(train);
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateTrain(TrainDto train)
        {
            _logger.LogInformation("Executing UpdateTrain service method");

            var entity = GetTrainEntity(train);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void DeleteTrain(int id)
        {
            _logger.LogInformation("Executing DeleteTrain service method");

            var entity = _context.Trains.SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
        public bool IsTrainExists(int id)
        {
            if (_context.Trains.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private TrainDto GetTrainDto(int id)
        {
            var user = _context.Trains.AsNoTracking().SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<TrainDto>(user);
            }
            catch
            {
                return null;
            }
        }

        private Train GetTrainEntity(TrainDto train)
        {
            try
            {
                return _mapper.Map<Train>(train);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<TrainDto> GetTrainsQuery()
        {
            var users = _context.Trains;
            try
            {
                return _mapper.Map<TrainDto[]>(users);
            }
            catch
            {
                return Array.Empty<TrainDto>();
            }
        }
        #endregion
    }
}
