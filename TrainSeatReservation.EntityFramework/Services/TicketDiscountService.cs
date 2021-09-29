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
    public class TicketDiscountService : ITicketDiscountService
    {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger _logger;
            public TicketDiscountService(ApplicationDbContext context,
                                    IMapper mapper,
                                    ILogger<TicketDiscountService> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public List<TicketDiscountDto> GetAllTicketDiscounts()
            {
                _logger.LogInformation("Executing GetTickets service method");
                return GetTicketDiscountsQuery().ToList();
            }
            public List<TicketDiscountDto> GetTicketDiscounts( int ticketId)
            {
                var ticketDiscounts = _context.TicketDiscounts
                    .Include(x => x.Ticket)
                    .Include(x => x.Discount)   
                    .Where(x => x.TicketId == ticketId);
                return _mapper.Map<TicketDiscountDto[]>(ticketDiscounts).ToList();
            }
            public TicketDiscountDto GetTicketDiscount(int id)
            {
                _logger.LogInformation("Executing GetTicket service method");
                return GetTicketDiscountDto(id);
            }
            public TicketDiscountDto AddTicketDiscount(TicketDiscountDto ticketDiscount)
            {
                _logger.LogInformation("Executing AddTicket service method");

                var entity = GetTicketDiscountEntity(ticketDiscount);
                entity.Id = 0;
                var result = _context.Add(entity);
                _context.SaveChanges();
                return _mapper.Map<TicketDiscountDto>(result.Entity);
            }
            public void UpdateTicketDiscount(TicketDiscountDto ticketDiscount)
            {
                _logger.LogInformation("Executing UpdateTicket service method");

                var entity = GetTicketDiscountEntity(ticketDiscount);
                _context.Update(entity);
                _context.SaveChanges();
            }
            public void DeleteTicketDiscount(int id)
            {
                _logger.LogInformation("Executing DeleteTicket service method");

                var entity = _context.Tickets.SingleOrDefault(x => x.Id == id);

                _context.Remove(entity);
                _context.SaveChanges();

            }
         
            public bool IsTicketDiscountExists(int id)
            {
                if (_context.Tickets.Any(x => x.Id == id))
                    return true;
                return false;
            }

            #region Private methods

            private TicketDiscountDto GetTicketDiscountDto(int id)
            {
                var ticket = _context.TicketDiscounts.AsNoTracking().SingleOrDefault(x => x.Id == id);
                try
                {
                    return _mapper.Map<TicketDiscountDto>(ticket);
                }
                catch
                {
                    return null;
                }
            }

            private TicketDiscount GetTicketDiscountEntity(TicketDiscountDto ticketDiscount)
            {
                try
                {
                    return _mapper.Map<TicketDiscount>(ticketDiscount);
                }
                catch
                {
                    return null;
                }
            }

            private IEnumerable<TicketDiscountDto> GetTicketDiscountsQuery()
            {
                var ticketDiscounts = _context.TicketDiscounts;
                try
                {
                    return _mapper.Map<TicketDiscountDto[]>(ticketDiscounts);
                }
                catch
                {
                    return Array.Empty<TicketDiscountDto>();
                }
            }
            #endregion
        }
    }
