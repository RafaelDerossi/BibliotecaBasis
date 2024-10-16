using BibliotecaBasis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaBasis.Infra.Data.Mapeamento
{
    public class PrecoMapping : IEntityTypeConfiguration<Preco>
    {
        public void Configure(EntityTypeBuilder<Preco> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Preco");

            builder.Property(u => u.LivroId)
               .IsRequired();

            builder.Property(u => u.Valor)
                .IsRequired()
                .HasColumnType($"decimal(14,2)");

            builder.Property(u => u.FormaDeVenda)
               .IsRequired();
        }
    }
}
