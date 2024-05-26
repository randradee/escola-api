using EscolaApi.Data.Contexts;
using EscolaApi.Data.Repositories;

namespace EscolaApi.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
