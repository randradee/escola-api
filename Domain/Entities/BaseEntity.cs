namespace EscolaApi.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public bool Ativo { get; set; } = true;
    }
}
