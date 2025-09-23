using AutoMapper;
using TooliRent.Core.Models;
using TooliRent.Services.DTOs.BookingDtos;
using TooliRent.Services.DTOs.CategoryDtos;
using TooliRent.Services.DTOs.ToolDtos;

namespace TooliRent.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Tool Mappings
            CreateMap<Tool, ToolDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Tool, ToolInfoDto>();

            CreateMap<CreateToolDto, Tool>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Bookings, opt => opt.Ignore());

            CreateMap<UpdateToolDto, Tool>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Bookings, opt => opt.Ignore());

            // Booking Mappings
            CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName));

            CreateMap<CreateBookingDto, Booking>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Tools, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<UpdateBookingDto, Booking>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Tools, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            // Category Mappings
            CreateMap<Category, CategoryDto>();

            CreateMap<CreateCategoryDto, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Tools, opt => opt.Ignore());

            CreateMap<UpdateCategoryDto, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Tools, opt => opt.Ignore());
        }
    }
}
