using EscolaApi.Domain.Entities;

namespace EscolaApi.Domain.Dtos.Aluno
{
    public class GetAlunoDto
    {
        public Guid? Id { get; set; }
        public bool? IsAtivo { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public string? DataNascimento { get; set; }
        public List<Turma>? Turmas { get; set; }

        public GetAlunoDto() { }

        public GetAlunoDto(Guid? id, bool? isAtivo, string? nome, string? sobrenome, string? email, string? dataNascimento, List<Turma>? turmas)
        {
            Id = id;
            IsAtivo = isAtivo;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Turmas = turmas;
        }
    }
}
