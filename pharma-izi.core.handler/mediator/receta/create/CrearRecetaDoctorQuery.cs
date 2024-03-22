using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.receta.create
{
    public class CrearRecetaDoctorQuery : IRequest<CrearRecetaDoctorOut>
    {
        public ClienteInformation information { get; set; }
        public class ClienteInformation
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string email { get; set; }
            public string celular { get; set; }
            public string identificacion { get; set; }
        }
    }
}
