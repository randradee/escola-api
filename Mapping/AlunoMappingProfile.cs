using AutoMapper;
using EscolaApi.Domain.Dtos.Aluno;
using EscolaApi.Domain.Entities;
using EscolaApi.Mapping.Convertions;

namespace EscolaApi.Mapping
{
    public class AlunoMappingProfile : Profile
    {
        public AlunoMappingProfile()
        {
            CreateMap<string, DateTime>().ConvertUsing<StringToDateTimeConverter>();
            CreateMap<DateTime, string>().ConvertUsing<DateTimeToStringConverter>();

            CreateMap<Aluno, GetAlunoDto>()
                .ForMember(dest => dest.IsAtivo, opt => opt.MapFrom(src => src.Ativo))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(src => src.Sobrenome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Turmas, opt => opt.Condition(src => src.Turmas != null))
                .ForMember(dest => dest.Turmas, opt => opt.MapFrom(src => src.Turmas));

            CreateMap<CreateAlunoDto, Aluno>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(src => src.Sobrenome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Turmas, opt => opt.Condition(src => src.Turmas != null))
                .ForMember(dest => dest.Turmas, opt => opt.MapFrom(src => src.Turmas));

            CreateMap<UpdateAlunoDto, Aluno>()
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.IsAtivo))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(src => src.Sobrenome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Turmas, opt => opt.Condition(src => src.Turmas != null))
                .ForMember(dest => dest.Turmas, opt => opt.MapFrom(src => src.Turmas));
        }
    }
}
