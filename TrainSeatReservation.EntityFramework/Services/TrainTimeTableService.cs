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
    public class TrainTimeTableService : ITrainTimeTableService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TrainTimeTableService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<TrainTimeTableService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<TrainTimeTableDto> GetTrainTimeTables()
        {
            _logger.LogInformation("Executing GetTrainTimeTables service method");
            return GetTrainTimeTablesQuery().ToList();
        }
        public TrainTimeTableDto GetTrainTimeTable(int id)
        {
            _logger.LogInformation("Executing GetTrainTimeTable service method");
            return GetTrainTimeTableDto(id);
        }
        public void AddTrainTimeTable(TrainTimeTableDto trainTimeTable)
        {
            _logger.LogInformation("Executing AddTrainTimeTable service method");

            var entity = GetTrainTimeTableEntity(trainTimeTable);
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateTrainTimeTable(TrainTimeTableDto trainTimeTable)
        {
            _logger.LogInformation("Executing UpdateTrainTimeTable service method");

            var entity = GetTrainTimeTableEntity(trainTimeTable);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void DeleteTrainTimeTable(int id)
        {
            _logger.LogInformation("Executing DeleteTrainTimeTable service method");

            var entity = _context.TrainTimeTables.SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
        public bool IsTrainTimeTableExists(int id)
        {
            if (_context.TrainTimeTables.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private TrainTimeTableDto GetTrainTimeTableDto(int id)
        {
            var trainTimeTable = _context.TrainTimeTables
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<TrainTimeTableDto>(trainTimeTable);
            }
            catch
            {
                return null;
            }
        }

        private TrainTimeTable GetTrainTimeTableEntity(TrainTimeTableDto trainTimeTable)
        {
            try
            {
                return _mapper.Map<TrainTimeTable>(trainTimeTable);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<TrainTimeTableDto> GetTrainTimeTablesQuery()
        {
            var trainTimeTables = _context.TrainTimeTables;
            try
            {
                return _mapper.Map<TrainTimeTableDto[]>(trainTimeTables);
            }
            catch
            {
                return Array.Empty<TrainTimeTableDto>();
            }
        }
        #endregion
    }
}
