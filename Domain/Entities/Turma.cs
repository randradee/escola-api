namespace EscolaApi.Domain.Entities
{
    public class Turma : BaseEntity
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public List<Aluno>? Alunos { get; } = [];
    }
}
