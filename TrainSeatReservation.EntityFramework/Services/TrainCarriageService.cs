//Program powstał na Wydziale Informatyki Politechniki Białostockiej
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
    public class TrainCarriageService : ITrainCarriageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TrainCarriageService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<TrainCarriageService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<TrainCarriageDto> GetTrainCarriages()
        {
            _logger.LogInformation("Executing GetTrainCarriages service method");
            return GetTrainCarriagesQuery().ToList();
        }
        public TrainCarriageDto GetTrainCarriage(int id)
        {
            _logger.LogInformation("Executing GetTrainCarriage service method");
            return GetTrainCarriageDto(id);
        }
        public void AddTrainCarriage(TrainCarriageDto trainCarriage)
        {
            _logger.LogInformation("Executing AddTrainCarriage service method");

            var entity = GetTrainCarriageEntity(trainCarriage);
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateTrainCarriage(TrainCarriageDto trainCarriage)
        {
            _logger.LogInformation("Executing UpdateTrainCarriage service method");

            var entity = GetTrainCarriageEntity(trainCarriage);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void DeleteTrainCarriage(int id)
        {
            _logger.LogInformation("Executing DeleteTrainCarriage service method");

            var entity = _context.TrainCarriages.SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
        public bool IsTrainCarriageExists(int id)
        {
            if (_context.TrainCarriages.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private TrainCarriageDto GetTrainCarriageDto(int id)
        {
            var trainCarriage = _context.TrainCarriages.AsNoTracking().SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<TrainCarriageDto>(trainCarriage);
            }
            catch
            {
                return null;
            }
        }

        private TrainCarriage GetTrainCarriageEntity(TrainCarriageDto trainCarriage)
        {
            try
            {
                return _mapper.Map<TrainCarriage>(trainCarriage);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<TrainCarriageDto> GetTrainCarriagesQuery()
        {
            var trainCarriages = _context.TrainCarriages;
            try
            {
                return _mapper.Map<TrainCarriageDto[]>(trainCarriages);
            }
            catch
            {
                return Array.Empty<TrainCarriageDto>();
            }
        }
        #endregion
    }
}
