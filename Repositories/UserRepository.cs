using EscolaApi.Data.Contexts;
using EscolaApi.Data.Repositories;
using EscolaApi.Domain.Models;
using EscolaApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EscolaApi.Repositories
{
    public class UserRepository(AppDbContext context) : BaseRepository(context), IUserRepository
    {
        public async Task<Usuario> GetUsuario(string login)
        {
            Usuario? result = await _context.Usuarios
                 .Where(x => x.Login == login)
                 .FirstOrDefaultAsync();

            return result == null ? throw new Exception("Usuário não encontrado") : result;
        }

        public async Task CreateUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }
    }
}
