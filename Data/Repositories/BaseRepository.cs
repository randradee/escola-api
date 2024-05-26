using EscolaApi.Data.Contexts;

namespace EscolaApi.Data.Repositories
{
    public abstract class BaseRepository(AppDbContext context)
    {
        protected readonly AppDbContext _context = context;
    }
}
