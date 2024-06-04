using EscolaApi.Domain.Dtos.Aluno;
using EscolaApi.Domain.Services.Communication;

namespace EscolaApi.Domain.Services
{
    public interface IAlunoService
    {
        Task<Response<CreateAlunoDto>> CreateAluno(CreateAlunoDto createAlunoDto);
        Task<Response<GetAlunoDto>> GetAlunoById(Guid id);
    }
}
