using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.doctor.login
{
    public class LoginDoctorQuery : IRequest<LoginDoctorOut>
    {
        public string identificacion { get; set; }
        public string password { get; set; }
    }
}
