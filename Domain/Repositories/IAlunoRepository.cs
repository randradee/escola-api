using EscolaApi.Domain.Entities;

namespace EscolaApi.Domain.Repositories
{
    public interface IAlunoRepository
    {
        Task<Aluno?> GetAlunoById(Guid id);
        Task CreateAluno(Aluno aluno);
    }
}
