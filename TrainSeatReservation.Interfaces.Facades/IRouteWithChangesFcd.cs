using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Interfaces.Facades
{
    public interface IRouteWithChangesFcd
    {
        void GetRoutes(int firstStationId, int lastStationId);
    }
}
