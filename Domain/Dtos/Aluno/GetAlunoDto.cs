using EscolaApi.Domain.Entities;

namespace EscolaApi.Domain.Dtos.Aluno
{
    public record GetAlunoDto
        (
            bool? IsAtivo,
            string? Nome,
            string? Sobrenome,
            string? Email,
            string? DataNascimento,
            List<Turma>? Turmas
        );
}
