using EscolaApi.Domain.Entities;

namespace EscolaApi.Domain.Repositories
{
    public interface IAlunoRepository
    {
        Task<Aluno?> GetAlunoByName(string nome);
        Task CreateAluno(Aluno aluno);
    }
}
