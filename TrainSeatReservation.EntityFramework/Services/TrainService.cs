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
        public void AddTrainWithCarriages(TrainDto train, int compartmentless, int compartmental)
        {
            _logger.LogInformation("Executing AddTrainWithCarriages service method");
            var trainEntity = AddTrainEntity(train);
            var carriages = _context.Carriages.Include(x =>x.Type).Where(x =>x.IsActive); // all carriages add flag isUsed
            var compartmentlessCarriages = carriages.Where(x => x.Type.Name == "Bezprzedziałowy").OrderByDescending(x => x.Seats.Count());
            var compartmentalCarriages = carriages.Where(x => x.Type.Name == "Przedziałowy").OrderByDescending(x => x.Seats.Count());

            if (compartmentalCarriages.Count() >= compartmental && compartmentlessCarriages.Count() >= compartmentless)
            {

                var compartmentlessCarriagesList = compartmentlessCarriages.ToList();
                var compartmentalCarriagesList = compartmentalCarriages.ToList();

                for (int i = 0; i < compartmentless; i++)
                {

                    var trainCarriage = new TrainCarriage
                    {
                        TrainId = trainEntity.Id,
                        CarriageId = compartmentlessCarriagesList[i].Id
                    };

                    _context.Add(trainCarriage);
                }
                for (int i = 0; i < compartmental; i++)
                {

                    var trainCarriage = new TrainCarriage
                    {
                        TrainId = trainEntity.Id,
                        CarriageId = compartmentalCarriagesList[i].Id
                    };

                    _context.Add(trainCarriage);
                }
                _context.SaveChanges();
            }
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

        private Train AddTrainEntity(TrainDto train)
        {
            _logger.LogInformation("Executing AddTrain service method");

            var entity = GetTrainEntity(train);
            var result = _context.Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }
        private TrainDto GetTrainDto(int id)
        {
            var train = _context.Trains
                .Include(x => x.Type)
                .Include(x => x.Route)
                .Include(x => x.TrainCarriages)
                    .ThenInclude(x => x.Carriage)
                        .ThenInclude(x => x.CarriageClass)
                .Include(x => x.TrainCarriages)
                    .ThenInclude(x => x.Carriage)
                        .ThenInclude(x => x.Type)
                .Include(x => x.TrainCarriages)
                    .ThenInclude(x => x.Carriage)
                        .ThenInclude(x => x.Seats)
                .AsNoTracking().SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<TrainDto>(train);
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
            var trains = _context.Trains
                .Include(x => x.Type)
                .Include(x => x.Route)
                .Include(x => x.TrainCarriages)
                    .ThenInclude(x => x.Carriage)
                        .ThenInclude(x => x.CarriageClass)
                .Include(x => x.TrainCarriages)
                    .ThenInclude(x => x.Carriage)
                        .ThenInclude(x => x.Type)
                .Include(x => x.TrainCarriages)
                    .ThenInclude(x => x.Carriage)
                        .ThenInclude(x => x.Seats);
            try
            {
                return _mapper.Map<TrainDto[]>(trains);
            }
            catch
            {
                return Array.Empty<TrainDto>();
            }
        }
        #endregion
    }
}
