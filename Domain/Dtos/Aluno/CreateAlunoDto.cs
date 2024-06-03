using EscolaApi.Domain.Entities;

namespace EscolaApi.Domain.Dtos.Aluno
{
    public record CreateAlunoDto
    (
        string Nome,
        string Sobrenome,
        string Email,
        string DataNascimento,
        List<Turma>? Turmas
    );
}
