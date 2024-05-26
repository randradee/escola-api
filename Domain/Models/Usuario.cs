using EscolaApi.Domain.Enums;

namespace EscolaApi.Domain.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public ECargo Cargo { get; set; }

        public Usuario() { }

        public Usuario(Guid id, string? login, string? senha, ECargo cargo)
        {
            Id = id;
            Login = login;
            Senha = senha;
            Cargo = cargo;
        }
    }
}
