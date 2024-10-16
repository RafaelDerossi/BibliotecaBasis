using BibliotecaBasis.Comum.Enumeradores;
using BibliotecaBasis.Dominio.Entidades;

namespace BibliotecaBasis.Dominio.Models.Precos
{
    public class PrecoResponseModel
    {
        public Guid Id { get; set; }

        public decimal Valor { get; set; }

        public FormaDeVenda FormaDeVenda { get; set; }

        public string? DescricaoFormaDeVenda { get; set; }

        public static PrecoResponseModel Mapear(Preco preco)
        {
            return new PrecoResponseModel
            {
                Id = preco.Id,
                Valor = preco.Valor,
                FormaDeVenda = preco.FormaDeVenda,
                DescricaoFormaDeVenda = DescricaoEnumeradorFormaDeVenda.ObterDescricao(preco.FormaDeVenda)
            };
        }
    }
}
