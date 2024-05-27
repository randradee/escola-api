using EscolaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaApi.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ativo).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.DataCriacao).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Sobrenome).IsRequired().HasMaxLength(20);
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.HasMany(x => x.Turmas).WithMany(x => x.Alunos).UsingEntity<TurmaAluno>();
        }
    }
}
