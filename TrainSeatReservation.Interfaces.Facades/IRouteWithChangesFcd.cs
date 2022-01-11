//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.DisplayItems;

namespace TrainSeatReservation.Interfaces.Facades
{
    public interface IRouteWithChangesFcd
    {
        RouteView GetRoutes(int firstStationId, int lastStationId, TimeSpan time, DateTime date);
    }
}
