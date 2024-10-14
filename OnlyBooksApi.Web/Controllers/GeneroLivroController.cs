using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroLivroController : ControllerBase
    {
        private readonly IGeneroLivroService _service;

        public GeneroLivroController(IGeneroLivroService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<GeneroLivroDto>> Listar()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult BuscarGenero(int id)
        {
            var generoLivro = _service.GetById(id);
            return Ok(generoLivro);
        }

        [HttpPost]
        public ActionResult CriarGeneroLivro([FromBody] GeneroLivroDto generoLivro)
        {
            GeneroLivroViewModel created = _service.Create(generoLivro);
            return CreatedAtAction(nameof(BuscarGenero), new { created.Id }, created);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] GeneroLivroDto genero)
        {
            GeneroLivroViewModel generoLivroDto = _service.Update(id, genero);
            return Ok(generoLivroDto);
        }
    }
}
