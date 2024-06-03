using AutoMapper;
using EscolaApi.Data.Repositories;
using EscolaApi.Domain.Dtos.Aluno;
using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Repositories;
using EscolaApi.Domain.Services;
using EscolaApi.Domain.Services.Communication;

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

            Aluno? storedAluno = await _alunoRepository.GetAlunoByName(createAlunoDto.Nome);

            //if (storedAluno != null
            //    && string.Equals(createAlunoDto.Nome, storedAluno.Nome, StringComparison.CurrentCultureIgnoreCase)
            //    && string.Equals(createAlunoDto.Sobrenome, storedAluno.Sobrenome, StringComparison.CurrentCultureIgnoreCase)
            //    && string.Equals(createAlunoDto.Email, storedAluno.Email, StringComparison.CurrentCultureIgnoreCase)
            //    )
            //{
            //    return new Response<CreateAlunoDto>("Já existe no sistema um aluno com as características informadas");
            //}

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

        public async Task<Response<GetAlunoDto>> GetAluno(string nome)
        {
            Aluno? aluno = await _alunoRepository.GetAlunoByName(nome);

            if(aluno == null)
            {
                return new Response<GetAlunoDto>("Aluno não encontrado");
            }

            var alunoDto = _mapper.Map<Aluno, GetAlunoDto>(aluno);

            return new Response<GetAlunoDto>(alunoDto);
        }
    }
}
