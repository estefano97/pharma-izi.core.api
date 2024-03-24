using AutoMapper;
using pharma_izi.core.handler.mediator.medicamento.search;
using pharma_izi.core.infrastructure.Database;

namespace pharma_izi.core.handler.mapper
{
    public class MedicamentosMapper : Profile
    {
        public MedicamentosMapper()
        {
            CreateMap<Medicamento, GetMedicamentosOut.MedicamentoInformation>();
        }
    }
}