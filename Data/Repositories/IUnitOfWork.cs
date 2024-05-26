namespace EscolaApi.Data.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
