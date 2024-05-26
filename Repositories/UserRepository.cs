using EscolaApi.Models;
using EscolaApi.Repositories.Interfaces;

namespace EscolaApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User? GetUser(string username, string password)
        {
            var users = new List<User>
            {
                new() { Id = 1, Username = "batman", Password = "batman", Role = "manager" },
                new() { Id = 2, Username = "robin", Password = "robin", Role = "employee" }
            };
            return users.FirstOrDefault( x => String.Equals(x.Username.ToLower(), username.ToLower())
                                            && String.Equals(x.Password.ToLower(), password.ToLower()));
        }
    }
}
