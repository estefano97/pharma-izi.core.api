using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pharma_izi.core.handler.mediator.cliente.create;
using pharma_izi.core.handler.mediator.receta.crearCodigoQR;
using pharma_izi.core.infrastructure.Database;
using pharma_izi.core.infrastructure.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.receta.create
{
    internal class CrearRecetaDoctorHandler : IRequestHandler<CrearRecetaDoctorQuery, CrearRecetaDoctorOut>
    {
        private readonly PharmaIziContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CrearRecetaDoctorHandler(PharmaIziContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CrearRecetaDoctorOut> Handle(CrearRecetaDoctorQuery request, CancellationToken cancellationToken)
        {
            try
            {

                Cliente clienteReceta = await _context.Clientes.Where(el => el.Identificacion == request.informacionCliente.identificacion).FirstOrDefaultAsync();
                
                //create if not exists
                if(clienteReceta == null)
                {
                    var createdCliente = await _mediator.Send(new CreateClienteQuery
                    {
                        information = new CreateClienteQuery.ClienteInformation
                        {
                            apellido = request.informacionCliente.apellido,
                            celular = request.informacionCliente.celular,
                            email = request.informacionCliente.email,
                            identificacion = request.informacionCliente.identificacion,
                            nombre = request.informacionCliente.nombre
                        }
                    });

                    clienteReceta = createdCliente.cliente;
                }

                var parsedRecetaMedicina = new List<MedicinaReceta>();

                //parseo de cada uno de los medicamentos
                foreach (var medicamentoForAdd in request.medicamentos)
                {
                    List<DetalleMedicina> detalleMedicinaParsed = new();

                    //parseo de informacion adicional
                    foreach (var detalleMedicamento in medicamentoForAdd.descripcionesAdicionales)
                    {
                        detalleMedicinaParsed.Add(new DetalleMedicina
                        {
                            Id = Guid.NewGuid(),
                            Descripcion = detalleMedicamento.valor,
                            Orden = detalleMedicamento.orden
                        });
                    };

                    //si el medicamento no existe, el lo pone como un medicamento extra agregado por el doctor
                    if(medicamentoForAdd.idPresentacionMedicina != null)
                    {
                        PresentacionesMedicamento presentacionMedicamentoSearched = await _context.PresentacionesMedicamentos.Include(el => el.IdMedicamentoNavigation).Where(el => el.Id == medicamentoForAdd.idPresentacionMedicina).FirstOrDefaultAsync();
                        parsedRecetaMedicina.Add(new MedicinaReceta
                        {
                            Id = Guid.NewGuid(),
                            IdTipoIva = presentacionMedicamentoSearched.IdMedicamentoNavigation.IdTipoIva,
                            IdPresentacionMedicinaReceta = presentacionMedicamentoSearched.Id,
                            DetalleMedicinas = detalleMedicinaParsed
                        });
                    }
                    else
                    {
                        parsedRecetaMedicina.Add(new MedicinaReceta
                        {
                            Id = Guid.NewGuid(),
                            DetalleMedicinas = detalleMedicinaParsed,
                            IdTipoIva = Guid.Empty,
                            IdPresentacionMedicinaReceta = Guid.Empty,
                            RequiereReceta = false
                        });
                    }
                }


                Receta createdReceta = new Receta
                {
                    Id = Guid.NewGuid(),
                    Descripcion = request.Descripcion,
                    FechaRegistro = DateTime.Now,
                    IdCliente = clienteReceta.Id,
                    IdDoctor = request.IdDoctor,
                    MedicinaReceta = parsedRecetaMedicina,
                    IdCodigoQrNavigation = new CodigosQr
                    {
                        Id = Guid.NewGuid(),
                        Valor = ""
                    }
                };
                var addingReceta = await _context.Recetas.AddAsync(createdReceta);
                await _context.SaveChangesAsync();

                var addQrCode = await _mediator.Send(new CrearCodigoQrRecetaQuery { idQrCode = addingReceta.Entity.IdCodigoQr, idReceta = addingReceta.Entity.Id });

                return new CrearRecetaDoctorOut { receta = addingReceta.Entity };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
