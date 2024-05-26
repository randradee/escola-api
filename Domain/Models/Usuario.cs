using EscolaApi.Domain.Enums;

namespace EscolaApi.Domain.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public ECargo Cargo { get; set; }
    }
}
