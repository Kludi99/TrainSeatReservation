using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons;
using TrainSeatReservation.Commons.Dto;
using TrainSeatReservation.EntityFramework.Models;

namespace TrainSeatReservation.EntityFramework.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Carriage, CarriageDto>();
            CreateMap<CarriageDto, Carriage>();

            CreateMap<Discount, DiscountDto>();
            CreateMap<DiscountDto, Discount>();

            CreateMap<Route, RouteDto>();
            CreateMap<RouteDto, Route>();

            CreateMap<Station, StationDto>();
            CreateMap<StationDto, Station>();

            CreateMap<TicketDiscount, TicketDiscountDto>();
            CreateMap<TicketDiscountDto, TicketDiscount>();

            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketDto, Ticket>();

            CreateMap<TrainCarriage, TrainCarriageDto>();
            CreateMap<TrainCarriageDto, TrainCarriage>();

            CreateMap<Train, TrainDto>();
            CreateMap<TrainDto, Train>();

            CreateMap<TrainStation, TrainStationDto>();
            CreateMap<TrainStationDto, TrainStation>();

        }
    }
}
