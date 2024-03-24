using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pharma_izi.core.infrastructure.Database;
using System;
using System.Collections.Generic;

namespace pharma_izi.core.handler.mediator.medicamento.search
{
    internal class GetMedicamentosHandler : IRequestHandler<GetMedicamentosQuery, GetMedicamentosOut>
    {
        private readonly PharmaIziContext _context;
        private readonly IMapper _mapper;

        public GetMedicamentosHandler(PharmaIziContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetMedicamentosOut> Handle(GetMedicamentosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var medicamentos = await _context.Medicamentos
                    .Where(m => m.Nombre.Contains(request.TerminoBusqueda))
                    .ToListAsync();

                var medicamentosParsed = _mapper.Map<List<GetMedicamentosOut.MedicamentoInformation>>(medicamentos);

                return new GetMedicamentosOut { medicamentosBusqueda = medicamentosParsed};
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}