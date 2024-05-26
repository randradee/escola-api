using EscolaApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EscolaApi.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Login).IsRequired();
            builder.Property(x => x.Senha).IsRequired();
            builder.Property(x => x.Cargo).IsRequired().HasConversion<string>();
        }
    }
}
