namespace EscolaApi.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Turma>? Turmas { get; } = [];
    }
}