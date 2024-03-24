using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.doctor.getAllRecetas
{
    public class GetAllRecetasDoctorQuery : IRequest<GetAllRecetasDoctorOut>
    {
        public Guid IdDoctor { get; set; }
    }
}
