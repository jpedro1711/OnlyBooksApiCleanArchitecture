using AutoMapper;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Dtos;

namespace OnlyBooksApi.Core.Models.MappingProfiles
{
    public class ReservaMapperProfile : Profile
    {
        public ReservaMapperProfile()
        {
            CreateMap<Reserva, ReservaDto>()
                .ForMember(dest => dest.Livros, opt => opt.MapFrom(src => src.Livros))
                .ReverseMap();
            CreateMap<ReservaDto, CreateReservaDto>().ReverseMap();
            CreateMap<CreateReservaDto, ReservaDto>().ReverseMap();
            CreateMap<CreateReservaDto, Reserva>().ReverseMap();
            CreateMap<Reserva, UpdateReservaDto>().ReverseMap();
            CreateMap<UpdateReservaDto, ReservaDto>().ReverseMap();
        }
    }
}
