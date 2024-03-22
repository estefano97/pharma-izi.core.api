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
        public ClienteInformation informacionCliente { get; set; }
        public List<MedicamentosAgregados> medicamentos { get; set; }
        public string Descripcion { get; set; }
        public Guid IdDoctor { get; set; }
        public class ClienteInformation
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string email { get; set; }
            public string celular { get; set; }
            public string identificacion { get; set; }
        } 

        public class MedicamentosAgregados
        {
            public string nombreMedicamento { get; set; }
            public Guid? idPresentacionMedicina { get; set; }
            public List<AdicionalMedicamento> descripcionesAdicionales { get; set; }
        }

        public class AdicionalMedicamento
        {
            public string valor { get; set; }
            public int orden { get; set; }
        }
    }
}
