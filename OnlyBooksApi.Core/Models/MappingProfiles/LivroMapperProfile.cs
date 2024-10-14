using AutoMapper;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Core.Models.MappingProfiles
{
    public class LivroMapperProfile : Profile
    {
        public LivroMapperProfile()
        {
            CreateMap<Livro, LivroDto>();
            CreateMap<Livro, CreateLivroDto>().ReverseMap();
            CreateMap<LivroDto, Livro>()
                .ForMember(dest => dest.GeneroLivroId, opt => opt.Ignore());
            CreateMap<LivroViewModel, Livro>()
                .ForMember(dest => dest.GeneroLivroId, opt => opt.Ignore());
            CreateMap<Livro, LivroViewModel>().ReverseMap();
        }
    }
}
