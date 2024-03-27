using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pharma_izi.core.infrastructure.Database;
using System;
using System.Collections.Generic;

namespace pharma_izi.core.handler.mediator.medicamento.search
{
    internal class GetMedicamentosBusquedaHandler : IRequestHandler<GetMedicamentosBusquedaQuery, GetMedicamentosBusquedaOut>
    {
        private readonly PharmaIziContext _context;
        private readonly IMapper _mapper;

        public GetMedicamentosBusquedaHandler(PharmaIziContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetMedicamentosBusquedaOut> Handle(GetMedicamentosBusquedaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var medicamentos = await _context.Medicamentos
                    .Where(m => m.Nombre.Contains(request.TerminoBusqueda))
                    .Take(20)
                    .ToListAsync();

                var medicamentosParsed = _mapper.Map<List<GetMedicamentosBusquedaOut.MedicamentoInformation>>(medicamentos);

                return new GetMedicamentosBusquedaOut { medicamentosBusqueda = medicamentosParsed};
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}