using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Interfaces.Facades;
using TrainSeatReservation.Interfaces.Infrastructure.Services;
using Priority_Queue;
using TrainSeatReservation.Commons.Dto;
using System.Diagnostics;
using TrainSeatReservation.Commons.DisplayItems;

namespace TrainSeatReservation.Facades
{
    public class RouteWithChangesFcd : IRouteWithChangesFcd
    {

        private readonly IStationService _stationService;
        private readonly IRouteStationService _routeStationService;
        private readonly ITrainStationService _trainStationService;
        private readonly ITicketService _ticketService;
        private readonly ITrainService _trainService;
        private readonly IRouteService _routeService;
 
        public RouteWithChangesFcd(IStationService stationService, IRouteStationService routeStationService, ITrainStationService trainStationService, IRouteService routeService, ITicketService ticketService, ITrainService trainService )
        {
            _stationService = stationService;
            _routeStationService = routeStationService;
            _trainStationService = trainStationService;
            _routeService = routeService;
            _ticketService = ticketService;
            _trainService = trainService;
        }
        public RouteView GetRoutes(int firstStationId, int lastStationId, TimeSpan time, DateTime date)
        {
            var routeView = new RouteView();
            routeView.Trains = new List<TrainView>();
            var timeSpan = TimeSpan.FromMinutes(1);
            var train = Djikstra(firstStationId, lastStationId, date, time);
            while(train != null)
            {
                routeView.Trains.Add(train);
                var moreTime = train.Route.StartTrainTimeTable.DepartureTime + timeSpan;
                train = Djikstra(firstStationId, lastStationId, date, moreTime.Value);
            }
            return routeView;
        }

        public TrainView Djikstra(int firstStationId, int lastStationId, DateTime date, TimeSpan time)
        {
            var charges = 3;
            var stations = _stationService.GetStations();
            var first = _stationService.GetStation(firstStationId); //station
            var firstStationRoutes = _routeStationService.GetRoutesFromStation(firstStationId);
            var firstStationInfo = _trainStationService.GetTrainsFromStation(firstStationId);

            var V = stations.Count;
            int[,] d = new int[charges + 1, V];
            PreviousStation[,] previousStations = new PreviousStation[charges + 1, V];
            bool[,] visited = new bool[charges + 1, V];
            var edges = _routeStationService.GetRouteStations();
            var priorityQueue = new SimplePriorityQueue<StationWithCharges, int>();

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j <= charges; j++)
                {
                    d[j, i] = int.MaxValue;
                }
            }
            d[0, firstStationId - 1] = 0;
            priorityQueue.Enqueue(new StationWithCharges(first, 0, null), 0);
            var previousRouteId = 0;
            var previousStation = new StationWithCharges();
            while (priorityQueue.Count != 0)
            {
                var current = priorityQueue.Dequeue();
                var previous = previousStation;
                var departureTime = previousStation.TrainTimeTable?.DepartureTime;
                var currentTrainsStationInfo = _trainStationService.GetTrainsFromStation(current.Station.Id);
                visited[current.charge, current.Station.Id - 1] = true;
                if (current.Station.Id == lastStationId)
                {
                    break;
                }
                var currentStationRoutes = edges.Where(x => x.StartStationId == current.Station.Id);
                var currentRoute = currentStationRoutes.FirstOrDefault();
                if (first.Id == current.Station.Id)
                    currentStationRoutes = currentStationRoutes.Where(x => x.StartTrainTimeTable.DepartureTime >= time);

                //zapisywać gdzieś id route z którego przyszło się do noda
                foreach (var item in currentStationRoutes)
                {
                    if (visited[current.charge, item.EndStationId - 1] == false)
                    {
                        var isRouteContainsEndStation = item.Route.RouteStations.Any(x => x.EndStationId == lastStationId);

                        if (d[current.charge, current.Station.Id - 1] != int.MaxValue)
                        {
                            if (isRouteContainsEndStation)
                            {

                                var currentOrder = item.Route.RouteStations.Where(x => x.StartStationId == current.Station.Id).Select(x => x.Order).FirstOrDefault();
                                var lastOrder = item.Route.RouteStations.Where(x => x.EndStationId == lastStationId).Select(x => x.Order).FirstOrDefault();
                                var stationsDjikstra = GetRouteStations(d, previousStations, charges, V, firstStationId, current.Station.Id);
                                //stationsString += "RouteId " + item.RouteId;
                                var last = stationsDjikstra.Where(x => x.Order == -1).SingleOrDefault();
                                last.RouteId = item.RouteId;
                                var stationsList = item.Route.RouteStations.Where(x => x.Order >= currentOrder && x.Order <= lastOrder);
                                foreach (var station in stationsList)
                                {
                                    stationsDjikstra.Add(new DjikstraStation
                                    {
                                        StationId = station.EndStationId,
                                        RouteId = station.RouteId,
                                        Order = stationsDjikstra.Count() - 1
                                    });
                                }
                                return GetTrainInfo(stationsDjikstra, date);
                                //break;
                            }
                            else
                            {


                                if ((previousRouteId != 0 && previousRouteId != item.RouteId) && previous != null/* warunek jeśli route się zmienia*/ && current.charge != charges) // zmienia się trasa i może być przesiadka
                                {
                                    current.TrainTimeTable = item.StartTrainTimeTable;
                                    if (current.TrainTimeTable.ArrivalTime > previous.TrainTimeTable.DepartureTime)
                                    {
                                        var changeTime = current.TrainTimeTable.ArrivalTime - previous.TrainTimeTable.DepartureTime;
                                        if (previousStation.Station.Id != current.Station.Id)
                                        {

                                            if ((d[current.charge, current.Station.Id - 1] + (int)item.Time.TotalMinutes + (int)changeTime?.TotalMinutes < d[current.charge + 1, item.EndStationId - 1]) || isRouteContainsEndStation)
                                            {
                                                currentRoute = item;
                                                previousRouteId = item.RouteId;
                                                d[current.charge + 1, item.EndStationId - 1] = d[current.charge, current.Station.Id - 1] + (int)item.Time.TotalMinutes + (int)changeTime?.TotalMinutes;
                                                previousStations[current.charge + 1, item.EndStationId - 1] = new PreviousStation(current.Station.Id, true, previousRouteId, current.TrainTimeTable);
                                                previous = new StationWithCharges(item.StartStation, current.charge, item.StartTrainTimeTable);
                                                var temp = new StationWithCharges(item.EndStation, current.charge + 1, null);
                                                if (priorityQueue.Contains(temp))
                                                {
                                                    priorityQueue.UpdatePriority(temp, d[current.charge + 1, item.EndStationId - 1]);
                                                }
                                                else
                                                {
                                                    priorityQueue.Enqueue(temp, d[current.charge + 1, item.EndStationId - 1]);
                                                }
                                            }
                                        }
                                    }
                                }
                                else if ((previousRouteId == 0 || previousRouteId == item.RouteId || previous == null) || current.charge == charges)
                                {
                                    current.TrainTimeTable = item.StartTrainTimeTable;

                                    if (d[current.charge, current.Station.Id - 1] + (int)item.Time.TotalMinutes < d[current.charge, item.EndStationId - 1])
                                    {
                                        currentRoute = item;
                                        previousRouteId = item.RouteId;
                                        d[current.charge, item.EndStationId - 1] = d[current.charge, current.Station.Id - 1] + (int)item.Time.TotalMinutes;
                                        previousStations[current.charge, item.EndStationId - 1] = new PreviousStation(current.Station.Id, false, previousRouteId, current.TrainTimeTable);
                                        previous = new StationWithCharges(item.StartStation, current.charge, item.StartTrainTimeTable);
                                        var temp = new StationWithCharges(item.EndStation, current.charge, null);
                                        if (priorityQueue.Contains(temp))
                                        {
                                            priorityQueue.UpdatePriority(temp, d[current.charge, item.EndStationId - 1]);
                                        }
                                        else
                                        {
                                            priorityQueue.Enqueue(temp, d[current.charge, item.EndStationId - 1]);
                                        }
                                    }


                                }
                            }
                        }
                    }
                    if (previousStation.Station == null) previousStation = previous;
                }
                previousStation = previous;
            }
            return null;

        }
        public List<DjikstraStation> GetRouteStations(int[,] d, PreviousStation[,] previousStations, int charges, int stations, int firstStationId, int lastStationId)
        {
            int min = int.MaxValue;
            int minrows = 0;
            for (int i = 0; i <= charges; i++)
            {
                if (d[i, lastStationId - 1] < min)
                {
                    minrows = i;
                }
            }
            var stationList = new List<DjikstraStation>();
            PreviousStation temp = previousStations[minrows, lastStationId - 1];
            var station = new DjikstraStation
            {
                Order = -1,
                RouteId = 0,
                StationId = lastStationId
            };
            stationList.Add(station);
            string result = lastStationId.ToString();
            var j = 0;
            while (temp != null)
            {
                var tmpStation = new DjikstraStation
                {
                    Order = j++,
                    RouteId = temp.routeId,
                    StationId = temp.id
                };
                stationList.Add(tmpStation);
                if (temp.charge == true)
                {
                    minrows--;
                }
                temp = previousStations[minrows, temp.id - 1];
            }
            Debug.WriteLine("Miasta:");
            Debug.Write(result);
            stationList.Reverse();
            return stationList;
        }
        private TrainView GetTrainInfo(List<DjikstraStation> stationList, DateTime date)
        {
            var firstStation = _stationService.GetStation(stationList.First().StationId);
            var firstRouteId = stationList.First().RouteId;
            var firstRouteStation = _routeStationService.GetRoutesFromStation(firstStation.Id).Where(x => x.RouteId == firstRouteId).Single();
            var lastStation = _stationService.GetStation(stationList.Last().StationId);
            var lastRouteId = stationList.Last().RouteId;
            var lastRouteStation = _routeStationService.GetRouteStations().Where(x => x.RouteId ==lastRouteId && x.EndStationId == lastStation.Id).Single();

            var trainView = new TrainView
            {
                StartStation = firstStation,
                EndStation = lastStation,
                
            };

            var routeStation = new RouteStationDto
            {
                StartStation = firstStation,
                EndStation = lastStation,
                Order = 0,
                
            };
            trainView.Train = firstRouteStation.Train;
            trainView.FirstRoute = firstRouteStation.Route;
            if (firstRouteId == lastRouteId)
            {
                trainView.Transits = 0;
                trainView.Route = routeStation;
                var routes = _routeStationService.GetRouteStations().Where(x => x.Order >= firstRouteStation.Order && x.Order <= lastRouteStation.Order && x.RouteId ==firstRouteId);
                foreach (var item in routes)
                {
                    trainView.Route.Distance += item.Distance;
                    trainView.Route.Price += item.Price;
                  
                }
                trainView.Route.Route = firstRouteStation.Route;
                trainView.Route.StartTrainTimeTable = firstRouteStation.StartTrainTimeTable;
                trainView.Route.EndTrainTimeTable = lastRouteStation.EndTrainTimeTable;
                trainView.TravelTime = lastRouteStation.EndTrainTimeTable.ArrivalTime.Value - firstRouteStation.StartTrainTimeTable.DepartureTime.Value;
                trainView.Train = firstRouteStation.Train;
                trainView.FreeSeats = CheckFreeSeats(date, firstRouteStation, lastRouteStation);
            }
            else
            {
                var changes = 0;
                var freeSeats = 0.0;
                var routeTransits = new List<RouteTransitView>();
                trainView.Route = routeStation;
                trainView.Route.StartTrainTimeTable = firstRouteStation.StartTrainTimeTable;
                trainView.Route.EndTrainTimeTable = lastRouteStation.EndTrainTimeTable;
                var firstRoute = _routeService.GetRoute(firstRouteStation.RouteId);
                TrainTimeTableDto endStationTime = new TrainTimeTableDto();
                var tmpFirstRouteStation = new RouteStationDto();
                var tmpLastStation = new RouteStationDto();
                var changePosition = 0;
                for (int i = 0; i < stationList.Count()-1; i++)
                {
                    if (i == stationList.Count() - 2)
                        endStationTime = _routeStationService.GetRouteStations().Where(x => x.EndStationId == stationList[i].StationId && x.RouteId == stationList[i].RouteId).Select(x=> x.EndTrainTimeTable).Single();
                    if(stationList[i].RouteId != stationList[i+1].RouteId)
                    {
                        
                        changes++;
                        var route = _routeService.GetRoute(stationList[i+1].RouteId);
                        var firstRouteStationInfo = _routeStationService.GetRouteStations().Where(x => x.EndStationId == stationList[i + 1].StationId && x.RouteId == stationList[i].RouteId).Single();
                        var secondRouteStationInfo = _routeStationService.GetRouteStations().Where(x => x.StartStationId == stationList[i + 1].StationId && x.RouteId == stationList[i+1].RouteId).Single();
                        var time = secondRouteStationInfo.StartTrainTimeTable.DepartureTime - firstRouteStationInfo.EndTrainTimeTable.ArrivalTime;
                        var stationTransit = _stationService.GetStation(stationList[i + 1].StationId);
                       

                        if (firstRouteStation.RouteId == firstRouteStationInfo.RouteId) //first transition
                        {
                            trainView.FreeSeats = CheckFreeSeats(date, firstRouteStation, firstRouteStationInfo);
                           //mpFirstRouteStation = secondRouteStationInfo
                        }     
                        if(changePosition !=i+1 && changePosition != 0)
                        {
                            var tmpRouteStationInfo = _routeStationService.GetRouteStations().Where(x => x.EndStationId == stationList[changePosition].StationId && x.RouteId == stationList[i].RouteId).Single();
                            freeSeats = CheckFreeSeats(date, tmpRouteStationInfo, firstRouteStationInfo);
                            routeTransits.Last().FreeSeats = freeSeats;
                        }
                        
                        routeTransits.Add(new RouteTransitView
                        {
                            Route = route,
                            TimeForTransit = time.Value,
                            Station = stationTransit,
                            Train = secondRouteStationInfo.Train,
                            //FreeSeats = CheckFreeSeats(date, firstRouteStationInfo, secondRouteStationInfo)
                        });
                        changePosition = i + 1;
                    }
                }
                var tmpRouteInfo = _routeStationService.GetRouteStations().Where(x => x.EndStationId == stationList[changePosition].StationId && x.RouteId == stationList.Last().RouteId).Single();
                freeSeats = CheckFreeSeats(date, tmpRouteInfo, lastRouteStation);
                routeTransits.Last().FreeSeats = freeSeats;

                trainView.RouteTransits = routeTransits;
                trainView.Transits = changes;
                trainView.Route.StartTrainTimeTable = firstRouteStation.StartTrainTimeTable;
                trainView.Route.EndTrainTimeTable = endStationTime;
                trainView.TravelTime = endStationTime.ArrivalTime.Value - firstRouteStation.StartTrainTimeTable.DepartureTime.Value;
            }
            trainView.Price += trainView.Route.Price;
            if(trainView.Transits > 0)
            {
                if (trainView.Transits == 1)
                {
                    double price = 0;
                    var route = _routeService.GetRoute(trainView.RouteTransits[0].Route.Id);
                    var firstRouteStationTransit = _routeStationService.GetRoutesFromStation(trainView.RouteTransits[0].Station.Id).Where(x => x.RouteId == trainView.RouteTransits[0].Route.Id).Single();
                    var routes = _routeStationService.GetRouteStations().Where(x => x.Order >= firstRouteStationTransit.Order && x.Order <= lastRouteStation.Order && x.RouteId == lastRouteId);
                    foreach (var item in routes)
                    {
                        price += item.Price;
                    }

                    // var selectedStations = route.RouteStations.Where(x => x.)
                    /*foreach (var item in route.RouteStations)
                    {
                        if(item.StartStationId == trainView.RouteTransits[0].Station.Id)
                        {

                        }
                    }*/
                    trainView.Price += price;
                }
                else
                {
                    var i = 0;
                    double price = 0;
                    foreach (var item in trainView.RouteTransits)
                    {
                        var route = _routeService.GetRoute(trainView.RouteTransits[i].Route.Id);
                        var firstRouteStationTransit = _routeStationService.GetRoutesFromStation(trainView.RouteTransits[i].Station.Id).Where(x => x.RouteId == trainView.RouteTransits[i].Route.Id).Single();
                        if (route.Id != lastRouteId)
                        {
                            var lastRouteStationTransit = _routeStationService.GetRouteStations().Where(x => x.RouteId == route.Id && x.EndStationId == trainView.RouteTransits[i+1].Station.Id).Single();
                            var routes = _routeStationService.GetRouteStations().Where(x => x.Order >= firstRouteStationTransit.Order && x.Order <= lastRouteStationTransit.Order && x.RouteId == route.Id);
                            foreach (var r in routes)
                            {
                                price += r.Price;
                            }
                        }
                        else
                        {
                            var routes = _routeStationService.GetRouteStations().Where(x => x.Order >= firstRouteStationTransit.Order && x.Order <= lastRouteStation.Order && x.RouteId == lastRouteId);
                            foreach (var r in routes)
                            {
                                price += r.Price;
                            }
                        }
                        // trainView.Price += item.Rou
                    }
                    trainView.Price += price;
                }
               
            }
            return trainView;
        }
        private double CheckFreeSeats(DateTime date, RouteStationDto firstRoute, RouteStationDto lastRoute)
        {
            var train = _trainService.GetTrain(firstRoute.TrainId);
            var tickets = _ticketService.GetTrainTicketsWithDate(date, firstRoute.TrainId);
            var freeSeats = 0;
            var capacity = 0;
            var occupiedSeats = 0;
            foreach (var item in tickets)
            {
                if ((item.DepartureTrainStation.TrainTimeTable.DepartureTime < firstRoute.StartTrainTimeTable.DepartureTime && item.ArrivalTrainStation.TrainTimeTable.ArrivalTime < lastRoute.EndTrainTimeTable.ArrivalTime)
                   || (item.DepartureTrainStation.TrainTimeTable.DepartureTime >= firstRoute.StartTrainTimeTable.DepartureTime && item.ArrivalTrainStation.TrainTimeTable.ArrivalTime <= lastRoute.EndTrainTimeTable.ArrivalTime)
                   || (item.DepartureTrainStation.TrainTimeTable.DepartureTime > firstRoute.StartTrainTimeTable.DepartureTime && item.ArrivalTrainStation.TrainTimeTable.ArrivalTime > lastRoute.EndTrainTimeTable.ArrivalTime))
                {
                    occupiedSeats += item.Seats.Count;
                }
            }
            foreach (var item in train.TrainCarriages)
            {
                capacity += item.Carriage.Capacity;
            }
            freeSeats = capacity - occupiedSeats;

            return (freeSeats / capacity * 100); ;
        }

    }
    public class PreviousStation
    {
        public int id { get; set; }
        public bool charge { get; set; }
        public int routeId { get; set; }
        public TrainTimeTableDto TrainTimeTableDto { get; set; }

        public PreviousStation(int id, bool charge, int routeId, TrainTimeTableDto trainTimeTableDto)
        {
            this.id = id;
            this.charge = charge;
            this.routeId = routeId;
            this.TrainTimeTableDto = trainTimeTableDto;
        }
        public PreviousStation() { }
    }
    public class StationWithCharges
    {
        public StationDto Station { get; set; }
        public int charge { get; set; }
        public TrainTimeTableDto TrainTimeTable { get; set; }
        public StationWithCharges(StationDto Station, int charge, TrainTimeTableDto trainTimeTable)
        {
            this.Station = Station;
            this.charge = charge;
            this.TrainTimeTable = trainTimeTable;
        }
        public StationWithCharges() { }
    }
}
