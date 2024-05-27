using EscolaApi.Domain.Entities;

namespace EscolaApi.Domain.Services
{
    public interface ITokenService
    {
        Task<string> GenerateToken(Usuario user);
    }
}
