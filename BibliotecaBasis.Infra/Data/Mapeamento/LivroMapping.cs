using BibliotecaBasis.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaBasis.Infra.Data.Mapeamento
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Livro");

            builder.Property(u => u.Titulo)
                .IsRequired()
                .HasColumnType($"varchar({Livro.TituloSize})");

            builder.Property(u => u.Editora)                
                .HasColumnType($"varchar({Livro.EditoraSize})");

            builder.Property(u => u.AnoPublicacao)
                .HasColumnType($"varchar({Livro.AnoPublicacaoSize})");
        }
    }
}
