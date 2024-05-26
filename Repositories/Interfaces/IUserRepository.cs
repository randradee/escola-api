using EscolaApi.Models;

namespace EscolaApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User? GetUser(string username, string password);
    }
}
