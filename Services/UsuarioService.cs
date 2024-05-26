using EscolaApi.Data.Repositories;
using EscolaApi.Domain.Dtos;
using EscolaApi.Domain.Enums;
using EscolaApi.Domain.Models;
using EscolaApi.Domain.Repositories;
using EscolaApi.Domain.Services;
using EscolaApi.Domain.Services.Communication;

namespace EscolaApi.Services
{
    public class UsuarioService(IUserRepository userRepository, ITokenService tokenService, IUnitOfWork unitOfWork) : IUsuarioService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ITokenService _tokenService = tokenService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Response<LoginResponseDto>> Login(string login, string senha)
        {
            Usuario user = await _userRepository.GetUsuario(login);

            try
            {
                string token = await _tokenService.GenerateToken(user);

                return new Response<LoginResponseDto>(new LoginResponseDto(login, token));
            }
            catch (Exception ex)
            {
                return new Response<LoginResponseDto>($"erro: {ex.Message}");
            }
        }

        public async Task<Response<CadastroDto>> Cadastrar(CadastroDto cadastroDto)
        {
            var usuario = new Usuario(new Guid(), cadastroDto.Login, cadastroDto.Senha, ECargo.ADMIN);

            try
            {
                await _userRepository.CreateUsuario(usuario);
                await _unitOfWork.CompleteAsync();

                return new Response<CadastroDto>(cadastroDto);
            }
            catch (Exception ex)
            {
                return new Response<CadastroDto>($"erro: {ex.Message}");
            }


        }
    }
}
