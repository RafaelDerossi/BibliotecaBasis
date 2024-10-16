using BibliotecaBasis.Comum.Enumeradores;
using BibliotecaBasis.Comum.ObjetosDeDominio;

namespace BibliotecaBasis.Dominio.Entidades
{
    public class Preco(Guid livroId, decimal valor, FormaDeVenda formaDeVenda) : Entidade
    {
        public Guid LivroId { get; private set; } = livroId;

        public decimal Valor { get; private set; } = valor;

        public FormaDeVenda FormaDeVenda { get; private set; } = formaDeVenda;
                       

        public void SetValor(decimal valor) => Valor = valor;
    }
}
