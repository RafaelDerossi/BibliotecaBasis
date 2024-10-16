using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Dominio.Models.Assuntos
{
    public class AssuntoResponseModel
    {
        public Guid Id { get; set; }

        public string? Descricao { get; set; }

        public static AssuntoResponseModel Mapear(Assunto assunto)
        {
            return new AssuntoResponseModel { Id = assunto.Id, Descricao = assunto.Descricao };
        }
    }
}
