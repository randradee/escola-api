using EscolaApi.Domain.Dtos;
using EscolaApi.Domain.Services.Communication;

namespace EscolaApi.Domain.Services
{
    public interface IUsuarioService
    {
        Task<Response<LoginResponseDto>> Login(string login, string senha);

        Task<Response<CadastroDto>> Cadastrar(CadastroDto cadastroDto);
    }
}
