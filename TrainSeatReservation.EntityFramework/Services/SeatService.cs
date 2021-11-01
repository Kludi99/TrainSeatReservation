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
    public class SeatService :ISeatService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SeatService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<SeatService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<SeatDto> GetSeats()
        {
            _logger.LogInformation("Executing GetSeats service method");
            return GetSeatsQuery().ToList();
        }
        public List<SeatDto> GetSeatsInCarriage(int carriageId)
        {
            _logger.LogInformation("Executing GetSeatsInCarriage service method");
            return GetSeatsInCarriageQuery(carriageId).ToList();
        }
        public SeatDto GetSeat(int id)
        {
            _logger.LogInformation("Executing GetSeat service method");
            return GetSeatDto(id);
        }
        public void AddSeat(SeatDto seat)
        {
            _logger.LogInformation("Executing AddSeat service method");

            var entity = GetSeatEntity(seat);
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateSeat(SeatDto seat)
        {
            _logger.LogInformation("Executing UpdateSeat service method");

            var entity = GetSeatEntity(seat);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void DeleteSeat(int id)
        {
            _logger.LogInformation("Executing DeleteSeat service method");

            var entity = _context.Seats.SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
       
        public bool IsSeatExists(int id)
        {
            if (_context.Seats.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private SeatDto GetSeatDto(int id)
        {
            var seat = _context.Seats.AsNoTracking().SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<SeatDto>(seat);
            }
            catch
            {
                return null;
            }
        }

        private Seat GetSeatEntity(SeatDto seat)
        {
            try
            {
                return _mapper.Map<Seat>(seat);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<SeatDto> GetSeatsQuery()
        {
            var seats = _context.Seats;
            try
            {
                return _mapper.Map<SeatDto[]>(seats);
            }
            catch
            {
                return Array.Empty<SeatDto>();
            }
        }
        private IEnumerable<SeatDto> GetSeatsInCarriageQuery(int carriageId)
        {
            var seats = _context.Seats.Where(x => x.CarriageId == carriageId).AsNoTracking();
            try
            {
                return _mapper.Map<SeatDto[]>(seats);
            }
            catch
            {
                return Array.Empty<SeatDto>();
            }
        }
        #endregion
    }
}
