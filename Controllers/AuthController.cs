using EscolaApi.Domain.Dtos;
using EscolaApi.Domain.Services;
using EscolaApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [Route("/api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUsuarioService _userService;

        public AuthController(IUsuarioService userService)
        {
            _userService = userService;
        }

        [HttpPost("/login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _userService.Login(loginDto.Login, loginDto.Senha);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }

        [HttpPost("/cadastro")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Cadastrar([FromBody] CadastroDto cadastroDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _userService.Cadastrar(cadastroDto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Created(result.Message, result.Resource);
        }
    }
}
