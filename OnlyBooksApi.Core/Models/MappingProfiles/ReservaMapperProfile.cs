using AutoMapper;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Core.Models.MappingProfiles
{
    public class ReservaMapperProfile : Profile
    {
        public ReservaMapperProfile()
        {
            CreateMap<Reserva, ReservaViewModel>()
                .ForMember(dest => dest.Livros, opt => opt.MapFrom(src => src.ReservaLivros.Select(rl => rl.Livro)))
                .ReverseMap();
            CreateMap<ReservaViewModel, CreateReservaDto>().ReverseMap();
            CreateMap<CreateReservaDto, ReservaViewModel>().ReverseMap();
            CreateMap<CreateReservaDto, Reserva>().ReverseMap();
            CreateMap<Reserva, UpdateReservaDto>().ReverseMap();
            CreateMap<UpdateReservaDto, ReservaViewModel>().ReverseMap();
        }
    }
}
