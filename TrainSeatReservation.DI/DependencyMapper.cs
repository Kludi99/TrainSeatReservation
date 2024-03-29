﻿//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TrainSeatReservation.Commons;
using TrainSeatReservation.Commons.Configuration;
using TrainSeatReservation.Commons.EmailService;
using TrainSeatReservation.Commons.Templates;
using TrainSeatReservation.Data;
using TrainSeatReservation.EntityFramework.AutoMapper;
using TrainSeatReservation.EntityFramework.Models;
using TrainSeatReservation.EntityFramework.Services;
using TrainSeatReservation.Facades;
using TrainSeatReservation.Interfaces.Facades;
using TrainSeatReservation.Interfaces.Infrastructure.Services;

namespace TrainSeatReservation.DI
{
    public static class DependencyMapper
    {
        public static void AddDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                    options.EnableSensitiveDataLogging();
                }
                    
                );
            serviceCollection.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            serviceCollection.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            serviceCollection.AddScoped<ITrainFcd, TrainFcd>();
            serviceCollection.AddScoped<ITrainService, TrainService>();

            serviceCollection.AddScoped<ICarriageFcd, CarriageFcd>();
            serviceCollection.AddScoped<ICarriageService, CarriageService>();

            serviceCollection.AddScoped<IRouteFcd, RouteFcd>();
            serviceCollection.AddScoped<IRouteService, RouteService>();

            serviceCollection.AddScoped<IStationFcd, StationFcd>();
            serviceCollection.AddScoped<IStationService, StationService>();

            serviceCollection.AddScoped<ITrainStationFcd, TrainStationFcd>();
            serviceCollection.AddScoped<ITrainStationService, TrainStationService>();

            serviceCollection.AddScoped<IRouteStationFcd, RouteStationFcd>();
            serviceCollection.AddScoped<IRouteStationService, RouteStationService>();

            serviceCollection.AddScoped<ITicketFcd, TicketFcd>();
            serviceCollection.AddScoped<ITicketService, TicketService>();

            serviceCollection.AddScoped<IDictionaryFcd, DictionaryFcd>();
            serviceCollection.AddScoped<IDictionaryService, DictionaryService>();

            serviceCollection.AddScoped<IDiscountFcd, DiscountFcd>();
            serviceCollection.AddScoped<IDiscountService, DiscountService>();

            serviceCollection.AddScoped<ITicketDiscountFcd, TicketDiscountFcd>();
            serviceCollection.AddScoped<ITicketDiscountService, TicketDiscountService>();

            serviceCollection.AddScoped<ITrainCarriageFcd, TrainCarriageFcd>();
            serviceCollection.AddScoped<ITrainCarriageService, TrainCarriageService>();

            serviceCollection.AddScoped<ISeatFcd, SeatFcd>();
            serviceCollection.AddScoped<ISeatService, SeatService>();

            serviceCollection.AddScoped<ISeatTicketFcd, SeatTicketFcd>();
            serviceCollection.AddScoped<ISeatTicketService, SeatTicketService>();

            serviceCollection.AddScoped<IRouteTicketFcd, RouteTicketFcd>();
            serviceCollection.AddScoped<IRouteTicketService, RouteTicketService>();

            serviceCollection.AddScoped<ITrainTimeTableFcd, TrainTimeTableFcd>();
            serviceCollection.AddScoped<ITrainTimeTableService, TrainTimeTableService>();

            serviceCollection.AddScoped<ITicketChangeFcd, TicketChangeFcd>();
            serviceCollection.AddScoped<ITicketChangeService, TicketChangeService>();

            serviceCollection.AddScoped<IRouteWithChangesFcd, RouteWithChangesFcd>();

            serviceCollection.AddSingleton<IEmailConfiguration>(configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            serviceCollection.AddTransient<IEmailService, EmailService>();
            serviceCollection.AddSingleton<TemplateManager>();

            serviceCollection.AddScoped<INotificationFcd, NotificationFcd>();
            serviceCollection.AddScoped<INotificationService, NotificationService>();

            serviceCollection.AddSingleton<IPayPalConfiguration>(configuration.GetSection("PayPal").Get<PayPalConfig>());
           // serviceCollection.AddSingleton<PayPalConfiguration>(configuration.GetSection("PayPal")/*.Get<PayPalConfiguration>()*/);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }


    }
}
