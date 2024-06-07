using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi92.Services;

namespace WebApi92.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuariosController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _usuarioServices.GetUsuarios();
            return Ok(response);
        }

        [HttpGet("{PkUsuario}")]
        public async Task<IActionResult> GetUsuario(int PkUsuario)
        {
            var response = await _usuarioServices.GetUsuario(PkUsuario);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuariosResponse request)
        {
            var response = await _usuarioServices.CrearUsuario(request);
            return Ok(response);
        }

        [HttpPut("{PkUsuario}")]
        public async Task<IActionResult> Editar( int PkUsuario, [FromBody] UsuariosResponse request)
        {
            var response = await _usuarioServices.EditarUsuario(PkUsuario, request);
            return Ok(response);
        }

        [HttpDelete("{PkUsuario}")]
        public async Task<IActionResult> Borrar(int PkUsuario)
        {
            var response = await _usuarioServices.BorrarUsuario(PkUsuario);
            return Ok(response);
        }



    }
}
