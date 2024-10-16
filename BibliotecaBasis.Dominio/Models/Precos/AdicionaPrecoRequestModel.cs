using BibliotecaBasis.Comum.Enumeradores;

namespace BibliotecaBasis.Dominio.Models.Precos
{
    public class AdicionaPrecoRequestModel
    {
        public Guid LivroId { get; set; }

        public decimal Valor { get; set; }

        public FormaDeVenda FormaDeVenda { get; set; }
    }
}
