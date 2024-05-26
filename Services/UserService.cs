using EscolaApi.Models;
using EscolaApi.Repositories.Interfaces;
using EscolaApi.Services.Interfaces;

namespace EscolaApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public UserService(IUserRepository userRepository, ITokenService tokenService) 
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<string> Login(string username, string password)
        {
            User? user = _userRepository.GetUser(username, password);

            if(user == null) { return String.Empty; }

            string token = await _tokenService.GenerateToken(user);

            return token;
        }
    }
}
