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
    public class TicketChangeService :ITicketChangeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TicketChangeService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<TicketChangeService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<TicketChangeDto> GetTicketChanges()
        {
            _logger.LogInformation("Executing GetTicketChanges service method");
            return GetTicketChangesQuery().ToList();
        }
        public TicketChangeDto GetTicketChange(int id)
        {
            _logger.LogInformation("Executing GetTicketChanges service method");
            return GetTicketChangesDto(id);
        }
        public void AddTicketChange(TicketChangeDto ticketChange)
        {
            _logger.LogInformation("Executing AddTicketChanges service method");

            var entity = GetTicketChangesEntity(ticketChange);
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateTicketChange(TicketChangeDto ticketChange)
        {
            _logger.LogInformation("Executing UpdateTicketChanges service method");

            var entity = GetTicketChangesEntity(ticketChange);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void DeleteTicketChange(int id)
        {
            _logger.LogInformation("Executing DeleteTicketChanges service method");

            var entity = _context.TicketChanges.SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
        public bool IsTicketChangeExists(int id)
        {
            if (_context.TicketChanges.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private TicketChangeDto GetTicketChangesDto(int id)
        {
            var TicketChanges = _context.TicketChanges.AsNoTracking()
                .Include(x => x.Station)
                .Include(x => x.Ticket)
                .SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<TicketChangeDto>(TicketChanges);
            }
            catch
            {
                return null;
            }
        }

        private TicketChange GetTicketChangesEntity(TicketChangeDto ticketChange)
        {
            try
            {
                return _mapper.Map<TicketChange>(ticketChange);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<TicketChangeDto> GetTicketChangesQuery()
        {
            var ticketChanges = _context.TicketChanges
                .AsNoTracking()
                .Include(x => x.Station)
                .Include(x => x.Ticket);
            try
            {
                return _mapper.Map<TicketChangeDto[]>(ticketChanges);
            }
            catch
            {
                return Array.Empty<TicketChangeDto>();
            }
        }
        #endregion
    }
}
