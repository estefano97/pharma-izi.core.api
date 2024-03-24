using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.doctor.getAllRecetas
{
    public class GetAllRecetasDoctorOut
    {
        public List<RecetasByDoctor> recetasDoctor { get; set; } 
        public class RecetasByDoctor
        {
            public Guid id { get; set; }
            public string descripcion { get; set; }
            public DateTime fecha_registro { get; set; }
            public string nombreCliente { get; set; }
            public string apellidoCliente { get; set; }
            public string emailCliente { get; set; }
            public string celularCliente { get; set; }

        }
    }
}
