using BibliotecaBasis.Comum.Enumeradores;

namespace BibliotecaBasis.Dominio.Entidades
{
    public class AdicionaPrecoViewModel
    {
        public Guid LivroId { get; set; }

        public decimal Valor { get; set; }

        public FormaDeVenda FormaDeVenda { get; set; }
    }
}
