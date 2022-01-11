//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using AutoMapper;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.Data;
using TrainSeatReservation.Interfaces.Infrastructure.Services;

namespace TrainSeatReservation.EntityFramework.Services
{
    public class RouteService : IRouteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public RouteService(ApplicationDbContext context,
                                IMapper mapper,
                                ILogger<RouteService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<RouteDto> GetRoutes()
        {
            _logger.LogInformation("Executing GetRoutes service method");
            return GetRoutesQuery().ToList();
        }
        public RouteDto GetRoute(int id)
        {
            _logger.LogInformation("Executing GetRoute service method");
            return GetRouteDto(id);
        }
        public void AddRoute(RouteDto route)
        {
            _logger.LogInformation("Executing AddRoute service method");

            var entity = GetRouteEntity(route);
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateRoute(RouteDto route)
        {
            _logger.LogInformation("Executing UpdateRoute service method");

            var entity = GetRouteEntity(route);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void DeleteRoute(int id)
        {
            _logger.LogInformation("Executing DeleteRoute service method");

            var entity = _context.Routes.SingleOrDefault(x => x.Id == id);

            _context.Remove(entity);
            _context.SaveChanges();

        }
       /* public List<RouteDto> GetRoutesWithStations(int firstStation, int lastStation)
        {
            var routes = _context.Routes.Include(x => x.RouteStations).Where(x => x.RouteStations.)
        } */
        public bool IsRouteExists(int id)
        {
            if (_context.Routes.Any(x => x.Id == id))
                return true;
            return false;
        }

        #region Private methods

        private RouteDto GetRouteDto(int id)
        {
            var route = _context.Routes
                .Include(x => x.RouteStations)
                   // .ThenInclude(x => x.Route)
                .Include(x => x.RouteStations)
                    .ThenInclude(x => x.StartStation)
                .Include(x => x.RouteStations)
                    .ThenInclude(x => x.EndStation)
                .Include(x => x.Train)
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);
            try
            {
                return _mapper.Map<RouteDto>(route);
            }
            catch
            {
                return null;
            }
        }

        private Route GetRouteEntity(RouteDto route)
        {
            try
            {
                return _mapper.Map<Route>(route);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<RouteDto> GetRoutesQuery()
        {
            var routes = _context.Routes
                .Include(x => x.RouteStations)
                    .ThenInclude(x => x.Route)
                .Include(x => x.RouteStations)
                    .ThenInclude(x => x.StartStation)
                .Include(x => x.RouteStations)
                    .ThenInclude(x => x.EndStation)
                    .Include(x => x.Train);
            try
            {
                return _mapper.Map<RouteDto[]>(routes);
            }
            catch
            {
                return Array.Empty<RouteDto>();
            }
        }
        #endregion
    }
}