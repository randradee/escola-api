using EscolaApi.Models;
using EscolaApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [Route("/api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            string token = await _userService.Login(user.Username, user.Password);

            if(token == "") 
            {
                return Unauthorized("Não autorizado");
            }

            return Ok(token);
        }
    }
}
