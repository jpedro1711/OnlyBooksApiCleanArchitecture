using AutoMapper;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Core.Models.MappingProfiles
{
    public class UsuarioMapperProfile : Profile
    {
        public UsuarioMapperProfile()
        {
            CreateMap<Usuario, CreateOrUpdateUsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<UsuarioViewModel, CreateOrUpdateUsuarioDto>().ReverseMap();
            CreateMap<UsuarioViewModel, CreateOrUpdateUsuarioDto>().ReverseMap();
        }
    }
}
