using MediatR;
using Microsoft.AspNetCore.Mvc;
using pharma_izi.core.infrastructure.helpers.consts;
using pharma_izi.core.infrastructure.helpers.services;

namespace pharma_izi.core.api.Controllers._base
{

    [Route("v1/[controller]")]
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        protected ApiBaseController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        protected ApiBaseController(IMediator mediator, IClaimsManager claimsManager)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _claimsManager = claimsManager ?? throw new ArgumentNullException(nameof(claimsManager));
        }

        protected IMediator _mediator { get; }
        private IClaimsManager _claimsManager { get; }

        protected string ReadClaimFromToken(string TokenClaims)
        {
            string identity = HttpContext.User.Claims.FirstOrDefault(el => el.Type == TokenClaims).Value;

            return _claimsManager.DesencriptarClaim(identity);
        }
    }
}
