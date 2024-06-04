using AutoMapper;
using EscolaApi.Data.Repositories;
using EscolaApi.Domain.Dtos.Aluno;
using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Repositories;
using EscolaApi.Domain.Services;
using EscolaApi.Domain.Services.Communication;
using Microsoft.IdentityModel.Tokens;

namespace EscolaApi.Services
{
    public class AlunoService(IUnitOfWork unitOfWork, IAlunoRepository alunoRepository, IMapper mapper) : IAlunoService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IAlunoRepository _alunoRepository = alunoRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<CreateAlunoDto>> CreateAluno(CreateAlunoDto createAlunoDto)
        {
            Aluno aluno = _mapper.Map<CreateAlunoDto, Aluno>(createAlunoDto);
            aluno.DataCriacao = DateTime.UtcNow;

            Aluno? storedAluno = await _alunoRepository.GetAlunoByUniqueness(createAlunoDto.Nome, createAlunoDto.Sobrenome, createAlunoDto.Email);

            if (storedAluno != null)
            {
                return new Response<CreateAlunoDto>("Já existe no sistema um aluno com as características informadas");
            }

            try
            {
                await _alunoRepository.CreateAluno(aluno);
                await _unitOfWork.CompleteAsync();

                return new Response<CreateAlunoDto>(createAlunoDto);
            }
            catch (Exception ex)
            {
                return new Response<CreateAlunoDto>($"erro: {ex.Message}");
            }

        }

        public async Task<Response<GetAlunoDto>> GetAlunoById(Guid id)
        {
            Aluno? aluno = await _alunoRepository.GetAlunoById(id);

            if(aluno == null)
            {
                return new Response<GetAlunoDto>("Aluno não encontrado");
            }

            var alunoDto = _mapper.Map<Aluno, GetAlunoDto>(aluno);

            return new Response<GetAlunoDto>(alunoDto);
        }
    }
}
