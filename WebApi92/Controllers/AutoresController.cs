using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi92.Context;
using WebApi92.Services;

namespace WebApi92.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorServices _autorServices;
        public AutoresController(IAutorServices autorServices)
        {
            _autorServices = autorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            return Ok(await _autorServices.GetAutores());
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor(Autor autor)
        {
            return Ok(await _autorServices.CrearAutor(autor));
        }




        [HttpGet("{PkAutor}")]
        public async Task<IActionResult> GetAutor(int PkAutor)
        {
            var response = await _autorServices.GetAutor(PkAutor);
            return Ok(response);
        }

        [HttpPut("{PkAutor}")]
        public async Task<IActionResult> EditarAutor(int PkAutor, [FromBody] AutoresResponse request)
        {
            var response = await _autorServices.EditarAutor(PkAutor, request);
            return Ok(response);
        }

        [HttpDelete("{PkAutor}")]
        public async Task<IActionResult> BorrarAutor(int PkAutor)
        {
            var response = await _autorServices.BorrarAutor(PkAutor);
            return Ok(response);
        }

    }
}
