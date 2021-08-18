using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TrainSeatReservation.Commons;
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
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                );
            serviceCollection.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            

            serviceCollection.AddScoped<ITrainFcd, TrainFcd>();
            serviceCollection.AddScoped<ITrainService, TrainService>();

            serviceCollection.AddScoped<ICarriageFcd, CarriageFcd>();
            serviceCollection.AddScoped<ICarriageService, CarriageService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }


    }
}
