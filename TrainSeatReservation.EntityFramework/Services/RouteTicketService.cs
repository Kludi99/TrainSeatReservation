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
    public class RouteTicketService : IRouteTicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public RouteTicketService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<RouteTicketService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<RouteTicketDto> GetRouteTickets()
        {
            _logger.LogInformation("Executing GetRouteTickets service method");
            return GetRouteTicketsQuery().ToList();
        }
        public RouteTicketDto GetRouteTicket(int id)
        {
            _logger.LogInformation("Executing GetRouteTicket service method");
            return GetRouteTicketDto(id);
        }
        public void AddRouteTicket(RouteTicketDto RouteTicket)
        {
            _logger.LogInformation("Executing AddRouteTicket service method");

            var entity = GetRouteTicketEntity(RouteTicket);
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateRouteTicket(RouteTicketDto RouteTicket)
        {
            _logger.LogInformation("Executing UpdateRouteTicket service method");

            var entity = GetRouteTicketEntity(RouteTicket);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void DeleteRouteTicket(int id)
        {
            _logger.LogInformation("Executing DeleteRouteTicket service method");

            var entity = _context.RouteTickets.SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
        public bool IsRouteTicketExists(int id)
        {
            if (_context.RouteTickets.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private RouteTicketDto GetRouteTicketDto(int id)
        {
            var RouteTicket = _context.RouteTickets.AsNoTracking()
                .Include(x => x.Route)
                .Include(x => x.Ticket)
                .SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<RouteTicketDto>(RouteTicket);
            }
            catch
            {
                return null;
            }
        }

        private RouteTicket GetRouteTicketEntity(RouteTicketDto RouteTicket)
        {
            try
            {
                return _mapper.Map<RouteTicket>(RouteTicket);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<RouteTicketDto> GetRouteTicketsQuery()
        {
            var RouteTickets = _context.RouteTickets
                .AsNoTracking()
                .Include(x => x.Route)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.DepartureTrainStation)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.ArrivalTrainStation);
            try
            {
                return _mapper.Map<RouteTicketDto[]>(RouteTickets);
            }
            catch
            {
                return Array.Empty<RouteTicketDto>();
            }
        }
        #endregion
    }
}
