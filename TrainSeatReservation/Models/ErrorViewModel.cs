//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;

namespace TrainSeatReservation.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
