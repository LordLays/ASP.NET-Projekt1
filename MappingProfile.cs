namespace WebApplication1;

using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, ReservationSummaryViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

        CreateMap<Hotel, HotelOffertViewModel>()
            .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.StarRating, opt => opt.MapFrom(src => src.StarRating));

        CreateMap<HotelRoom, HotelRoomViewModel>()
            .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel.Name))
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number.ToString()))
            .ForMember(dest => dest.TypeRoom, opt => opt.MapFrom(src => src.Type));

        CreateMap<Reservation, ReservationSummaryViewModel>()
            .ForMember(dest => dest.ReservationID, opt => opt.MapFrom(src => src.IDReservation))
            .ForMember(dest => dest.OfertID, opt => opt.MapFrom(src => src.OfertID))
            .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Ofert.Hotel.Name))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Ofert.Hotel.City))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Ofert.Hotel.Country))
            .ForMember(dest => dest.HotelAddress, opt => opt.MapFrom(src => src.Ofert.Hotel.Address))
            .ForMember(dest => dest.Meal, opt => opt.MapFrom(src => src.Ofert.Meal))
            .ForMember(dest => dest.TakeOffPlace, opt => opt.MapFrom(src => src.Ofert.TakeOffPlace))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Ofert.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.Ofert.EndDate))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Ofert.TotalPrice))
            .ForMember(dest => dest.BookedRooms, opt => opt.MapFrom(src => src.BookedRooms));

        CreateMap<Review, ReviewViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Customer.Name))
            .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel.Name))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
            .ForMember(dest => dest.ReviewText, opt => opt.MapFrom(src => src.Reviews));
    }
}
