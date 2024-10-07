using AutoMapper;
using OnlyBooksApi.Core.Models.Dtos;

namespace OnlyBooksApi.Core.Models.MappingProfiles
{
    public class GeneroLivroMapperProfile : Profile
    {
        public GeneroLivroMapperProfile()
        {
            CreateMap<GeneroLivro, GeneroLivroDto>();
            CreateMap<GeneroLivroDto, GeneroLivro>();
            CreateMap<GeneroLivroResponseDto, GeneroLivro>().ReverseMap();
            CreateMap<GeneroLivroDto, GeneroLivro>().ReverseMap();
        }
    }
}
