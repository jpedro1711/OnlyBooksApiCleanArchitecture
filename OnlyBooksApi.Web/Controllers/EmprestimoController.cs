using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Core.Exceptions;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.Enums;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmprestimoController : ControllerBase
    {
        private IEmprestimoService _service;
        public EmprestimoController(IEmprestimoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<EmprestimoDto>> Listar()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult BuscarEmprestimo(int id)
        {

            var emprestimo = _service.GetById(id);
            return Ok(emprestimo);
        }

        [HttpPost]
        public async Task<ActionResult> CriarEmprestimo([FromBody] CreateEmprestimoDto emprestimo)
        {

            var result = await _service.CreateAsync(emprestimo);

            return Ok(result);
        }




        [HttpPatch("atualizarStatus")]
        public IActionResult AtualizarStatus([FromQuery] int id, [FromQuery] StatusEmprestimo novoStatus)
        {
            EmprestimoViewModel emprestimo = _service.UpdateStatus(id, novoStatus);
            return Ok(emprestimo);
        }
    }
}
