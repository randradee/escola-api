using EscolaApi.Domain.Dtos.Aluno;
using EscolaApi.Domain.Dtos.Auth;
using EscolaApi.Domain.Services;
using EscolaApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace EscolaApi.Controllers
{
    [Route("/api/[controller]")]
    public class AlunoController(IAlunoService alunoService) : Controller
    {
        private readonly IAlunoService _alunoService = alunoService;

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAluno([FromBody] CreateAlunoDto createAlunoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _alunoService.CreateAluno(createAlunoDto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Created(result.Message, result.Resource);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("{id}")]
        public async Task<IActionResult> GetAluno([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _alunoService.GetAluno(id);
        }
    }
}
