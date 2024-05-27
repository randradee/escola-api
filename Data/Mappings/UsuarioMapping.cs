using EscolaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaApi.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ativo).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.DataCriacao).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Login).IsRequired().HasMaxLength(20);
            builder.Property(x => x.SenhaHash).IsRequired();
            builder.Property(x => x.SenhaSalt).IsRequired();
            builder.Property(x => x.Cargo).IsRequired().HasConversion<string>();
        }
    }
}
