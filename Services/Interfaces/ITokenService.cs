using EscolaApi.Models;

namespace EscolaApi.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}
