using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Core.Exceptions;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.Enums;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _service;

        public LivroController(ILivroService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LivroViewModel>> Listar()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult BuscarLivro(int id)
        {
            var livro = _service.GetById(id);
            return Ok(livro);
        }

        [HttpPost]
        public ActionResult CriarLivro([FromBody] CreateLivroDto livro)
        {
            LivroViewModel created = _service.Create(livro);
            return CreatedAtAction(nameof(BuscarLivro), new { id = created.Id }, created);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Livro livro)
        {
            LivroViewModel generoLivroDto = _service.Update(id, livro);
            return Ok(generoLivroDto);
        }

        [HttpPatch("atualizarStatus")]
        public IActionResult AtualizarStatus([FromQuery] int id, [FromQuery] StatusLivro novoStatus)
        {
            LivroViewModel dto = _service.AtualizarStatus(id, novoStatus);
            return Ok(dto);
        }

        [HttpPatch("avaliar")]
        public IActionResult Avaliar([FromQuery] int id, [FromQuery] int novaNota)
        {
            LivroViewModel dto = _service.AvaliarLivro(id, novaNota);
            return Ok(dto);
        }
    }
}
