﻿//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Configuration
{
    public interface IPayPalConfiguration
    {
       string ClientId { get; set; }
       string ClientSecret { get; set; }
     
    }
}
