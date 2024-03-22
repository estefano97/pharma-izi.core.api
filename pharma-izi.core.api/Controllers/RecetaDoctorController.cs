using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pharma_izi.core.api.Controllers._base;
using pharma_izi.core.handler.mediator.receta.crearCodigoQR;
using pharma_izi.core.infrastructure.helpers;

namespace pharma_izi.core.api.Controllers
{
    //[Authorize(Roles = AuthenticationRoles.Doctor)]
    public class RecetaDoctorController : ApiBaseController
    {
        public RecetaDoctorController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("receta")]
        public async Task<IActionResult> createReceta()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("prueba")]
        public async Task<IActionResult> testearQrCode([FromQuery]Guid idPrueba)
        {
            try
            {
                var req = await _mediator.Send(new CrearCodigoQrRecetaQuery { idReceta = idPrueba });
                return Ok(req);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
