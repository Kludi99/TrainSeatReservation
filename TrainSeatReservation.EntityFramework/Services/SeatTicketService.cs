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
    public class SeatTicketService : ISeatTicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SeatTicketService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<SeatTicketService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<SeatTicketDto> GetSeatTickets()
        {
            _logger.LogInformation("Executing GetSeatTickets service method");
            return GetSeatTicketsQuery().ToList();
        }
        public SeatTicketDto GetSeatTicket(int id)
        {
            _logger.LogInformation("Executing GetSeatTicket service method");
            return GetSeatTicketDto(id);
        }
        public void AddSeatTicket(SeatTicketDto SeatTicket)
        {
            _logger.LogInformation("Executing AddSeatTicket service method");

            var entity = GetSeatTicketEntity(SeatTicket);
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateSeatTicket(SeatTicketDto SeatTicket)
        {
            _logger.LogInformation("Executing UpdateSeatTicket service method");

            var entity = GetSeatTicketEntity(SeatTicket);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void DeleteSeatTicket(int id)
        {
            _logger.LogInformation("Executing DeleteSeatTicket service method");

            var entity = _context.SeatTickets.SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
        public bool IsSeatTicketExists(int id)
        {
            if (_context.SeatTickets.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private SeatTicketDto GetSeatTicketDto(int id)
        {
            var SeatTicket = _context.SeatTickets.AsNoTracking()
                .Include(x => x.Seat)
                .Include(x => x.Ticket)
                .SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<SeatTicketDto>(SeatTicket);
            }
            catch
            {
                return null;
            }
        }

        private SeatTicket GetSeatTicketEntity(SeatTicketDto SeatTicket)
        {
            try
            {
                return _mapper.Map<SeatTicket>(SeatTicket);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<SeatTicketDto> GetSeatTicketsQuery()
        {
            var SeatTickets = _context.SeatTickets
                .AsNoTracking()
                .Include(x => x.Seat)
                    .ThenInclude(x => x.Carriage)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.DepartureTrainStation)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.ArrivalTrainStation);
            try
            {
                return _mapper.Map<SeatTicketDto[]>(SeatTickets);
            }
            catch
            {
                return Array.Empty<SeatTicketDto>();
            }
        }
        #endregion
    }
}
