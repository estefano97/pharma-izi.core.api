using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pharma_izi.core.api.Controllers._base;
using pharma_izi.core.api.DTOs.receta;
using pharma_izi.core.handler.mediator.doctor.getAllRecetas;
using pharma_izi.core.handler.mediator.receta.crearCodigoQR;
using pharma_izi.core.handler.mediator.receta.create;
using pharma_izi.core.infrastructure.helpers.consts;
using pharma_izi.core.infrastructure.helpers.services;
using System.Security.Claims;

namespace pharma_izi.core.api.Controllers
{
    [Authorize(Policy = AuthenticationRoles.Doctor)]
    public class RecetaDoctorController : ApiBaseController
    {
        public RecetaDoctorController(IMediator mediator, IClaimsManager claimsManager) : base(mediator, claimsManager)
        {
        }

        [HttpPost("crear")]
        public async Task<IActionResult> createReceta([FromBody] CrearRecetaDoctorDTO request)
        {
            try
            {
                string idDoctorDesencrypted = ReadClaimFromToken(TokenClaims.id);
                Guid idDoctor = Guid.Parse(idDoctorDesencrypted);
                var req = await _mediator.Send(
                    new CrearRecetaDoctorQuery { 
                        Descripcion = request.Descripcion, 
                        informacionCliente = request.informacionCliente, 
                        medicamentos = request.medicamentos, 
                        IdDoctor = idDoctor 
                    }
                );
                return Ok("receta creada con exito!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAllRecetasByDoctor()
        {
            try
            {
                string idDoctorDesencrypted = ReadClaimFromToken(TokenClaims.id);
                Guid idDoctor = Guid.Parse(idDoctorDesencrypted);

                var request = await _mediator.Send(new GetAllRecetasDoctorQuery { IdDoctor = idDoctor });

                return Ok(request);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
