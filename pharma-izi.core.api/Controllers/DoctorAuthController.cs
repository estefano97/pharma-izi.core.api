using MediatR;
using Microsoft.AspNetCore.Mvc;
using pharma_izi.core.api.Controllers._base;
using pharma_izi.core.api.DTOs.DoctorAuth;
using pharma_izi.core.handler.mediator.doctor.login;

namespace pharma_izi.core.api.Controllers
{

    public class DoctorAuthController : ApiBaseController
    {
        public DoctorAuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("register")]
        public async Task<IActionResult> LoginDoctor([FromBody]LoginDoctorDTO credentials)
        {
            try
            {
                var respuesta= await _mediator.Send(new LoginDoctorQuery { identificacion = credentials.identificacion, password = credentials.password});

                if (!respuesta.IsSuccess) return Unauthorized();

                return Ok(respuesta);

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
