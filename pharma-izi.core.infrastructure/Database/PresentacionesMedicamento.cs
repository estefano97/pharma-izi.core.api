using System;
using System.Collections.Generic;

namespace pharma_izi.core.infrastructure.Database;

public partial class PresentacionesMedicamento
{
    public Guid Id { get; set; }

    public decimal Valor { get; set; }

    public string? Descripcion { get; set; }

    public Guid IdMedicamento { get; set; }

    public virtual Medicamento IdMedicamentoNavigation { get; set; } = null!;
}
