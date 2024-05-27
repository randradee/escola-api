using EscolaApi.Data.Mappings;
using EscolaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EscolaApi.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new AlunoMapping());
            modelBuilder.ApplyConfiguration(new TurmaMapping());
        }
    }
}
