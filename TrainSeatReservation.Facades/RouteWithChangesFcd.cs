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

namespace TrainSeatReservation.Facades
{
    public class RouteWithChangesFcd : IRouteWithChangesFcd
    {

        private readonly IStationService _stationService;
        private readonly IRouteStationService _routeStationService;
        private readonly ITrainStationService _trainStationService;
 
        public RouteWithChangesFcd(IStationService stationService, IRouteStationService routeStationService, ITrainStationService trainStationService)
        {
            _stationService = stationService;
            _routeStationService = routeStationService;
            _trainStationService = trainStationService;
        }
        public void GetRoutes(int firstStationId, int lastStationId)
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
            d[0, firstStationId-1] = 0;
            Debug.WriteLine("Dijkstraaa");
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
               // var currentStationInfo = _trainStationService.GetTrainInformationFromStationAndRoute(current.Station.Id, currentRoute.RouteId);
                //zapisywać gdzieś id route z którego przyszło się do noda
                foreach (var item in currentStationRoutes)
                {
                             if (visited[current.charge, item.EndStationId-1] == false)
                    {
                        var isRouteContainsEndStation = item.Route.RouteStations.Any(x => x.EndStationId == lastStationId);
                       
                        if (d[current.charge, current.Station.Id-1] != int.MaxValue)
                        {
                            if (isRouteContainsEndStation)
                            {
                                /*  var currentStationInfo = _trainStationService.GetTrainInformationFromStationAndRoute(current.Station.Id, item.RouteId);
                                  var time = currentStationInfo.TrainTimeTable;
                                  current.TrainTimeTable = time;

                                  if (d[current.charge, current.Station.Id - 1] + item.Distance < d[current.charge, item.EndStationId - 1])
                                  {
                                      currentRoute = item;
                                      previousRouteId = item.RouteId;
                                      d[current.charge, item.EndStationId - 1] = d[current.charge, current.Station.Id - 1] + item.Distance;
                                      previousStations[current.charge, item.EndStationId - 1] = new PreviousStation(current.Station.Id, false, previousRouteId);
                                      previous = new StationWithCharges(item.StartStation, current.charge, time);
                                      var temp = new StationWithCharges(item.EndStation, current.charge, null);
                                      if (priorityQueue.Contains(temp))
                                      {
                                          priorityQueue.UpdatePriority(temp, -d[current.charge, item.EndStationId - 1]);
                                      }
                                      else
                                      {
                                          priorityQueue.Enqueue(temp, -d[current.charge, item.EndStationId - 1]);
                                      }
                                  }*/
                                if ((previousRouteId != 0 && previousRouteId != item.RouteId) && previous != null/* warunek jeśli route się zmienia*/ && current.charge != charges) // zmienia się trasa i może być przesiadka
                                {
                                   // var currentStationInfo = _trainStationService.GetTrainInformationFromStationAndRoute(current.Station.Id, item.RouteId);
                                   // var time = currentStationInfo.TrainTimeTable;
                                    current.TrainTimeTable = item.StartTrainTimeTable;
                                    if (previousStations[current.charge, current.Station.Id - 1] != null)
                                    {


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
                                }
                                else if ((previousRouteId == 0 || previousRouteId == item.RouteId || previous == null) || current.charge == charges)
                                {
                                    //var currentStationInfo = _trainStationService.GetTrainInformationFromStationAndRoute(current.Station.Id, item.RouteId);
                                    //var time = currentStationInfo.TrainTimeTable;
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
                            else
                            {

                        
                            if ((previousRouteId != 0 && previousRouteId != item.RouteId) && previous != null/* warunek jeśli route się zmienia*/ && current.charge != charges) // zmienia się trasa i może być przesiadka
                            {
                               // var currentStationInfo = _trainStationService.GetTrainInformationFromStationAndRoute(current.Station.Id, item.RouteId);
                               // var time = currentStationInfo.TrainTimeTable;
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
                            else if((previousRouteId == 0 || previousRouteId == item.RouteId || previous == null) || current.charge == charges)
                            {
                               // var currentStationInfo = _trainStationService.GetTrainInformationFromStationAndRoute(current.Station.Id, item.RouteId);
                                //var time = currentStationInfo.TrainTimeTable;
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
                    if(previousStation.Station == null) previousStation = previous;
                }
                previousStation = previous;
            }

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j <= charges; j++)
                {
                    if(previousStations[j, i] != null)
                    Debug.Write("Stacja " + previousStations[j, i].id + " ");
                }
                Debug.WriteLine(' ');
            }
            GetRouteStations(d, previousStations, charges, V, firstStationId, lastStationId);
        }
        public void GetRouteStations(int[,] d, PreviousStation[,] previousStations, int charges, int stations, int firstStationId, int lastStationId)
        {
            int min = int.MaxValue;
            int minrows = 0;
            for (int i = 0; i <= charges; i++)
            {
                if (d[i, lastStationId - 1] < min)
                {
                    //min = d[i, stations - 1];
                    minrows = i;
                }
            }
            //if (min == int.MaxValue)
            //{
            //    Console.WriteLine(min);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    return;
            //}
            PreviousStation temp = previousStations[minrows, lastStationId - 1];
            string result = lastStationId.ToString();
            while (temp != null)
            {
                result = (temp.id).ToString() + " " + result;
                if (temp.charge == true)
                {
                    minrows--;
                }
                temp = previousStations[minrows, temp.id-1];
            }
            //Console.WriteLine();
            //Console.WriteLine("Czas optymalnej trasy: ");
            //Console.Write(min);
            //Console.WriteLine();
            Debug.WriteLine("Miasta:");
            Debug.Write(result);

            for (int i = 0; i < charges; i++)
            {
                for (int j = 0; j < stations; j++)
                {

                }
            }
        }

    }
    public class PreviousStation
    {
        public int id { get; set; }
        public bool charge { get; set; }
        public int routeId { get; set; }
        public TrainTimeTableDto TrainTimeTableDto { get; set; }
        /*public void SetId(int id)
        {
            this.id = id;
        }
        public void SetCharge(bool charge)
        {
            this.charge = charge;
        }
        public int GetId()
        {
            return id;
        }
        public bool GetCharge()
        {
            return charge;
        }*/
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
