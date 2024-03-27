using pharma_izi.core.handler.mediator.receta.create;

namespace pharma_izi.core.api.DTOs.receta
{
    public class CrearRecetaDoctorDTO
    {
        public CrearRecetaDoctorQuery.ClienteInformation informacionCliente { get; set; }
        public List<CrearRecetaDoctorQuery.MedicamentosAgregados> medicamentos { get; set; }
        public string Descripcion { get; set; }
        public Guid IdDoctor { get; set; }
    }
}
