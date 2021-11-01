using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Configuration
{
    public class PayPalConfig: IPayPalConfiguration
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
