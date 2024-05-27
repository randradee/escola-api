using EscolaApi.Domain.Entities;

namespace EscolaApi.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<Usuario?> GetUsuario(string login);

        Task CreateUsuario(Usuario usuario);
    }
}
