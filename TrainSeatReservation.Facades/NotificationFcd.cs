using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Interfaces.Facades;
using TrainSeatReservation.Interfaces.Infrastructure.Services;

namespace TrainSeatReservation.Facades
{
    public class NotificationFcd : INotificationFcd
    {
        private readonly INotificationService _service;

        public NotificationFcd(INotificationService service)
        {
            _service = service;
        }
        public void SendCarriageChangeMesssage(int carriageId, string content)
        {
            _service.SendCarriageChangeMesssage(carriageId, content);
        }
    }
}
