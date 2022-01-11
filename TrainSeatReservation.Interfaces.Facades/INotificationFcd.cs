//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Interfaces.Facades
{
    public interface INotificationFcd
    {
        void SendCarriageChangeMesssage(int carriageId, string content);
    }
}
