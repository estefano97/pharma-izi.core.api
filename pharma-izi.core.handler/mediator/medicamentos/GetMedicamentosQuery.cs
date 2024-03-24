using MediatR;


namespace pharma_izi.core.handler.mediator.medicamento.search;

public class GetMedicamentosQuery : IRequest<GetMedicamentosOut>
{
    public string TerminoBusqueda { get; set; }
}