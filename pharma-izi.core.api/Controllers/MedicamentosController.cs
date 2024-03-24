using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using pharma_izi.core.api.Controllers._base;
using pharma_izi.core.handler.mediator.medicamento.search;
using System;
using System.Threading.Tasks;
using pharma_izi.core.api.DTOs.Medicamentos;

namespace pharma_izi.core.api.Controllers
{
    public class MedicamentosController : ApiBaseController
    {
        private readonly IMediator _mediator;

        public MedicamentosController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchMedicamentos([FromBody] SearchMedicamentoDTO bodyReq)
        {
            try
            {
                var query = new GetMedicamentosBusquedaQuery { TerminoBusqueda = bodyReq.searchTerm };
                var respuesta = await _mediator.Send(query);

                if (respuesta.medicamentosBusqueda == null) return NotFound("Medicamento no encontrado!");

                return Ok(respuesta.medicamentosBusqueda);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al buscar medicamentos.");
            }
        }
    }
}