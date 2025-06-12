using Microsoft.AspNetCore.Mvc;
using MovieStar.Application.Contracts.Services;
using MovieStar.Application.DTOs.Request;

namespace MovieStar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios);
        }
        [HttpGet("get-by-email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var usuario = await _usuarioService.GetByEmailAsync(email);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");
            return Ok(usuario);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (loginRequest == null)
                return BadRequest("Dados inválidos.");
            var usuario = await _usuarioService.LoginAsync(loginRequest);
            if (usuario == null)
                return Unauthorized("Usuário ou senha inválidos.");
            return Ok(usuario);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Add([FromBody] RegistroRequest usuarioRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (usuarioRequest == null)
                return BadRequest("Dados inválidos.");
            await _usuarioService.AddAsync(usuarioRequest);
            return CreatedAtAction(nameof(GetByEmail), new { email = usuarioRequest.Email }, usuarioRequest);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] RegistroRequest usuarioRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (usuarioRequest == null)
                return BadRequest("Dados inválidos.");
            try
            {
                await _usuarioService.UpdateAsync(usuarioRequest);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _usuarioService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}