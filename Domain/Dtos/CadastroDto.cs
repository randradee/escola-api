using EscolaApi.Domain.Enums;

namespace EscolaApi.Domain.Dtos
{
    public record CadastroDto(string Login, string Senha, string Cargo);
}
