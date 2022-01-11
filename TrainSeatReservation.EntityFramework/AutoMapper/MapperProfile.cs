//Program powstał na Wydziale Informatyki Politechniki Białostockiej
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
            CreateMap<Dictionary, DictionaryDto>();
            CreateMap<DictionaryDto, Dictionary>();

            CreateMap<DictionaryItem, DictionaryItemDto>();
            CreateMap<DictionaryItemDto, DictionaryItem>();

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

            CreateMap<TrainTimeTable, TrainTimeTableDto>();
            CreateMap<TrainTimeTableDto, TrainTimeTable>();

            CreateMap<Seat, SeatDto>();
            CreateMap<SeatDto, Seat>();

            CreateMap<SeatTicket, SeatTicketDto>();
            CreateMap<SeatTicketDto, SeatTicket>();

            CreateMap<RouteStation, RouteStationDto>();
            CreateMap<RouteStationDto, RouteStation>();

            CreateMap<RouteTicket, RouteTicketDto>();
            CreateMap<RouteTicketDto, RouteTicket>();

            CreateMap<TicketChange, TicketChangeDto>();
            CreateMap<TicketChangeDto, TicketChange>();

            CreateMap<TicketResigned, TicketResignedDto>();
            CreateMap<TicketResignedDto, TicketResigned>();
            CreateMap<Ticket, TicketResigned>();

        }
    }
}
