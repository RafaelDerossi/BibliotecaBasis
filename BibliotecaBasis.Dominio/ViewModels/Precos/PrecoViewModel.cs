using BibliotecaBasis.Comum.Enumeradores;
using BibliotecaBasis.Dominio.ViewModels.Assuntos;

namespace BibliotecaBasis.Dominio.Entidades
{
    public class PrecoViewModel
    {
        public Guid Id { get; set; }

        public decimal Valor { get; set; }

        public FormaDeVenda FormaDeVenda { get; set; }

        public string? DescricaoFormaDeVenda { get; set; }

        public static PrecoViewModel Mapear(Preco preco)
        {
            return new PrecoViewModel 
            {
                Id = preco.Id,
                Valor = preco.Valor,
                FormaDeVenda = preco.FormaDeVenda,
                DescricaoFormaDeVenda = DescricaoEnumeradorFormaDeVenda.ObterDescricao(preco.FormaDeVenda)
            };
        }
    }
}
