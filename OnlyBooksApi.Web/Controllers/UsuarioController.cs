using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Core.Exceptions;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.ViewModels;

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
        public ActionResult<List<UsuarioViewModel>> Listar()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult BuscarUsuario(int id)
        {
            var usuario = _service.GetById(id);
            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult CriarUsuario([FromBody] CreateOrUpdateUsuarioDto usuario)
        {
            UsuarioViewModel created = _service.Create(usuario);
            return CreatedAtAction(nameof(BuscarUsuario), new { id = created.Id }, created);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] CreateOrUpdateUsuarioDto usuario)
        {
            UsuarioViewModel usuarioDto = _service.Update(id, usuario);
            return Ok(usuarioDto);
        }
    }
}
