using Commom.DTOs;
using DataAccess.Models;
using AutoMapper;
using HotelTransilvania.ViewModels;

namespace HotelTransilvania.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>()
                 .ForPath(_ => _.FullNamePersonOnly, option => option.MapFrom(_ => string.Join(" ", _.FirstName, _.LastName)))
                 .ForPath(_ => _.FullName, option => option.MapFrom(_ => string.Join(" ", _.FirstName, _.LastName, _.TradeName)))
                .ReverseMap();
            CreateMap<Reservation, ReservationDTO>()
                  .ForPath(_ => _.MainGuestFullName, option => option.MapFrom(_ => string.Join(" ", _.MainGuest.FirstName, _.MainGuest.LastName)))
                  .ForPath(_ => _.ContactPersonFullName, option => option.MapFrom(_ => string.Join(" ", _.ContactPerson.FirstName, _.ContactPerson.LastName, _.ContactPerson.TradeName)))
                  .ForPath(_ => _.RoomCategory, option => option.MapFrom(_ => _.RoomCategory.Name))
                  .ForPath(_ => _.RoomCode, option => option.MapFrom(_ => _.Room.Code))
                  .ForPath(_ => _.Rate, option => option.MapFrom(_ => _.RoomCategory.Rate))
                  .ForPath(_ => _.MaxOfGuests, option => option.MapFrom(_ => _.Room.MaxOfGuests))
                  .ReverseMap()
                  .ForMember(_ => _.MainGuest, option => option.Ignore())
                  .ForMember(_ => _.ContactPerson, option => option.Ignore())
                  .ForMember(_ => _.Room, option => option.Ignore())
                  .ForMember(_ => _.RoomCategory, option => option.Ignore());
            CreateMap<ReservationClientDTO, ReservationClient>()
                   .ForMember(_ => _.Client, option => option.Ignore())
                   .ForMember(_ => _.Reservation, option => option.Ignore())
                   .ReverseMap()
                   .ForPath(_ => _.FirstName, option => option.MapFrom(_ => _.Client.FirstName))
                   .ForPath(_ => _.LastName, option => option.MapFrom(_ => _.Client.LastName));
            CreateMap<ReservationDTO, ArrivalsOfTheDayViewModel>()
                .ForPath(_ => _.CreationDate, option => option.MapFrom(_ => _.CreationDate.ToString()))
                .ForPath(_ => _.Arrival, option => option.MapFrom(_ => _.Arrival.ToShortDateString()))
                .ForPath(_ => _.Departure, option => option.MapFrom(_ => _.Departure.ToShortDateString()))
                .ForPath(_ => _.Status, option => option.MapFrom(_ => _.Status.ToString()));
        }
    }
}
