using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Interfaces.Infrastructure.Services
{
    public interface INotificationService
    {
        void SendCarriageChangeMesssage(int carriageId, string content);
    }
}
