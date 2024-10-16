namespace BibliotecaBasis.Comum.Enumeradores
{
    public enum FormaDeVenda
    {
        BALCAO = 1,
        SELF_SERVICE = 2,
        INTERNET = 3,
        EVENTO = 4,
        OUTROS = 5
    }

    public static class DescricaoEnumeradorFormaDeVenda
    {
        public static string ObterDescricao(FormaDeVenda enumerador)
        {
            return enumerador switch
            {
                FormaDeVenda.BALCAO => "Balcao",
                FormaDeVenda.SELF_SERVICE => "Self-Service",
                FormaDeVenda.INTERNET => "Internet",
                FormaDeVenda.EVENTO => "Evento",
                FormaDeVenda.OUTROS => "Outros",
                _ => "",
            };
        }        
    }
}
