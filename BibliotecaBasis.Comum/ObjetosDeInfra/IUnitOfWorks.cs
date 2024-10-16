namespace BibliotecaBasis.Comum.ObjetosDeInfra
{
    public interface IUnitOfWorks
    {
        Task<bool> Commit();
    }
}