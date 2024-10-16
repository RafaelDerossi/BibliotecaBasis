using BibliotecaBasis.Dominio.Models.Livros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaBasis.Infra.Data.Mapeamento
{
    public class LivroCompletoViewModelMapping : IEntityTypeConfiguration<LivroViewModel>
    {
        public void Configure(EntityTypeBuilder<LivroViewModel> builder)
        {
            builder.HasNoKey();

            builder.ToView("ViewLivro");
        }
    }
}
