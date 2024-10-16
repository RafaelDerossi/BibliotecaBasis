using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Dominio.ViewModels.Assuntos
{
    public class AssuntoViewModel
    {
        public Guid Id { get; set; }

        public string? Descricao { get; set; }

        public static AssuntoViewModel Mapear(Assunto assunto)
        {  
            return new AssuntoViewModel { Id = assunto.Id, Descricao = assunto.Descricao }; 
        }
    }
}
