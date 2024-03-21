using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace pharma_izi.core.api.Controllers._base
{

    [Route("v1/[controller]")]
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        protected ApiBaseController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        protected IMediator _mediator { get; }
    }
}
