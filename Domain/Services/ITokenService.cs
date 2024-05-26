using EscolaApi.Domain.Models;

namespace EscolaApi.Domain.Services
{
    public interface ITokenService
    {
        Task<string> GenerateToken(Usuario user);
    }
}
