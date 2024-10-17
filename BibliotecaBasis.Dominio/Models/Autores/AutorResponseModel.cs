using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Dominio.Models.Autores
{
    public class AutorResponseModel
    {
        public Guid? Id { get; set; }

        public string? Nome { get; set; }


        public static AutorResponseModel Mapear(Autor autor)
        {
            return new AutorResponseModel { Id = autor.Id, Nome = autor.Nome };
        }
    }
}
