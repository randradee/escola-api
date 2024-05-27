using EscolaApi.Domain.Enums;

namespace EscolaApi.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string? Login { get; set; }
        public string? SenhaHash { get; set; }
        public string? SenhaSalt {  get; set; }
        public ECargo Cargo { get; set; }
    }
}
