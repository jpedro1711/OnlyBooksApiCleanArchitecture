using AutoMapper;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Core.Models.MappingProfiles
{
    public class EmprestimoMapperProfile : Profile
    {
        public EmprestimoMapperProfile()
        {
            CreateMap<Emprestimo, EmprestimoDto>().ReverseMap();
            CreateMap<Emprestimo, CreateEmprestimoDto>().ReverseMap();
            CreateMap<CreateEmprestimoDto, EmprestimoDto>().ReverseMap();

            CreateMap<EmprestimoViewModel, EmprestimoDto>().ReverseMap();
            CreateMap<CreateEmprestimoDto, EmprestimoViewModel>().ReverseMap();
            CreateMap<Emprestimo, EmprestimoViewModel>().ReverseMap();
        }
    }
}
