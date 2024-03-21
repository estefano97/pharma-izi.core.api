using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.doctor.login
{
    public class LoginDoctorOut
    {

        public LoginDoctorInformation informacionDoctor { get; set; }

        public string tokenUsuario { get; set; }

        public bool IsSuccess { get; set; }

        public class LoginDoctorInformation
        {
            public string Nombre { get; set; }

            public string Celular { get; set; }

            public string? NombreConsultorio { get; set; }

            public string Apellido { get; set; }

            public string Identificacion { get; set; }
        }
    }
}
