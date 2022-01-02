using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Configuration;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Data;
using TrainSeatReservation.Interfaces.Infrastructure.Services;

namespace TrainSeatReservation.EntityFramework.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public NotificationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void SendCarriageChangeMesssage(int carriageId, string content)
        {
            var tickets = GetTicketsWithCarriage(carriageId);
            var date = DateTime.Now;
            var filteredTickets = tickets.Where(x => x.SendInformation == true && x.TripDate.Date > date.Date && x.PhoneNumber != null)
                .GroupBy(x => x.PhoneNumber).ToList();
            foreach (var item in filteredTickets)
            {
                VonageConfig.Send(content, item.Key);
            }
        }

        private List<TicketDto> GetTicketsWithCarriage(int carriageId)
        {
            var train = _context.TrainCarriages.Where(x => x.CarriageId == carriageId).Select(x => x.TrainId).FirstOrDefault();
            var routeId = _context.RouteStations.Where(x => x.TrainId == train).Select(x => x.RouteId).FirstOrDefault();
            var ticketsIds = _context.RouteTickets.Where(x => x.RouteId == routeId).Select(x => x.TicketId).ToList();
            var tickets = _context.Tickets.Where(x => ticketsIds.Contains(x.Id));

            return _mapper.Map<TicketDto[]>(tickets).ToList();
        }

    }
}
