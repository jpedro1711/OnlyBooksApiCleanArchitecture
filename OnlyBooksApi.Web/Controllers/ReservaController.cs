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
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _service;

        public ReservaController(IReservaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ReservaViewModel>> Listar()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult BuscarReserva(int id)
        {
            var reserva = _service.GetById(id);
            return Ok(reserva);
        }

        [HttpGet("usuario")]
        public IActionResult GetReservaPorUsuario([FromQuery] string userEmail)
        {
            return Ok(_service.GetByUserEmail(userEmail));
        }

        [HttpPost]
        public ActionResult CriarReserva([FromBody] CreateReservaDto reserva)
        {
            ReservaViewModel created = _service.Create(reserva);
            return CreatedAtAction(nameof(BuscarReserva), new { id = created.Id }, created);
        }

        [HttpPatch("atualizarStatus")]
        public IActionResult AtualizarStatus([FromQuery] int id, [FromQuery] StatusReserva novoStatus)
        {
            ReservaViewModel reservaDto = _service.UpdateStatus(id, novoStatus);
            return Ok(reservaDto);
        }
    }
}
