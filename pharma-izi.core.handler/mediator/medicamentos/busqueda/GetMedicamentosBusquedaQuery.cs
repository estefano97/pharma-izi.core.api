using MediatR;


namespace pharma_izi.core.handler.mediator.medicamento.search;

public class GetMedicamentosBusquedaQuery : IRequest<GetMedicamentosBusquedaOut>
{
    public string TerminoBusqueda { get; set; }
}