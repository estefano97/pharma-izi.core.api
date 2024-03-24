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
        private readonly IMapper _mapper;

        public MedicamentosController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchMedicamentos([FromBody] SearchMedicamentoDTO bodyReq)
        {
            try
            {
                var query = new GetMedicamentosQuery { TerminoBusqueda = bodyReq.searchTerm };
                var respuesta = await _mediator.Send(query);

                return Ok(respuesta.medicamentosBusqueda);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al buscar medicamentos.");
            }
        }
    }
}