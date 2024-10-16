using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Dominio.ViewModels.Autores
{
    public class AutorViewModel
    {
        public Guid Id { get; set; }

        public string? Nome { get; set; }


        public static AutorViewModel Mapear(Autor autor)
        {
            return new AutorViewModel { Id = autor.Id, Nome = autor.Nome };
        }
    }
}
