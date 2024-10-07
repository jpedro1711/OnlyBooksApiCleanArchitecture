using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Core.Exceptions;
using OnlyBooksApi.Core.Models.Dtos;

namespace OnlyBooksApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<UsuarioResponseDto>> Listar()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult BuscarUsuario(int id)
        {
            try
            {
                var usuario = _service.GetById(id);
                return Ok(usuario);
            }
            catch (UsuarioException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CriarUsuario([FromBody] CreateOrUpdateUsuarioDto usuario)
        {
            UsuarioResponseDto created = _service.Create(usuario);

            return CreatedAtAction(nameof(BuscarUsuario), new { id = created.Id }, created);
        }

        [HttpDelete]
        public IActionResult Remover(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (UsuarioException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] CreateOrUpdateUsuarioDto usuario)
        {
            try
            {
                UsuarioResponseDto usuarioDto = _service.Update(id, usuario);

                return Ok(usuarioDto);
            }
            catch (ReservaException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
