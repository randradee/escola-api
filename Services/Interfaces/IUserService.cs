namespace EscolaApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(string username, string password);
    }
}
