﻿using Microsoft.AspNetCore.Mvc;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Core.Exceptions;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.Enums;

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

        [HttpGet("livrosEmprestados")]
        public ActionResult<List<LivroDto>> GetLivrosEmprestados()
        {
            return Ok(_service.GetLivrosEmprestados());
        }

        [HttpGet("{id}")]
        public ActionResult BuscarEmprestimo(int id)
        {
            try
            {
                var emprestimo = _service.GetById(id);
                return Ok(emprestimo);
            }
            catch (EmprestimoException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> CriarEmprestimo([FromBody] CreateEmprestimoDto emprestimo)
        {
            try
            {
                var result = await _service.CreateAsync(emprestimo);

                return Ok(result.message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Ocorreu um erro.", Detalhes = ex.Message });
            }
        }




        [HttpPatch("atualizarStatus")]
        public IActionResult AtualizarStatus([FromQuery] int id, [FromQuery] StatusEmprestimo novoStatus)
        {
            try
            {
                EmprestimoDto emprestimoDto = _service.UpdateStatus(id, novoStatus);
                return Ok(emprestimoDto);

            }
            catch (ReservaException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}