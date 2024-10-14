using AutoMapper;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Core.Models.MappingProfiles
{
    public class GeneroLivroMapperProfile : Profile
    {
        public GeneroLivroMapperProfile()
        {
            CreateMap<GeneroLivro, GeneroLivroDto>();
            CreateMap<GeneroLivroDto, GeneroLivro>();
            CreateMap<GeneroLivroViewModel, GeneroLivro>().ReverseMap();
            CreateMap<GeneroLivroDto, GeneroLivro>().ReverseMap();
        }
    }
}
