using EscolaApi.Domain.Dtos;
using EscolaApi.Domain.Services.Communication;

namespace EscolaApi.Domain.Services
{
    public interface IUsuarioService
    {
        Task<Response<UsuarioDto>> Login(LoginDto usuario, CancellationToken cancellationToken);

        Task<Response<CadastroDto>> Cadastrar(CadastroDto cadastroDto, CancellationToken cancellationToken);
    }
}
