using BibliotecaBasis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaBasis.Infra.Data.Mapeamento
{
    public class AutorMapping : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Autor");

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType($"varchar({Autor.NomeSize})");           
        }
    }
}
