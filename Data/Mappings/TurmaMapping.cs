using EscolaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaApi.Data.Mappings
{
    public class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ativo).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.DataCriacao).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);
            builder.HasMany(x => x.Alunos).WithMany(x => x.Turmas).UsingEntity<TurmaAluno>();
        }
    }
}
