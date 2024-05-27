using EscolaApi.Domain.Enums;

namespace EscolaApi.Domain.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string? Login { get; set; }
        public string? SenhaHash { get; set; }
        public string? SenhaSalt {  get; set; }
        public ECargo Cargo { get; set; }
    }
}
