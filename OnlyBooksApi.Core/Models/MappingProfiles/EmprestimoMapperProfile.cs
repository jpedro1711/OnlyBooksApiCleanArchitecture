using AutoMapper;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Dtos;

namespace OnlyBooksApi.Core.Models.MappingProfiles
{
    public class EmprestimoMapperProfile : Profile
    {
        public EmprestimoMapperProfile()
        {
            CreateMap<Emprestimo, EmprestimoDto>().ReverseMap();
            CreateMap<Emprestimo, CreateEmprestimoDto>().ReverseMap();
            CreateMap<CreateEmprestimoDto, EmprestimoDto>().ReverseMap();
        }
    }
}
