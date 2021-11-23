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
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TicketService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<TicketService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<TicketDto> GetTickets()
        {
            _logger.LogInformation("Executing GetTickets service method");
            return GetTicketsQuery().ToList();
        }
        public List<TicketDto> GetTrainTicketsWithDate(DateTime date, int trainId)
        {
            var tickets = _context.Tickets
                .Include( x => x.SeatTickets)
                .Include(x => x.ArrivalTrainStation)
                    .ThenInclude(x => x.TrainTimeTable)
                .Include(x => x.DepartureTrainStation)
                    .ThenInclude(x => x.TrainTimeTable)
                .Where(x => x.TripDate.Date == date.Date && x.DepartureTrainStation.TrainId == trainId);
            return _mapper.Map<TicketDto[]>(tickets).ToList();
        }
        public TicketDto GetTicket(int id)
        {
            _logger.LogInformation("Executing GetTicket service method");
            return GetTicketDto(id);
        }
        public TicketDto AddTicket(TicketDto ticket)
        {
            _logger.LogInformation("Executing AddTicket service method");

            var entity = GetTicketEntity(ticket);
            entity.Id = 0;
            entity.CreateDate = DateTime.Now;
            var result = _context.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<TicketDto>(result.Entity);
        }
        public TicketDto UpdateTicket(TicketDto ticket)
        {
            _logger.LogInformation("Executing UpdateTicket service method");

            //var entity = GetTicketEntity(ticket);
            var ticketDto = _context.Tickets.Where(x => x.Id == ticket.Id).FirstOrDefault();
            ticketDto.Email = ticket.Email;
            ticketDto.Name = ticket.Name;
            ticketDto.Surname = ticket.Surname;
            ticketDto.UserId = ticket.UserId;
            ticketDto.PhoneNumber = ticket.PhoneNumber;
            ticketDto.IsPaid = ticket.IsPaid;
            var result = _context.Update(ticketDto);
            _context.SaveChanges();
            return _mapper.Map<TicketDto>(result.Entity);
        }
        public void DeleteTicket(int id)
        {
            _logger.LogInformation("Executing DeleteTicket service method");

            var entity = _context.Tickets.SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
        public List<TicketDto> FindTicket(string prefix)
        {
            var entities = _context.Tickets.Where(x => x.Name.Contains(prefix));
            var tickets = _mapper.Map<TicketDto[]>(entities);
            return tickets.ToList();
        }
        public bool IsTicketExists(int id)
        {
            if (_context.Tickets.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private TicketDto GetTicketDto(int id)
        {
            var ticket = _context.Tickets.AsNoTracking()
                .Include(x => x.ArrivalTrainStation)
                .ThenInclude(x => x.TrainTimeTable)
                .Include(x => x.DepartureTrainStation)
                .ThenInclude(x => x.TrainTimeTable)
                .Include(x => x.ArrivalStation)
                .Include(x => x.DepartureStation)
                .SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<TicketDto>(ticket);
            }
            catch
            {
                return null;
            }
        }

        private Ticket GetTicketEntity(TicketDto ticket)
        {
            try
            {
                return _mapper.Map<Ticket>(ticket);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<TicketDto> GetTicketsQuery()
        {
            var tickets = _context.Tickets.Include(x => x.ArrivalTrainStation)
                .ThenInclude(x => x.TrainTimeTable)
                .Include(x => x.DepartureTrainStation)
                .ThenInclude(x => x.TrainTimeTable)
                .Include(x => x.ArrivalStation)
                .Include(x => x.DepartureStation)
                .AsNoTracking();
            try
            {
                return _mapper.Map<TicketDto[]>(tickets);
            }
            catch
            {
                return Array.Empty<TicketDto>();
            }
        }
        #endregion
    }
}
