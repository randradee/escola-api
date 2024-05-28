using EscolaApi.Data.Repositories;
using EscolaApi.Domain.Enums;
using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Repositories;
using EscolaApi.Domain.Services;
using EscolaApi.Domain.Services.Communication;
using EscolaApi.Domain.Dtos.Auth;

namespace EscolaApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly string _pepper;
        private readonly int _iteration;

        public UsuarioService(IUserRepository userRepository, ITokenService tokenService, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _pepper = _configuration["Pepper"]!;
            _iteration = 3;
        }

        public async Task<Response<UsuarioDto>> Login(LoginDto loginDto, CancellationToken cancellationToken)
        {
            try
            {
                Usuario? usuario = await _userRepository.GetUsuario(loginDto.Login);

                if (usuario == null) return new Response<UsuarioDto>("Usuário ou senha incorreto(s)");

                var passwordHash = PasswordHasher.ComputeHash(loginDto.Senha, usuario.SenhaSalt!, _pepper, _iteration);

                if(passwordHash != usuario.SenhaHash)
                {
                    return new Response<UsuarioDto>("Usuário ou senha incorreto(s)");
                }
              
                string token = await _tokenService.GenerateToken(usuario);

                return new Response<UsuarioDto>(new UsuarioDto(loginDto.Login, token));
            }
            catch (Exception ex)
            {
                return new Response<UsuarioDto>($"erro: {ex.Message}");
            }
        }

        public async Task<Response<CadastroDto>> Cadastrar(CadastroDto cadastroDto, CancellationToken cancellationToken)
        {
            var usuario = new Usuario
            {
                Login = cadastroDto.Login,
                SenhaSalt = PasswordHasher.GenerateSalt(),
                Cargo = Enum.Parse<ECargo>(cadastroDto.Cargo)
            };
            usuario.SenhaHash = PasswordHasher.ComputeHash(cadastroDto.Senha, usuario.SenhaSalt, _pepper, _iteration);

            try
            {
                Usuario? alreadyExists = await _userRepository.GetUsuario(cadastroDto.Login);

                if (alreadyExists != null)
                {
                    return new Response<CadastroDto>("Já existe um usuário com esse nome");
                }

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
