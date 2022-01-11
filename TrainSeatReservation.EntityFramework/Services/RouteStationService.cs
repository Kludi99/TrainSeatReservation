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
    public class RouteStationService : IRouteStationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public RouteStationService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<RouteStationService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<RouteStationDto> GetRouteStations()
        {
            _logger.LogInformation("Executing GetRouteStations service method");
            return GetRouteStationsQuery().ToList();
        }
        public List<RouteStationDto> GetRoutesFromStation(int stationId)
        {
            _logger.LogInformation("Executing GetRouteStations service method");
            var routesStation = _context.RouteStations
               .Include(t => t.EndStation)
               .Include(t => t.StartStation)
               .Include(t => t.Route)
               .Include(t => t.Train)
               .Include(t => t.StartTrainTimeTable)
               .Include(t => t.EndTrainTimeTable)
               .AsNoTracking().Where(x => x.StartStationId == stationId);
            return _mapper.Map<RouteStationDto[]>(routesStation).ToList();
        }
        public RouteStationDto GetRouteStation(int id)
        {
            _logger.LogInformation("Executing GetRouteStation service method");
            return GetRouteStationDto(id);
        }
        public void AddRouteStation(RouteStationDto routeStation)
        {
            _logger.LogInformation("Executing AddRouteStation service method");

            var entity = GetRouteStationEntity(routeStation);
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateRouteStation(RouteStationDto routeStation)
        {
            _logger.LogInformation("Executing UpdateRouteStation service method");

            var entity = GetRouteStationEntity(routeStation);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void DeleteRouteStation(int id)
        {
            _logger.LogInformation("Executing DeleteRouteStation service method");

            var entity = _context.RouteStations.SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
        /* public List<RouteDto> GetRoutesWithStations(int firstStation, int lastStation)
         {
             var routes = _context.Routes.Include(x => x.RouteStations).Where(x => x.RouteStations.)
         } */
        public bool IsRouteStationExists(int id)
        {
            if (_context.Routes.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private RouteStationDto GetRouteStationDto(int id)
        {
            var routeStation = _context.RouteStations
                .Include(x => x.EndStation)
                .Include(x => x.StartStation)
                .Include(x => x.Route)
                .Include(t => t.Train)
                .Include(t => t.StartTrainTimeTable)
                .Include(t => t.EndTrainTimeTable)
                .AsNoTracking().SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<RouteStationDto>(routeStation);
            }
            catch
            {
                return null;
            }
        }

        private RouteStation GetRouteStationEntity(RouteStationDto routeStation)
        {
            try
            {
                return _mapper.Map<RouteStation>(routeStation);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<RouteStationDto> GetRouteStationsQuery()
        {
            var routeStations = _context.RouteStations.Include(x => x.EndStation)
                .ThenInclude(x => x.TrainStations)

                .Include(x => x.StartStation)
                .ThenInclude(x => x.TrainStations)
                .Include(t => t.Train)
                .Include(t => t.StartTrainTimeTable)
                .Include(t => t.EndTrainTimeTable)
                .Include(x => x.Route).AsQueryable();
            try
            {
                return _mapper.Map<RouteStationDto[]>(routeStations);
            }
            catch
            {
                return Array.Empty<RouteStationDto>();
            }
        }
        #endregion
    }
}
