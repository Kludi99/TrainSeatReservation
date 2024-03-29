﻿//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainSeatReservation.Data;
using TrainSeatReservation.EntityFramework.Models;

[assembly: HostingStartup(typeof(TrainSeatReservation.Areas.Identity.IdentityHostingStartup))]
namespace TrainSeatReservation.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}