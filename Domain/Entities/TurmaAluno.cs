namespace EscolaApi.Domain.Entities
{
    public class TurmaAluno : BaseEntity
    {
        public Guid TurmaId { get; set; }
        public Guid AlunoId { get; set; }
    }
}
