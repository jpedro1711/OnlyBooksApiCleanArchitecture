using AutoMapper;
using OnlyBooksApi.Core.Models.Dtos;

namespace OnlyBooksApi.Core.Models.MappingProfiles
{
    public class UsuarioMapperProfile : Profile
    {
        public UsuarioMapperProfile()
        {
            CreateMap<Usuario, CreateOrUpdateUsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioResponseDto>().ReverseMap();
            CreateMap<UsuarioResponseDto, CreateOrUpdateUsuarioDto>().ReverseMap();
            CreateMap<UsuarioResponseDto, CreateOrUpdateUsuarioDto>().ReverseMap();
        }
    }
}
