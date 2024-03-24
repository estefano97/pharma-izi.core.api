using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pharma_izi.core.infrastructure.Database;
using pharma_izi.core.infrastructure.helpers.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.doctor.getAllRecetas
{
    internal class GetAllRecetasDoctorHandler : IRequestHandler<GetAllRecetasDoctorQuery, GetAllRecetasDoctorOut>
    {
        private readonly PharmaIziContext _context;
        private readonly IMapper _mapper;

        public GetAllRecetasDoctorHandler(PharmaIziContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllRecetasDoctorOut> Handle(GetAllRecetasDoctorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var recetasByDoctor = await _context.Recetas
                    .Include(el => el.IdClienteNavigation)
                    .Where(el => el.IdDoctor == request.IdDoctor).ToListAsync();

                var recetasMapped = _mapper.Map<List<GetAllRecetasDoctorOut.RecetasByDoctor>>(recetasByDoctor);

                return new GetAllRecetasDoctorOut() { recetasDoctor = recetasMapped };
            }
            catch(Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
