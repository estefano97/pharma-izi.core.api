using System.Text;
using System.Threading.Tasks;

namespace pharma_izi.core.handler.mediator.medicamento.search
{

    public class GetMedicamentosOut
    {
        public List<MedicamentoInformation> medicamentosBusqueda { get; set; } 

        public class MedicamentoInformation
        {
            public Guid Id { get; set; }

            public string Nombre { get; set; } 
            
            public bool EnStock { get; set; } 
            
            public string FotoMedicamento { get; set; } 

            public bool RequiereReceta { get; set; } 
        }
    }

}