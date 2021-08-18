using AutoMapper;
using TrainSeatReservation.Interfaces.Infrastructure.Services;
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

namespace TrainSeatReservation.EntityFramework.Services
{
    public class CarriageService : ICarriageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CarriageService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<CarriageService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<CarriageDto> GetCarriages()
        {
            _logger.LogInformation("Executing GetCarriages service method");
            return GetCarriagesQuery().ToList();
        }
        public CarriageDto GetCarriage(int id)
        {
            _logger.LogInformation("Executing GetCarriage service method");
            return GetCarriageDto(id);
        }
        public void AddCarriage(CarriageDto carriage)
        {
            _logger.LogInformation("Executing AddCarriage service method");

            var entity = GetCarriageEntity(carriage);
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateCarriage(CarriageDto carriage)
        {
            _logger.LogInformation("Executing UpdateCarriage service method");

            var entity = GetCarriageEntity(carriage);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void DeleteCarriage(int id)
        {
            _logger.LogInformation("Executing DeleteCarriage service method");

            var entity = _context.Carriages.SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
        public bool IsCarriageExists(int id)
        {
            if (_context.Carriages.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private CarriageDto GetCarriageDto(int id)
        {
            var user = _context.Carriages.AsNoTracking().SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<CarriageDto>(user);
            }
            catch
            {
                return null;
            }
        }

        private Carriage GetCarriageEntity(CarriageDto carriage)
        {
            try
            {
                return _mapper.Map<Carriage>(carriage);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<CarriageDto> GetCarriagesQuery()
        {
            var users = _context.Carriages;
            try
            {
                return _mapper.Map<CarriageDto[]>(users);
            }
            catch
            {
                return Array.Empty<CarriageDto>();
            }
        }
        #endregion
    }
}
