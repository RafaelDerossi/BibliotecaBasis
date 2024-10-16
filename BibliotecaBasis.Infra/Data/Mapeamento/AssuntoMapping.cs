using BibliotecaBasis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaBasis.Infra.Data.Mapeamento
{
    public class AssuntoMapping : IEntityTypeConfiguration<Assunto>
    {
        public void Configure(EntityTypeBuilder<Assunto> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Assunto");

            builder.Property(u => u.Descricao)
                .IsRequired()
                .HasColumnType($"varchar({Assunto.DescricaoSize})");

        }
    }
}
