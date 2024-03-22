using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.cliente.create
{
    internal class CreateClienteHandler : IRequestHandler<CreateClienteQuery, CreateClienteOut>
    {
        public Task<CreateClienteOut> Handle(CreateClienteQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
