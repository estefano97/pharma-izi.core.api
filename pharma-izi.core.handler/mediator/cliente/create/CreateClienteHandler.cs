using AutoMapper;
using MediatR;
using pharma_izi.core.infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.cliente.create
{
    internal class CreateClienteHandler : IRequestHandler<CreateClienteQuery, CreateClienteOut>
    {
        private readonly PharmaIziContext _context;
        private readonly IMapper _mapper;

        public CreateClienteHandler(PharmaIziContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateClienteOut> Handle(CreateClienteQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = new Cliente {
                    Id = Guid.NewGuid(),
                    Apellido = request.information.apellido, 
                    Celular = request.information.celular, 
                    Email = request.information.email, 
                    Identificacion = request.information.identificacion, 
                    Nombre = request.information.nombre
                };
                var req = await _context.Clientes.AddAsync(usuario);

                return new CreateClienteOut { idUsuario = usuario.Id };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
